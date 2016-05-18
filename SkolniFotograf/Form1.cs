using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;

using SkolniFotograf.Core;
using SkolniFotograf.Model;
using SkolniFotograf.Model.Directories;
using SkolniFotograf.Model.Galleries;
using System.IO;

namespace SkolniFotograf
{
    public partial class Form1 : Form, IMessaging
    {
        private readonly GaleriesCollection _galeriesCollection = new GaleriesCollection();
        private readonly PhotoPathFinder _photoPathFinder;
        private readonly PhotosPaths _photosPaths;

        private Settings _settings = new Settings();

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
                _settings.GalleriesPath = ofd.FileName;
                LoadGaleries();
                _settings.Save();
            }
        }

        private void LoadGaleries()
        {
            comboBoxGaleries.Items.Clear();

            try
            {
                textBoxGaleries.Text = _settings.GalleriesPath;
                XmlDocument xmlDef = new XmlDocument();
                xmlDef.Load(_settings.GalleriesPath);

                _galeriesCollection.Load(xmlDef);
            }
            catch (Exception ex)
            {
                AddError(ex.Message);
            }

            FillGalerriesCombobox();
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
                _settings.PhotoSourceDirectory = ofd.SelectedPath;
                LoadSourcePhotos();
                _settings.Save();
            }
        }

        private void LoadSourcePhotos()
        {
            textBoxSource.Text = _settings.PhotoSourceDirectory;
            _photoPathFinder.AddPhotosFromDirectory(_settings.PhotoSourceDirectory, "*.jpg");
        }

        private void buttonDestditClick(object sender, EventArgs e)
        {
            FolderBrowserDialog ofd = new FolderBrowserDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                _settings.PhotoDestinationDirectory = ofd.SelectedPath;
                InitializeDestination();
                _settings.Save();
            }
        }

        private void InitializeDestination()
        {
            textBoxDestination.Text = _settings.PhotoDestinationDirectory;
        }

        private void buttonProcessClick(object sender, EventArgs e)
        {
            ClearMessages();

            Gallery currGallery = ((ComboGaleryItem)comboBoxGaleries.SelectedItem).Gallery;
            AddMessage(String.Format("Star Processing gallery '{0}'", currGallery.Name));
            AddNewLine();

            TargetPhotoGenerator tpg = new TargetPhotoGenerator(currGallery, _settings.PhotoDestinationDirectory, _photosPaths, this);

            tpg.GenerateTargetPhotos();
            EnsureTardetDirectoris(tpg.TargetDirectories);

            foreach (PhotoCopyInfo photoCopyInfo in tpg.PhotoCopyInfos)
            {
                // AddMessage(String.Format("copying photo from '{0}' to '{1}'", photoCopyInfo.SrcFullFileName, photoCopyInfo.DestFullFileName));

                try
                {
                    System.IO.File.Copy(photoCopyInfo.SrcFullFileName, photoCopyInfo.DestFullFileName, true);
                }
                catch (Exception ex)
                {
                    AddError(ex.Message);
                    AddNewLine();
                }
            }

            AddNewLine();
            AddMessage(String.Format("Gallery processed '{0}'", currGallery.Name));
        }

        private void EnsureTardetDirectoris(ICollection<string> targetDirectories)
        {
            foreach (string targetDir in targetDirectories)
            {
                if (Directory.Exists(targetDir))
                {
                    continue;
                }

                Directory.CreateDirectory(targetDir);
            }
        }

        public void AddError(string message)
        {
            listBoxOutput.Items.Add(String.Format("[{0}] Error: '{1}'", DateTime.Now.ToString("HH:mm:ss"), message));
        }

        public void AddMessage(string message)
        {
            listBoxOutput.Items.Add(String.Format("[{0}] - '{1}'", DateTime.Now.ToString("HH:mm:ss"), message));
        }

        public void AddNewLine()
        {
            listBoxOutput.Items.Add(string.Empty);
        }

        public void ClearMessages()
        {
            listBoxOutput.Items.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _settings.Load();

            if (!String.IsNullOrEmpty(_settings.GalleriesPath))
            {
                LoadGaleries();
            }

            if (!String.IsNullOrEmpty(_settings.PhotoSourceDirectory))
            {
                LoadSourcePhotos();
            }

            if (!String.IsNullOrEmpty(_settings.PhotoDestinationDirectory))
            {
                InitializeDestination();
            }
        }
    }
}
