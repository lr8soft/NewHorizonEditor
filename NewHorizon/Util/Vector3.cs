using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewHorizon.Util
{
    public class Vector3:ICloneable
    {
        public Vector3(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }


        public Vector3(float v): this(v, v ,v)
        { }

        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public object Clone()
        {
            return new Vector3(X, Y, Z);
        }
    }
}
