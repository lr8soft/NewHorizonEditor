using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NewHorizon.Util
{
    public class TreeNodeDeclared: TreeNode
    {
        private DeclareObject _declareObject;
        public DeclareObject DeclareObject
        {
            get {
                return _declareObject;
            }
            set
            {
                _declareObject = value;
                this.Text = ToString();
            }
        }



        public override string ToString()
        {
            if (DeclareObject == null)
                return "";
            else {
                return DeclareObject.declareName;
            }
        }

    }
}
