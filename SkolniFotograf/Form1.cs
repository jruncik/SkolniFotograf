using System;
using System.Windows.Forms;
using System.Xml;

using SkolniFotograf.Model.Directories;
using SkolniFotograf.Model.Galleries;

namespace SkolniFotograf
{
    public partial class Form1 : Form
    {
        private readonly GaleriesCollection _galeriesCollection = new GaleriesCollection();
        private readonly PhotosPaths _photosPaths;
        private readonly PhotoPathFinder _photoPathFinder;

        public Form1()
        {
            InitializeComponent();
            _photosPaths = new PhotosPaths();
            _photoPathFinder = new PhotoPathFinder(_photosPaths);

        }

        private void buttonGaleriesClick(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Galleries (.xml)|*.xml|All Files (*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                comboBoxGaleries.Items.Clear();

                textBoxGaleries.Text = ofd.FileName;
                try
                {
                    XmlDocument xmlDef = new XmlDocument();
                    xmlDef.Load(ofd.FileName);

                    _galeriesCollection.Load(xmlDef);
                }
                catch (Exception ex)
                {
                    AddError(ex.Message);
                }

                FillGalerriesCombobox();
            }
        }

        private void FillGalerriesCombobox()
        {
            foreach (Gallery gallery in _galeriesCollection.Galleries)
            {
                comboBoxGaleries.Items.Add(new ComboGaleryItem(gallery));
            }

            if (comboBoxGaleries.Items.Count > 0)
            {
                comboBoxGaleries.SelectedItem =comboBoxGaleries.Items[0]; 
            }
        }

        private void buttonSrcDirClick(object sender, EventArgs e)
        {
            FolderBrowserDialog ofd = new FolderBrowserDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBoxSource.Text = ofd.SelectedPath;
                _photoPathFinder.AddPhotosFromDirectory(ofd.SelectedPath, "*.jpg");
            }
        }

        private void buttonDestditClick(object sender, EventArgs e)
        {
            FolderBrowserDialog ofd = new FolderBrowserDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBoxDestination.Text = ofd.SelectedPath;
            }
        }

        private void buttonProcessClick(object sender, EventArgs e)
        {
            Gallery currGallery = ((ComboGaleryItem)comboBoxGaleries.SelectedItem).Gallery;
            AddMessage(String.Format("Star Processing gallery '{0}'", currGallery.Name));
            AddMessage(String.Format("Gallery processed '{0}'", currGallery.Name));
        }

        private void AddError(string message)
        {
            listBoxOutput.Items.Add(String.Format("[{0}] Error: '{1}'", DateTime.Now.ToString("HH:mm:ss"), message));
        }

        private void AddMessage(string message)
        {
            listBoxOutput.Items.Add(String.Format("[{0}] - '{1}'", DateTime.Now.ToString("HH:mm:ss"), message));
        }
    }
}
