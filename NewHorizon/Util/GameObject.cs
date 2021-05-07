using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewHorizon.Util
{
    public class GameObject: ICloneable
    {
        public DeclareObject DeclareObject { get; set; }
        public string TagName { get; set; }
        public Transform Transform { get; set; }


        public GameObject(DeclareObject declareObject, string tagName, Transform transform)
        {
            this.DeclareObject = declareObject;
            this.TagName = tagName;
            this.Transform = transform;
        }

        public object Clone()
        {
            return new GameObject(DeclareObject, TagName, (Transform)Transform.Clone());
        }
    }
}
