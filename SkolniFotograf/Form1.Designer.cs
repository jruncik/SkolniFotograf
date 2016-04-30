namespace SkolniFotograf
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonGaleries = new System.Windows.Forms.Button();
            this.buttonSrcDir = new System.Windows.Forms.Button();
            this.buttonDestdit = new System.Windows.Forms.Button();
            this.textBoxGaleries = new System.Windows.Forms.TextBox();
            this.textBoxDestination = new System.Windows.Forms.TextBox();
            this.textBoxSource = new System.Windows.Forms.TextBox();
            this.buttonProcess = new System.Windows.Forms.Button();
            this.comboBoxGaleries = new System.Windows.Forms.ComboBox();
            this.listBoxOutput = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // buttonGaleries
            // 
            this.buttonGaleries.Location = new System.Drawing.Point(12, 12);
            this.buttonGaleries.Name = "buttonGaleries";
            this.buttonGaleries.Size = new System.Drawing.Size(75, 23);
            this.buttonGaleries.TabIndex = 0;
            this.buttonGaleries.Text = "Galeries";
            this.buttonGaleries.UseVisualStyleBackColor = true;
            this.buttonGaleries.Click += new System.EventHandler(this.buttonGaleriesClick);
            // 
            // buttonSrcDir
            // 
            this.buttonSrcDir.Location = new System.Drawing.Point(12, 41);
            this.buttonSrcDir.Name = "buttonSrcDir";
            this.buttonSrcDir.Size = new System.Drawing.Size(75, 23);
            this.buttonSrcDir.TabIndex = 1;
            this.buttonSrcDir.Text = "Source";
            this.buttonSrcDir.UseVisualStyleBackColor = true;
            this.buttonSrcDir.Click += new System.EventHandler(this.buttonSrcDirClick);
            // 
            // buttonDestdit
            // 
            this.buttonDestdit.Location = new System.Drawing.Point(12, 70);
            this.buttonDestdit.Name = "buttonDestdit";
            this.buttonDestdit.Size = new System.Drawing.Size(75, 23);
            this.buttonDestdit.TabIndex = 2;
            this.buttonDestdit.Text = "Destination";
            this.buttonDestdit.UseVisualStyleBackColor = true;
            this.buttonDestdit.Click += new System.EventHandler(this.buttonDestditClick);
            // 
            // textBoxGaleries
            // 
            this.textBoxGaleries.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxGaleries.Location = new System.Drawing.Point(94, 14);
            this.textBoxGaleries.Name = "textBoxGaleries";
            this.textBoxGaleries.ReadOnly = true;
            this.textBoxGaleries.Size = new System.Drawing.Size(480, 20);
            this.textBoxGaleries.TabIndex = 3;
            // 
            // textBoxDestination
            // 
            this.textBoxDestination.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDestination.Location = new System.Drawing.Point(94, 73);
            this.textBoxDestination.Name = "textBoxDestination";
            this.textBoxDestination.ReadOnly = true;
            this.textBoxDestination.Size = new System.Drawing.Size(480, 20);
            this.textBoxDestination.TabIndex = 4;
            // 
            // textBoxSource
            // 
            this.textBoxSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSource.Location = new System.Drawing.Point(94, 44);
            this.textBoxSource.Name = "textBoxSource";
            this.textBoxSource.ReadOnly = true;
            this.textBoxSource.Size = new System.Drawing.Size(480, 20);
            this.textBoxSource.TabIndex = 5;
            // 
            // buttonProcess
            // 
            this.buttonProcess.Location = new System.Drawing.Point(12, 121);
            this.buttonProcess.Name = "buttonProcess";
            this.buttonProcess.Size = new System.Drawing.Size(75, 23);
            this.buttonProcess.TabIndex = 6;
            this.buttonProcess.Text = "Process";
            this.buttonProcess.UseVisualStyleBackColor = true;
            this.buttonProcess.Click += new System.EventHandler(this.buttonProcessClick);
            // 
            // comboBoxGaleries
            // 
            this.comboBoxGaleries.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxGaleries.FormattingEnabled = true;
            this.comboBoxGaleries.Location = new System.Drawing.Point(93, 121);
            this.comboBoxGaleries.Name = "comboBoxGaleries";
            this.comboBoxGaleries.Size = new System.Drawing.Size(481, 21);
            this.comboBoxGaleries.TabIndex = 7;
            // 
            // listBoxOutput
            // 
            this.listBoxOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxOutput.FormattingEnabled = true;
            this.listBoxOutput.Location = new System.Drawing.Point(12, 163);
            this.listBoxOutput.Name = "listBoxOutput";
            this.listBoxOutput.Size = new System.Drawing.Size(562, 160);
            this.listBoxOutput.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 346);
            this.Controls.Add(this.listBoxOutput);
            this.Controls.Add(this.comboBoxGaleries);
            this.Controls.Add(this.buttonProcess);
            this.Controls.Add(this.textBoxSource);
            this.Controls.Add(this.textBoxDestination);
            this.Controls.Add(this.textBoxGaleries);
            this.Controls.Add(this.buttonDestdit);
            this.Controls.Add(this.buttonSrcDir);
            this.Controls.Add(this.buttonGaleries);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGaleries;
        private System.Windows.Forms.Button buttonSrcDir;
        private System.Windows.Forms.Button buttonDestdit;
        private System.Windows.Forms.TextBox textBoxGaleries;
        private System.Windows.Forms.TextBox textBoxDestination;
        private System.Windows.Forms.TextBox textBoxSource;
        private System.Windows.Forms.Button buttonProcess;
        private System.Windows.Forms.ComboBox comboBoxGaleries;
        private System.Windows.Forms.ListBox listBoxOutput;
    }
}

