using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NewHorizon
{
    public partial class FormMain : Form
    {
        public static string assetsPath = "";

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
                        }


                    }

                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("读取NewHorizon项目失败！\n" + exception.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
