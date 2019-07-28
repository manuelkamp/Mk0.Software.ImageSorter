﻿namespace Mk0.Software.ImageSorter
{
    partial class Main
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemCropImage = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemEditImage = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemOpenExplorer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemImageDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.labelQuellPath = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelCounter = new System.Windows.Forms.Label();
            this.labelZielPath = new System.Windows.Forms.Label();
            this.buttonQuellPfad = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonInfo = new System.Windows.Forms.Button();
            this.buttonJumpBack = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelNoTargets = new System.Windows.Forms.Label();
            this.buttonJumpForward = new System.Windows.Forms.Button();
            this.buttonUndo = new System.Windows.Forms.Button();
            this.buttonDeleteImage = new System.Windows.Forms.Button();
            this.buttonRotate90 = new System.Windows.Forms.Button();
            this.buttonRotate180 = new System.Windows.Forms.Button();
            this.buttonRotate270 = new System.Windows.Forms.Button();
            this.buttonMirrorHorizontal = new System.Windows.Forms.Button();
            this.buttonMirrorVertikal = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelNoImages = new System.Windows.Forms.Label();
            this.labelZoom = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.comboBoxZoom = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox.ContextMenuStrip = this.contextMenuStrip;
            this.pictureBox.ImageLocation = "";
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(682, 526);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.LoadCompleted += new System.ComponentModel.AsyncCompletedEventHandler(this.PictureBox_LoadCompleted);
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBox_MouseDown);
            this.pictureBox.MouseEnter += new System.EventHandler(this.PictureBox_MouseEnter);
            this.pictureBox.MouseLeave += new System.EventHandler(this.PictureBox_MouseLeave);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBox_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PictureBox_MouseUp);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemCropImage,
            this.toolStripMenuItemEditImage,
            this.toolStripMenuItemOpenExplorer,
            this.toolStripMenuItemImageDetails});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(196, 92);
            // 
            // toolStripMenuItemCropImage
            // 
            this.toolStripMenuItemCropImage.Name = "toolStripMenuItemCropImage";
            this.toolStripMenuItemCropImage.Size = new System.Drawing.Size(195, 22);
            this.toolStripMenuItemCropImage.Text = "Bild zuschneiden (F2)";
            this.toolStripMenuItemCropImage.Click += new System.EventHandler(this.BildZuschneidenToolStripMenuItem_Click);
            // 
            // toolStripMenuItemEditImage
            // 
            this.toolStripMenuItemEditImage.Name = "toolStripMenuItemEditImage";
            this.toolStripMenuItemEditImage.Size = new System.Drawing.Size(195, 22);
            this.toolStripMenuItemEditImage.Text = "Bild bearbeiten (F3)";
            this.toolStripMenuItemEditImage.Click += new System.EventHandler(this.ToolStripMenuItemEditImage_Click);
            // 
            // toolStripMenuItemOpenExplorer
            // 
            this.toolStripMenuItemOpenExplorer.Name = "toolStripMenuItemOpenExplorer";
            this.toolStripMenuItemOpenExplorer.Size = new System.Drawing.Size(195, 22);
            this.toolStripMenuItemOpenExplorer.Text = "Speicherort öffnen (F4)";
            this.toolStripMenuItemOpenExplorer.Click += new System.EventHandler(this.ToolStripMenuItemOpenExplorer_Click);
            // 
            // toolStripMenuItemImageDetails
            // 
            this.toolStripMenuItemImageDetails.Name = "toolStripMenuItemImageDetails";
            this.toolStripMenuItemImageDetails.Size = new System.Drawing.Size(195, 22);
            this.toolStripMenuItemImageDetails.Text = "Bildeigenschaften (F5)";
            this.toolStripMenuItemImageDetails.Click += new System.EventHandler(this.ToolStripMenuItemImageDetails_Click);
            // 
            // buttonSettings
            // 
            this.buttonSettings.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.buttonSettings.Location = new System.Drawing.Point(233, 16);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(23, 23);
            this.buttonSettings.TabIndex = 1;
            this.buttonSettings.Text = "@";
            this.buttonSettings.UseVisualStyleBackColor = true;
            this.buttonSettings.Click += new System.EventHandler(this.ButtonSettings_Click);
            // 
            // labelQuellPath
            // 
            this.labelQuellPath.AutoSize = true;
            this.labelQuellPath.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelQuellPath.Location = new System.Drawing.Point(6, 45);
            this.labelQuellPath.Name = "labelQuellPath";
            this.labelQuellPath.Size = new System.Drawing.Size(76, 13);
            this.labelQuellPath.TabIndex = 2;
            this.labelQuellPath.Text = "C:/dummypfad";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.labelCounter);
            this.groupBox1.Controls.Add(this.labelQuellPath);
            this.groupBox1.Controls.Add(this.labelZielPath);
            this.groupBox1.Location = new System.Drawing.Point(694, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(262, 81);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informationen";
            // 
            // labelCounter
            // 
            this.labelCounter.AutoSize = true;
            this.labelCounter.ForeColor = System.Drawing.Color.Gray;
            this.labelCounter.Location = new System.Drawing.Point(6, 16);
            this.labelCounter.Name = "labelCounter";
            this.labelCounter.Size = new System.Drawing.Size(94, 13);
            this.labelCounter.TabIndex = 3;
            this.labelCounter.Text = "keine Bildaktionen";
            // 
            // labelZielPath
            // 
            this.labelZielPath.AutoSize = true;
            this.labelZielPath.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelZielPath.Location = new System.Drawing.Point(6, 60);
            this.labelZielPath.Name = "labelZielPath";
            this.labelZielPath.Size = new System.Drawing.Size(168, 13);
            this.labelZielPath.TabIndex = 6;
            this.labelZielPath.Text = "Zielpfad in Einstellungen wählen...";
            // 
            // buttonQuellPfad
            // 
            this.buttonQuellPfad.Font = new System.Drawing.Font("Wingdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.buttonQuellPfad.Location = new System.Drawing.Point(204, 16);
            this.buttonQuellPfad.Name = "buttonQuellPfad";
            this.buttonQuellPfad.Size = new System.Drawing.Size(23, 23);
            this.buttonQuellPfad.TabIndex = 4;
            this.buttonQuellPfad.Text = "1";
            this.buttonQuellPfad.UseVisualStyleBackColor = true;
            this.buttonQuellPfad.Click += new System.EventHandler(this.ButtonQuellPfad_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.buttonInfo);
            this.groupBox2.Controls.Add(this.buttonQuellPfad);
            this.groupBox2.Controls.Add(this.buttonSettings);
            this.groupBox2.Controls.Add(this.buttonJumpBack);
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Controls.Add(this.buttonJumpForward);
            this.groupBox2.Controls.Add(this.buttonUndo);
            this.groupBox2.Location = new System.Drawing.Point(694, 99);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(262, 433);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ziele";
            // 
            // buttonInfo
            // 
            this.buttonInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonInfo.Location = new System.Drawing.Point(175, 16);
            this.buttonInfo.Name = "buttonInfo";
            this.buttonInfo.Size = new System.Drawing.Size(23, 23);
            this.buttonInfo.TabIndex = 8;
            this.buttonInfo.Text = "i";
            this.buttonInfo.UseVisualStyleBackColor = true;
            this.buttonInfo.Click += new System.EventHandler(this.ButtonInfo_Click);
            // 
            // buttonJumpBack
            // 
            this.buttonJumpBack.Enabled = false;
            this.buttonJumpBack.Font = new System.Drawing.Font("Wingdings", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.buttonJumpBack.Location = new System.Drawing.Point(6, 16);
            this.buttonJumpBack.Name = "buttonJumpBack";
            this.buttonJumpBack.Size = new System.Drawing.Size(23, 23);
            this.buttonJumpBack.TabIndex = 7;
            this.buttonJumpBack.Text = "ç";
            this.buttonJumpBack.UseVisualStyleBackColor = true;
            this.buttonJumpBack.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonJumpBack_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.labelNoTargets);
            this.panel2.Location = new System.Drawing.Point(3, 45);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(258, 382);
            this.panel2.TabIndex = 5;
            this.panel2.MouseEnter += new System.EventHandler(this.Panel2_MouseEnter);
            this.panel2.MouseLeave += new System.EventHandler(this.PictureBox_MouseLeave);
            // 
            // labelNoTargets
            // 
            this.labelNoTargets.AutoSize = true;
            this.labelNoTargets.ForeColor = System.Drawing.Color.Maroon;
            this.labelNoTargets.Location = new System.Drawing.Point(19, 10);
            this.labelNoTargets.Name = "labelNoTargets";
            this.labelNoTargets.Size = new System.Drawing.Size(198, 91);
            this.labelNoTargets.TabIndex = 0;
            this.labelNoTargets.Text = "Keine Unterordner im Zielpfad gefunden.\r\n\r\nBilder können nur in Unterordner des\r\n" +
    "Zielpfades verschoben werden.\r\n\r\nWählen Sie einen anderen Zielpfad\r\nin den Einst" +
    "ellungen.";
            // 
            // buttonJumpForward
            // 
            this.buttonJumpForward.Enabled = false;
            this.buttonJumpForward.Font = new System.Drawing.Font("Wingdings", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.buttonJumpForward.Location = new System.Drawing.Point(35, 16);
            this.buttonJumpForward.Name = "buttonJumpForward";
            this.buttonJumpForward.Size = new System.Drawing.Size(23, 23);
            this.buttonJumpForward.TabIndex = 1;
            this.buttonJumpForward.Text = "è";
            this.buttonJumpForward.UseVisualStyleBackColor = true;
            this.buttonJumpForward.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonJumpForward_Click);
            // 
            // buttonUndo
            // 
            this.buttonUndo.Enabled = false;
            this.buttonUndo.Font = new System.Drawing.Font("Wingdings", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.buttonUndo.Location = new System.Drawing.Point(64, 16);
            this.buttonUndo.Name = "buttonUndo";
            this.buttonUndo.Size = new System.Drawing.Size(23, 23);
            this.buttonUndo.TabIndex = 2;
            this.buttonUndo.Text = "Õ";
            this.buttonUndo.UseVisualStyleBackColor = true;
            this.buttonUndo.Click += new System.EventHandler(this.ButtonUndo_Click);
            // 
            // buttonDeleteImage
            // 
            this.buttonDeleteImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonDeleteImage.Location = new System.Drawing.Point(6, 538);
            this.buttonDeleteImage.Name = "buttonDeleteImage";
            this.buttonDeleteImage.Size = new System.Drawing.Size(100, 23);
            this.buttonDeleteImage.TabIndex = 5;
            this.buttonDeleteImage.Text = "Löschen";
            this.buttonDeleteImage.UseVisualStyleBackColor = true;
            this.buttonDeleteImage.Click += new System.EventHandler(this.ImageDelete);
            // 
            // buttonRotate90
            // 
            this.buttonRotate90.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonRotate90.Location = new System.Drawing.Point(121, 538);
            this.buttonRotate90.Name = "buttonRotate90";
            this.buttonRotate90.Size = new System.Drawing.Size(100, 23);
            this.buttonRotate90.TabIndex = 6;
            this.buttonRotate90.Tag = "90";
            this.buttonRotate90.Text = "Drehen 90°";
            this.buttonRotate90.UseVisualStyleBackColor = true;
            this.buttonRotate90.Click += new System.EventHandler(this.ImageRotate);
            // 
            // buttonRotate180
            // 
            this.buttonRotate180.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonRotate180.Location = new System.Drawing.Point(227, 538);
            this.buttonRotate180.Name = "buttonRotate180";
            this.buttonRotate180.Size = new System.Drawing.Size(100, 23);
            this.buttonRotate180.TabIndex = 7;
            this.buttonRotate180.Tag = "180";
            this.buttonRotate180.Text = "Drehen 180°";
            this.buttonRotate180.UseVisualStyleBackColor = true;
            this.buttonRotate180.Click += new System.EventHandler(this.ImageRotate);
            // 
            // buttonRotate270
            // 
            this.buttonRotate270.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonRotate270.Location = new System.Drawing.Point(333, 538);
            this.buttonRotate270.Name = "buttonRotate270";
            this.buttonRotate270.Size = new System.Drawing.Size(100, 23);
            this.buttonRotate270.TabIndex = 8;
            this.buttonRotate270.Tag = "270";
            this.buttonRotate270.Text = "Drehen 270°";
            this.buttonRotate270.UseVisualStyleBackColor = true;
            this.buttonRotate270.Click += new System.EventHandler(this.ImageRotate);
            // 
            // buttonMirrorHorizontal
            // 
            this.buttonMirrorHorizontal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonMirrorHorizontal.Location = new System.Drawing.Point(448, 538);
            this.buttonMirrorHorizontal.Name = "buttonMirrorHorizontal";
            this.buttonMirrorHorizontal.Size = new System.Drawing.Size(100, 23);
            this.buttonMirrorHorizontal.TabIndex = 9;
            this.buttonMirrorHorizontal.Tag = "y";
            this.buttonMirrorHorizontal.Text = "Spiegeln horiz.";
            this.buttonMirrorHorizontal.UseVisualStyleBackColor = true;
            this.buttonMirrorHorizontal.Click += new System.EventHandler(this.ImageMirror);
            // 
            // buttonMirrorVertikal
            // 
            this.buttonMirrorVertikal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonMirrorVertikal.Location = new System.Drawing.Point(554, 538);
            this.buttonMirrorVertikal.Name = "buttonMirrorVertikal";
            this.buttonMirrorVertikal.Size = new System.Drawing.Size(100, 23);
            this.buttonMirrorVertikal.TabIndex = 10;
            this.buttonMirrorVertikal.Tag = "x";
            this.buttonMirrorVertikal.Text = "Spiegeln vertikal";
            this.buttonMirrorVertikal.UseVisualStyleBackColor = true;
            this.buttonMirrorVertikal.Click += new System.EventHandler(this.ImageMirror);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.labelNoImages);
            this.panel1.Controls.Add(this.pictureBox);
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(682, 526);
            this.panel1.TabIndex = 3;
            this.panel1.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.ZoomInOut);
            // 
            // labelNoImages
            // 
            this.labelNoImages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelNoImages.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNoImages.ForeColor = System.Drawing.Color.Maroon;
            this.labelNoImages.Location = new System.Drawing.Point(0, 0);
            this.labelNoImages.Name = "labelNoImages";
            this.labelNoImages.Size = new System.Drawing.Size(682, 526);
            this.labelNoImages.TabIndex = 1;
            this.labelNoImages.Text = "Keine Bilder im aktuellen Pfad vorhanden.\r\nBitte den Pfad ändern, um Bilder zu so" +
    "rtieren.\r\nErlaubte Dateiformate sind (JPG, PNG, GIF, BMP, TIF).";
            this.labelNoImages.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelZoom
            // 
            this.labelZoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelZoom.AutoSize = true;
            this.labelZoom.Location = new System.Drawing.Point(924, 543);
            this.labelZoom.Name = "labelZoom";
            this.labelZoom.Size = new System.Drawing.Size(18, 13);
            this.labelZoom.TabIndex = 13;
            this.labelZoom.Text = "x1";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Location = new System.Drawing.Point(0, -52);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(688, 52);
            this.panel3.TabIndex = 2;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Location = new System.Drawing.Point(634, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(51, 47);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(56, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "\"Pfadangabe\" verschoben.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(57, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bild \"Dateiname\" erfolgreich nach";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 46);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // comboBoxZoom
            // 
            this.comboBoxZoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxZoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxZoom.FormattingEnabled = true;
            this.comboBoxZoom.Items.AddRange(new object[] {
            "Auto",
            "Vollbild",
            "Original"});
            this.comboBoxZoom.Location = new System.Drawing.Point(799, 538);
            this.comboBoxZoom.Name = "comboBoxZoom";
            this.comboBoxZoom.Size = new System.Drawing.Size(121, 21);
            this.comboBoxZoom.TabIndex = 14;
            this.comboBoxZoom.SelectedIndexChanged += new System.EventHandler(this.ComboBoxZoom_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(759, 543);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Zoom";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(967, 566);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxZoom);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.labelZoom);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonMirrorVertikal);
            this.Controls.Add(this.buttonMirrorHorizontal);
            this.Controls.Add(this.buttonRotate270);
            this.Controls.Add(this.buttonRotate180);
            this.Controls.Add(this.buttonRotate90);
            this.Controls.Add(this.buttonDeleteImage);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(983, 605);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Image Sorter v1.32 | © 2015-2019 by manuelkamper.com";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.Shown += new System.EventHandler(this.Main_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Main_KeyDown);
            this.Resize += new System.EventHandler(this.Main_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.Label labelQuellPath;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labelNoTargets;
        private System.Windows.Forms.Button buttonJumpForward;
        private System.Windows.Forms.Label labelCounter;
        private System.Windows.Forms.Button buttonUndo;
        private System.Windows.Forms.Button buttonDeleteImage;
        private System.Windows.Forms.Button buttonRotate90;
        private System.Windows.Forms.Button buttonRotate180;
        private System.Windows.Forms.Button buttonRotate270;
        private System.Windows.Forms.Button buttonMirrorHorizontal;
        private System.Windows.Forms.Button buttonMirrorVertikal;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelZoom;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEditImage;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpenExplorer;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemImageDetails;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelNoImages;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCropImage;
        private System.Windows.Forms.Button buttonQuellPfad;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Label labelZielPath;
        private System.Windows.Forms.ComboBox comboBoxZoom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonJumpBack;
        private System.Windows.Forms.Button buttonInfo;
    }
}
