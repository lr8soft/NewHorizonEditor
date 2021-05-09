using Microsoft.VisualBasic;
using NewHorizon.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NewHorizon
{
    public partial class FormDeclare : Form
    {
        private static string declareFolder = "assets\\Config\\object\\";
        public DialogResult Result { get; set; }
        public DeclareObject DeclareObject { get; set; }



        public FormDeclare(DeclareObject declareObject)
        {
            InitializeComponent();

            DeclareObject = declareObject;
            if (declareObject == null)
            {
                DeclareObject = new DeclareObject("declareObject", declareFolder + "declareObject.json", false);

                UpdateObjectInfo();
            }
            else {
                UpdateNodeInfo();
            }
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {

        }

        private void UpdateNodeInfo()
        {
            var nodes = NodeUtil.GetAllNodes(DeclareAttrTreeview.Nodes);
            foreach (var node in nodes)
            {
                if (node.Name == "value")
                {
                    TreeNode parent = node.Parent;
                    if (parent == null) continue;

                    switch (parent.Text)
                    {
                        case "DeclareName":
                            node.Text = DeclareObject.declareName; break;

                        case "ModelName":
                            node.Text = DeclareObject.modelName; break;

                        case "ShaderName":
                            node.Text = DeclareObject.shaderName; break;

                        case "ScriptName":
                            node.Text = DeclareObject.scriptName; break;
                    }

                }
            }
        }

        private void DeclareAttrTreeview_DoubleClick(object sender, EventArgs e)
        {
            TreeNode selectedNode = DeclareAttrTreeview.SelectedNode;
            if (selectedNode == null) return;

            TreeNode parent = selectedNode.Parent;
            if (parent == null) return;

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

        private void UpdateObjectInfo()
        {
            var nodes = NodeUtil.GetAllNodes(DeclareAttrTreeview.Nodes);
            foreach (TreeNode node in nodes)
            {
                if (node.Name == "value")
                {
                    TreeNode parent = node.Parent;
                    if (parent == null) continue;

                    switch (parent.Text)
                    {
                        case "DeclareName":
                            DeclareObject.declareName = node.Text;
                            DeclareObject.declareJsonPath = declareFolder + node.Text + ".json";
                            break;

                        case "ModelName":
                            DeclareObject.modelName = node.Text; break;

                        case "ShaderName":
                            DeclareObject.shaderName = node.Text; break;

                        case "ScriptName":
                            DeclareObject.scriptName = node.Text; break;
                    }
                }
            }

        }
    }
}
