using NewHorizon.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace NewHorizon
{
    public partial class FormInstance : Form
    {
        private static int instanceIndex = 0;

        public DialogResult Result { get; set; }

        public DeclareObject DeclareObject { get; set; }
        public GameObject GameObject { get; set; }

        public FormInstance(GameObject gameObject)
        {
            InitializeComponent();

            this.GameObject = gameObject;
            if (gameObject == null)
            {
                InitializeGameObject();
            }
            else {
                UpdateNodeInfo();
            }


        }

        private void InitializeGameObject()
        {

            Transform transform = new Transform();
            transform.Position = new Vector3(0f);
            transform.Rotation = new Vector3(0f);
            transform.Scale = new Vector3(0.1f);

            GameObject = new GameObject(DeclareObject, DeclareObject.declareName + instanceIndex.ToString(), transform);

            instanceIndex++;
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {

        }

        private void InstanceAttrTree_DoubleClick(object sender, EventArgs e)
        {
            TreeNode selectedNode = InstanceAttrTree.SelectedNode;
            if (selectedNode == null) return;

            int objectIndex = InstanceAttrTree.Nodes.IndexOf(selectedNode);


            if (selectedNode.Name == "value")
            {
                string info = Interaction.InputBox("请输入新的值", "信息", selectedNode.Text, -1, -1);
                if (info.Length > 0)
                {
                    selectedNode.Text = info;
                    UpdateObjectInfo();
                }

            }

        }

        private void UpdateNodeInfo()
        {
            var nodes = NodeUtil.GetAllNodes(InstanceAttrTree.Nodes);
            foreach (TreeNode node in nodes)
            {

                if (node.Name == "value")
                {

                    TreeNode parent = node.Parent;
                    if (parent == null) continue;

                    if (parent.Text == "TagName")
                    {
                       node.Text = GameObject.TagName;
                    }
                    else {
                        TreeNode grandNode = parent.Parent;
                        if (grandNode == null) continue;

                        UpdateNodeFromTransform(grandNode.Text, parent.Text, node);
                    }
                }
            }
        }

        private void UpdateObjectInfo()
        {
            var nodes = NodeUtil.GetAllNodes(InstanceAttrTree.Nodes);
            foreach (TreeNode node in nodes)
            {
                if (node.Name == "value")
                {
                    TreeNode parent = node.Parent;
                    if (parent == null) continue;

                    if (parent.Text == "TagName")
                    {
                        GameObject.TagName = node.Text;
                    }
                    else {
                        TreeNode grandNode = parent.Parent;
                        if (grandNode == null) continue;

                        switch (grandNode.Text)
                        {
                            case "Position":
                                UpdatePosition(node, parent.Text); break;
                            case "Rotation":
                                UpdateRotation(node, parent.Text); break;
                            case "Scale":
                                UpdateScale(node, parent.Text); break;
                        }
                    }
                }
            }
        }


        private void UpdateNodeFromTransform(string vectorName, string type, TreeNode valueNode)
        {
            Vector3 vector;
            switch (vectorName)
            {
                case "Position":
                    vector = GameObject.Transform.Position; break;
                case "Rotation":
                    vector = GameObject.Transform.Rotation; break;
                case "Scale":
                    vector = GameObject.Transform.Scale; break;

                default:
                    return;
            }

            string info = "";

            switch (type)
            {
                case "X":
                    info =  vector.X.ToString(); break;
                case "Y":
                    info = vector.Y.ToString(); break;
                case "Z":
                    info =  vector.Z.ToString(); break;

                default:
                    return;

            }
            valueNode.Text = info;

        }

        private void UpdatePosition(TreeNode node, string type)
        {
            switch (type)
            {
                case "X":
                    GameObject.Transform.Position.X = float.Parse(node.Text);
                    break;
                case "Y":
                    GameObject.Transform.Position.Y = float.Parse(node.Text);
                    break;
                case "Z":
                    GameObject.Transform.Position.Z = float.Parse(node.Text);
                    break;

                default:
                    break;
            }
        }




        private void UpdateRotation(TreeNode node, string type)
        {
            switch (type)
            {
                case "X":
                    GameObject.Transform.Rotation.X = float.Parse(node.Text);
                    break;
                case "Y":
                    GameObject.Transform.Rotation.Y = float.Parse(node.Text);
                    break;
                case "Z":
                    GameObject.Transform.Rotation.Z = float.Parse(node.Text);
                    break;

                default:
                    break;
            }
        }


        private void UpdateScale(TreeNode node, string type)
        {
            switch (type)
            {
                case "X":
                    GameObject.Transform.Scale.X = float.Parse(node.Text);
                    break;
                case "Y":
                    GameObject.Transform.Scale.Y = float.Parse(node.Text);
                    break;
                case "Z":
                    GameObject.Transform.Scale.Z = float.Parse(node.Text);
                    break;

                default:
                    break;
            }
        }
    }
}
