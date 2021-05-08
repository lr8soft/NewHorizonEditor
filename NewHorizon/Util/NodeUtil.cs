using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NewHorizon.Util
{
    public class NodeUtil
    {

        public static List<TreeNode> GetAllNodes(TreeNodeCollection treeNodeCollection)
        {
            List<TreeNode> treeNodes = new List<TreeNode>();
            foreach (TreeNode node in treeNodeCollection)
            {
                treeNodes.Add(node);
                treeNodes.AddRange(GetAllNodes(node.Nodes));
            }

            return treeNodes;
        }
    }
}
