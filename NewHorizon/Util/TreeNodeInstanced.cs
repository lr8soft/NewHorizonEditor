using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NewHorizon.Util
{
    public class TreeNodeInstanced: TreeNode
    {
        private GameObject _gameObject;
        public GameObject InstanceObject
        {
            get
            {
                return _gameObject;
            }
            set
            {
                _gameObject = value;
                this.Text = ToString();
            }
        }


        public override string ToString()
        {
            if (InstanceObject == null)
                return "";
            else
            {
                return InstanceObject.TagName ;
            }
        }

    }
}
