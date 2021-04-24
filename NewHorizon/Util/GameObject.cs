using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewHorizon.Util
{
    public class GameObject
    {
        public DeclareObject DeclareObject;
        public string TagName;
        public Transform Transform;

        public GameObject(DeclareObject declareObject, string tagName, Transform transform)
        {
            this.DeclareObject = declareObject;
            this.TagName = tagName;
            this.Transform = transform;
        }
    }
}
