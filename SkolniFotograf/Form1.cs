using SkolniFotograf.Model.Directories;
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
            _photosPaths = new PhotosPaths();
            _photoPathFinder = new PhotoPathFinder(_photosPaths);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Galleries (.xml)|*.xml|All Files (*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                XmlDocument xmlDef = new XmlDocument();
                xmlDef.Load(ofd.FileName);

                _galeriesCollection.Load(xmlDef);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FolderBrowserDialog ofd = new FolderBrowserDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                _photoPathFinder.AddPhotosFromDirectory(ofd.SelectedPath, "*.jpg");
            }
        }

        private readonly GaleriesCollection _galeriesCollection = new GaleriesCollection();
        private readonly PhotosPaths _photosPaths;
        private readonly PhotoPathFinder _photoPathFinder;
    }
}
