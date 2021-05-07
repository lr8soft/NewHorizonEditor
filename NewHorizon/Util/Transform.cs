using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewHorizon.Util
{
    public class Transform: ICloneable
    {
        public Transform()
        {
            Position = new Vector3(0.0f);
            Rotation = new Vector3(0.0f);
            Scale = new Vector3(0.0f);
        }

        public Vector3 Position { get; set; }
        public Vector3 Rotation { get; set; }
        public Vector3 Scale { get; set; }

        public object Clone()
        {
            Transform transform = new Transform();
            transform.Position = (Vector3)Position.Clone();
            transform.Rotation = (Vector3)Rotation.Clone();
            transform.Scale = (Vector3)Scale.Clone();
            return transform;
        }
    }
}
