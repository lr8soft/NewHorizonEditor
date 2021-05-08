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

                    TreeNodeDeclared treeNodeInstanceParent = new TreeNodeDeclared();
                    treeNodeInstanceParent.DeclareObject = (DeclareObject)treeNodeDeclared.DeclareObject.Clone();
                    //两个treeview不能使用同一个treenode

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

                GameObject newObject = (GameObject)treeNodeInstanced.InstanceObject.Clone();

                FormInstance formInstance = new FormInstance(newObject); //根据节点的object信息修改
                if (formInstance.ShowDialog() == DialogResult.OK)
                {

                    treeNodeInstanced.InstanceObject = newObject;
                }

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

            if (!(selectedNode is TreeNodeDeclared))
            {
                MessageBox.Show("节点无法添加实例", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            TreeNodeDeclared treeNodeDeclared = (TreeNodeDeclared)selectedNode;

            FormInstance formInstance = new FormInstance(null);
            if(formInstance.ShowDialog() == DialogResult.OK)
            {
                GameObject returnObject = formInstance.GameObject;
                returnObject.DeclareObject = treeNodeDeclared.DeclareObject;
                insertObject(returnObject);
            }

        }

        private void buttonDeleteInstance_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = InstanceObjectTreeView.SelectedNode;
            if (selectedNode is TreeNodeInstanced)
            {
                TreeNode parentNode = selectedNode.Parent;
                parentNode.Nodes.Remove(selectedNode);
            }

        }

        private void buttonAddOrigin_Click(object sender, EventArgs e)
        {
            FormDeclare formDeclare = new FormDeclare(null);
            if (formDeclare.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void buttonDeleteOrigin_Click(object sender, EventArgs e)
        {

        }

        private void insertObject(GameObject gameObject)
        {
            foreach (TreeNode treeNode in InstanceObjectTreeView.Nodes)
            {
                if (treeNode is TreeNodeDeclared)
                {
                    TreeNodeDeclared treeNodeDeclared = (TreeNodeDeclared)treeNode;

                    if (treeNodeDeclared.DeclareObject.declareName == gameObject.DeclareObject.declareName)
                    {
                        TreeNodeInstanced treeNodeInstanced = new TreeNodeInstanced();
                        treeNodeInstanced.InstanceObject = gameObject;
                        treeNode.Nodes.Add(treeNodeInstanced);
                        return;
                    }
                }

            }
        }

        private void 保存项目SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (assetsPath.Length > 0)
            {
                SaveInstanceJson();
            }
            else {
                MessageBox.Show("未打开任何项目！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SaveInstanceJson()
        {
            JObject instanceObject = new JObject();
            JObject objectDeclare = new JObject();
            JArray objectContainer = new JArray();

            instanceObject.Add("objectDeclare", objectDeclare);
            objectDeclare.Add("object", objectContainer);

            var declareNodes = NodeUtil.GetAllNodes(declareTreeView.Nodes);
            foreach (var node in declareNodes)      //构建objectDeclare中的所有声明为JObject，组合为JArray
            {
                if (!(node is TreeNodeDeclared)) continue;

                TreeNodeDeclared treeNodeDeclared = (TreeNodeDeclared)node;

                JObject declareJson = new JObject();
                declareJson.Add("objectName", treeNodeDeclared.DeclareObject.declareName);
                declareJson.Add("objectJson", treeNodeDeclared.DeclareObject.declareJsonPath);

                objectContainer.Add(declareJson);
            }

            JObject objectInstance = new JObject();
            instanceObject.Add("objectInstance", objectInstance);

            var instanceNodes = NodeUtil.GetAllNodes(InstanceObjectTreeView.Nodes);
            //获得实例treeview的所有节点

            Dictionary<string, JArray> instanceParentDict = new Dictionary<string, JArray>();
            //所有的声明对象

            foreach (var node in instanceNodes)
            {
                if (!(node is TreeNodeInstanced)) continue;

                TreeNodeInstanced treeNodeInstanced = (TreeNodeInstanced)node;
                GameObject gameObject = treeNodeInstanced.InstanceObject;

                string declareName = gameObject.DeclareObject.declareName;
                if (!instanceParentDict.ContainsKey(declareName))//如果字典里还没有对应的数组
                {

                    instanceParentDict[declareName] = new JArray();
                    objectInstance.Add(declareName, instanceParentDict[declareName]);
                }

                JArray targetInstanceArray = instanceParentDict[declareName];   //即将要插入的Arrays

                JObject instanceJson = new JObject();
                instanceJson.Add("tagName", gameObject.TagName);

                JObject transformJson = BuildTransformJson(gameObject.Transform);  //构建transform
                instanceJson.Add("transform", transformJson);

                targetInstanceArray.Add(instanceJson);  //把instance的json加入array

            }

            string instanceFilePath = assetsPath + "\\assets\\Config\\Instance.json";
            try
            {
                string output = Newtonsoft.Json.JsonConvert.SerializeObject(instanceObject, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(instanceFilePath, output);
            }
            catch(Exception expt) {
                MessageBox.Show(expt.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private JObject BuildTransformJson(Transform transform)
        {
            JObject transformJson = new JObject();

            JArray position = new JArray();
            position.Add(transform.Position.X);
            position.Add(transform.Position.Y);
            position.Add(transform.Position.Z);
            transformJson.Add("position", position);

            JArray rotation = new JArray();
            rotation.Add(transform.Rotation.X);
            rotation.Add(transform.Rotation.Y);
            rotation.Add(transform.Rotation.Z);
            transformJson.Add("rotation", rotation);

            JArray scale = new JArray();
            scale.Add(transform.Scale.X);
            scale.Add(transform.Scale.Y);
            scale.Add(transform.Scale.Z);
            transformJson.Add("scale", scale);

            return transformJson;
        }


    }
}
