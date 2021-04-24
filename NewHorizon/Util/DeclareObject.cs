using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NewHorizon.Util
{
    public class DeclareObject
    {
        public string declareName;
        public string declareJsonPath;

        public string modelName { get; set; }
        public string shaderName { get; set; }
        public string scriptName { get; set; }

        public DeclareObject(string declareName, string jsonPath)
        {
            this.declareName = declareName;
            this.declareJsonPath = jsonPath;

            LoadFromJson();
        }

        public void LoadFromJson()
        {
            string jsonRealPath = FormMain.assetsPath + "\\" +declareJsonPath;
            using (StreamReader streamReader = File.OpenText(jsonRealPath))
            {
                using (JsonTextReader jsonReader = new JsonTextReader(streamReader))
                {
                    JObject jObject = (JObject)JToken.ReadFrom(jsonReader);

                    this.modelName = jObject["model"].ToString();
                    this.shaderName = jObject["shader"].ToString();
                    this.scriptName = jObject["script"].ToString();

                    //MessageBox.Show(this.modelName + " " + this.shaderName + " " + this.scriptName, "");
                }
            }
        }

    }
}
