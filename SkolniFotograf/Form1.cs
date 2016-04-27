using SkolniFotograf.Model.Galeries;
using System;
using System.Windows.Forms;
using System.Xml;

namespace SkolniFotograf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Galeries (.xml)|*.xml|All Files (*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                XmlDocument xmlDef = new XmlDocument();
                xmlDef.Load(ofd.FileName);

                Galeries galeries = new Galeries();
                galeries.Load(xmlDef);
            }
        }
    }
}
