using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NewHorizon.Util;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NewHorizon
{
    public partial class FormMain : Form
    {
        public static string assetsPath = "";
        public static Dictionary<string, DeclareObject> declareObjects = new Dictionary<string, DeclareObject>();
        public static List<GameObject> instanceObjects = new List<GameObject>();



        public FormMain()
        {
            InitializeComponent();
        }

        private void SplitContainerFixedWidth(object sender, EventArgs e)
        {
            ((SplitContainer)sender).SplitterDistance = ((SplitContainer)sender).Width / 2 ;
        }

        private void 打开OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "选择NewHorizon的根文件夹";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                assetsPath = dialog.SelectedPath;

                LoadAssetsFolder();
                LoadUIData();
            }

        }

        private void LoadAssetsFolder()
        {
            string instanceFilePath = assetsPath + "\\assets\\Config\\Instance.json";

            try
            {
                using (StreamReader streamReader = File.OpenText(instanceFilePath))
                {
                    using (JsonTextReader jsonReader = new JsonTextReader(streamReader))
                    {
                        JObject jObject = (JObject)JToken.ReadFrom(jsonReader);

                        var objectsDeclared = jObject["objectDeclare"]["object"].ToArray<JToken>();//读取所有objectDeclare部分

                        foreach (var declareObject in objectsDeclared)
                        {
                            string declareName = declareObject["objectName"].ToString();
                            string declareJsonPath = declareObject["objectJson"].ToString();

                            DeclareObject gameDeclareObject = new DeclareObject(declareName, declareJsonPath);
                            declareObjects[declareName] = gameDeclareObject;

                        }

                        JToken objectInstanced = jObject["objectInstance"];
                        foreach(var declareValue in declareObjects)
                        {
                            try
                            {
                                var instanceGroup = objectInstanced[declareValue.Key].ToArray<JToken>();
                                foreach (var instance in instanceGroup)
                                {
                                    string instanceTagName = instance["tagName"].ToString();
                                    var instanceTransformObject = instance["transform"];

                                    float[] position = GetVector3FromJson(instanceTransformObject, "position");
                                    float[] scale = GetVector3FromJson(instanceTransformObject, "scale");
                                    float[] rotation = GetVector3FromJson(instanceTransformObject, "rotation");

                                    Transform transform = new Transform();
                                    transform.Position = new Vector3(position[0], position[1], position[2] );
                                    transform.Rotation = new Vector3(rotation[0], rotation[1], rotation[2]);
                                    transform.Scale = new Vector3(scale[0], scale[1], scale[2]);

                                    GameObject gameObject = new GameObject(declareValue.Value, instanceTagName, transform);
                                    instanceObjects.Add(gameObject);
                                }
                            }
                            catch (Exception expt)
                            {
                                Console.WriteLine(expt.Message);
                                continue;
                            }

                        }

                    }

                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("读取NewHorizon项目失败！\n" + exception.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void LoadUIData()
        {
            Dictionary<string, TreeNode> instanceParents = new Dictionary<string, TreeNode>();
            if (declareObjects.Count > 0)
            {
                TreeNodeCollection treeNodeCollection =  declareTreeView.Nodes;
                TreeNodeCollection instanceCollection = InstanceObjectTreeView.Nodes;
                foreach (var declareObject in declareObjects)
                {
                    TreeNodeDeclared treeNodeDeclared = new TreeNodeDeclared();
                    treeNodeDeclared.DeclareObject = declareObject.Value;
                    treeNodeCollection.Add(treeNodeDeclared);

                    TreeNode treeNodeInstanceParent = new TreeNode();
                    treeNodeInstanceParent.Text = declareObject.Value.declareName;
                    instanceCollection.Add(treeNodeInstanceParent);
                    instanceParents.Add(declareObject.Value.declareName, treeNodeInstanceParent);
                }
            }

            if (instanceParents.Count > 0 && instanceObjects.Count > 0)
            {
                foreach (var gameObject in instanceObjects)
                {
                    TreeNode parentNode = instanceParents[gameObject.DeclareObject.declareName];

                    TreeNodeInstanced treeNodeInstanced = new TreeNodeInstanced();
                    treeNodeInstanced.InstanceObject = gameObject;

                    parentNode.Nodes.Add(treeNodeInstanced);

                }
            }

        }

        public float[] GetVector3FromJson(JToken jToken, string name)
        {
            float[] info = new float[3];

            var vectorToken = jToken[name].ToArray<JToken>();
            for(int i=0; i < 3; i++)
            {
                float v = float.Parse(vectorToken[i].ToString());
                info[i] = v;
            }

            return info;
        }

        private void InstanceObjectTreeView_DoubleClick(object sender, EventArgs e)
        {
            TreeView treeView = (TreeView)sender;
            TreeNode selectedNode = treeView.SelectedNode;

            if (selectedNode is TreeNodeInstanced)
            {
                TreeNodeInstanced treeNodeInstanced = (TreeNodeInstanced)selectedNode;
            }
        }

        private void buttonAddInstance_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = InstanceObjectTreeView.SelectedNode;
            if (selectedNode == null)
            {
                MessageBox.Show("未选中节点", "信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (selectedNode is TreeNodeInstanced)
            {
                MessageBox.Show("实例无法再次添加实例", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


        }
    }
}
