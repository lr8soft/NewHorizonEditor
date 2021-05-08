using NewHorizon.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NewHorizon
{
    public partial class FormDeclare : Form
    {
        private static string declareFolder = "assets\\Config\\object\\";
        public DialogResult Result { get; set; }
        public DeclareObject DeclareObject { get; set; }



        public FormDeclare(DeclareObject declareObject)
        {
            InitializeComponent();

            DeclareObject = declareObject;
            if (declareObject == null)
            {
                DeclareObject = new DeclareObject("declareObject", declareFolder + "declareObject.json", false);
            }
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {

        }
    }
}
