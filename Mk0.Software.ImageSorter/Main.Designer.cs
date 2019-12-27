namespace Mk0.Software.ImageSorter
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
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemCropImage = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemEditImage = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemOpenExplorer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemImageDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemShowEXIF = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.labelQuellPath = new System.Windows.Forms.Label();
            this.groupBoxInformationen = new System.Windows.Forms.GroupBox();
            this.labelCounter = new System.Windows.Forms.Label();
            this.labelZielPath = new System.Windows.Forms.Label();
            this.buttonQuellPfad = new System.Windows.Forms.Button();
            this.groupBoxZiele = new System.Windows.Forms.GroupBox();
            this.buttonLastImage = new System.Windows.Forms.Button();
            this.buttonInfo = new System.Windows.Forms.Button();
            this.buttonJumpBack = new System.Windows.Forms.Button();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.labelNoTargets = new System.Windows.Forms.Label();
            this.buttonJumpForward = new System.Windows.Forms.Button();
            this.buttonUndo = new System.Windows.Forms.Button();
            this.buttonDeleteImage = new System.Windows.Forms.Button();
            this.buttonRotate90 = new System.Windows.Forms.Button();
            this.buttonRotate180 = new System.Windows.Forms.Button();
            this.buttonRotate270 = new System.Windows.Forms.Button();
            this.buttonMirrorHorizontal = new System.Windows.Forms.Button();
            this.buttonMirrorVertikal = new System.Windows.Forms.Button();
            this.panelImageBackground = new System.Windows.Forms.Panel();
            this.labelNoImages = new System.Windows.Forms.Label();
            this.groupBoxRander = new System.Windows.Forms.GroupBox();
            this.labelRander = new System.Windows.Forms.Label();
            this.trackBarRander = new System.Windows.Forms.TrackBar();
            this.buttonRandLinks = new System.Windows.Forms.Button();
            this.buttonRandRechts = new System.Windows.Forms.Button();
            this.buttonRandUnten = new System.Windows.Forms.Button();
            this.buttonRandOben = new System.Windows.Forms.Button();
            this.labelZoom2 = new System.Windows.Forms.Label();
            this.panelBanner = new System.Windows.Forms.Panel();
            this.pictureBoxBanner2 = new System.Windows.Forms.PictureBox();
            this.labelBanner2 = new System.Windows.Forms.Label();
            this.labelBanner1 = new System.Windows.Forms.Label();
            this.pictureBoxBanner1 = new System.Windows.Forms.PictureBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.comboBoxZoom = new System.Windows.Forms.ComboBox();
            this.labelZoom1 = new System.Windows.Forms.Label();
            this.buttonDuplicate = new System.Windows.Forms.Button();
            this.groupBoxTransformation = new System.Windows.Forms.GroupBox();
            this.buttonTransformation = new System.Windows.Forms.Button();
            this.buttonHintergrund = new System.Windows.Forms.Button();
            this.buttonRander = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.groupBoxInformationen.SuspendLayout();
            this.groupBoxZiele.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.panelImageBackground.SuspendLayout();
            this.groupBoxRander.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRander)).BeginInit();
            this.panelBanner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBanner2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBanner1)).BeginInit();
            this.groupBoxTransformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxImage.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBoxImage.ContextMenuStrip = this.contextMenuStrip;
            this.pictureBoxImage.ImageLocation = "";
            this.pictureBoxImage.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.Size = new System.Drawing.Size(682, 526);
            this.pictureBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxImage.TabIndex = 0;
            this.pictureBoxImage.TabStop = false;
            this.pictureBoxImage.LoadCompleted += new System.ComponentModel.AsyncCompletedEventHandler(this.PictureBox_LoadCompleted);
            this.pictureBoxImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBox_MouseDown);
            this.pictureBoxImage.MouseEnter += new System.EventHandler(this.PictureBox_MouseEnter);
            this.pictureBoxImage.MouseLeave += new System.EventHandler(this.PictureBox_MouseLeave);
            this.pictureBoxImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBox_MouseMove);
            this.pictureBoxImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PictureBox_MouseUp);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemCropImage,
            this.toolStripMenuItemEditImage,
            this.toolStripMenuItemOpenExplorer,
            this.toolStripMenuItemImageDetails,
            this.toolStripMenuItemShowEXIF});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(206, 114);
            // 
            // toolStripMenuItemCropImage
            // 
            this.toolStripMenuItemCropImage.Name = "toolStripMenuItemCropImage";
            this.toolStripMenuItemCropImage.Size = new System.Drawing.Size(205, 22);
            this.toolStripMenuItemCropImage.Text = "Bild zuschneiden (F2)";
            this.toolStripMenuItemCropImage.Click += new System.EventHandler(this.BildZuschneidenToolStripMenuItem_Click);
            // 
            // toolStripMenuItemEditImage
            // 
            this.toolStripMenuItemEditImage.Name = "toolStripMenuItemEditImage";
            this.toolStripMenuItemEditImage.Size = new System.Drawing.Size(205, 22);
            this.toolStripMenuItemEditImage.Text = "Bild bearbeiten (F3)";
            this.toolStripMenuItemEditImage.Click += new System.EventHandler(this.ToolStripMenuItemEditImage_Click);
            // 
            // toolStripMenuItemOpenExplorer
            // 
            this.toolStripMenuItemOpenExplorer.Name = "toolStripMenuItemOpenExplorer";
            this.toolStripMenuItemOpenExplorer.Size = new System.Drawing.Size(205, 22);
            this.toolStripMenuItemOpenExplorer.Text = "Speicherort öffnen (F4)";
            this.toolStripMenuItemOpenExplorer.Click += new System.EventHandler(this.ToolStripMenuItemOpenExplorer_Click);
            // 
            // toolStripMenuItemImageDetails
            // 
            this.toolStripMenuItemImageDetails.Name = "toolStripMenuItemImageDetails";
            this.toolStripMenuItemImageDetails.Size = new System.Drawing.Size(205, 22);
            this.toolStripMenuItemImageDetails.Text = "Bildeigenschaften (F5)";
            this.toolStripMenuItemImageDetails.Click += new System.EventHandler(this.ToolStripMenuItemImageDetails_Click);
            // 
            // toolStripMenuItemShowEXIF
            // 
            this.toolStripMenuItemShowEXIF.Name = "toolStripMenuItemShowEXIF";
            this.toolStripMenuItemShowEXIF.Size = new System.Drawing.Size(205, 22);
            this.toolStripMenuItemShowEXIF.Text = "EXIF-Daten anzeigen (F6)";
            this.toolStripMenuItemShowEXIF.Click += new System.EventHandler(this.ToolStripMenuItemShowEXIF_Click);
            // 
            // buttonSettings
            // 
            this.buttonSettings.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.buttonSettings.Location = new System.Drawing.Point(233, 16);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(23, 23);
            this.buttonSettings.TabIndex = 7;
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
            // groupBoxInformationen
            // 
            this.groupBoxInformationen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxInformationen.Controls.Add(this.labelCounter);
            this.groupBoxInformationen.Controls.Add(this.labelQuellPath);
            this.groupBoxInformationen.Controls.Add(this.labelZielPath);
            this.groupBoxInformationen.Location = new System.Drawing.Point(694, 12);
            this.groupBoxInformationen.Name = "groupBoxInformationen";
            this.groupBoxInformationen.Size = new System.Drawing.Size(262, 81);
            this.groupBoxInformationen.TabIndex = 3;
            this.groupBoxInformationen.TabStop = false;
            this.groupBoxInformationen.Text = "Informationen";
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
            this.buttonQuellPfad.TabIndex = 6;
            this.buttonQuellPfad.Text = "1";
            this.buttonQuellPfad.UseVisualStyleBackColor = true;
            this.buttonQuellPfad.Click += new System.EventHandler(this.ButtonQuellPfad_Click);
            // 
            // groupBoxZiele
            // 
            this.groupBoxZiele.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxZiele.Controls.Add(this.buttonLastImage);
            this.groupBoxZiele.Controls.Add(this.buttonInfo);
            this.groupBoxZiele.Controls.Add(this.buttonQuellPfad);
            this.groupBoxZiele.Controls.Add(this.buttonSettings);
            this.groupBoxZiele.Controls.Add(this.buttonJumpBack);
            this.groupBoxZiele.Controls.Add(this.panelButtons);
            this.groupBoxZiele.Controls.Add(this.buttonJumpForward);
            this.groupBoxZiele.Controls.Add(this.buttonUndo);
            this.groupBoxZiele.Location = new System.Drawing.Point(694, 99);
            this.groupBoxZiele.Name = "groupBoxZiele";
            this.groupBoxZiele.Size = new System.Drawing.Size(262, 433);
            this.groupBoxZiele.TabIndex = 4;
            this.groupBoxZiele.TabStop = false;
            this.groupBoxZiele.Text = "Ziele";
            // 
            // buttonLastImage
            // 
            this.buttonLastImage.Font = new System.Drawing.Font("Wingdings", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.buttonLastImage.Location = new System.Drawing.Point(105, 16);
            this.buttonLastImage.Name = "buttonLastImage";
            this.buttonLastImage.Size = new System.Drawing.Size(23, 23);
            this.buttonLastImage.TabIndex = 4;
            this.buttonLastImage.Text = "I";
            this.buttonLastImage.UseVisualStyleBackColor = true;
            this.buttonLastImage.Visible = false;
            this.buttonLastImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonLastImage_MouseDown);
            this.buttonLastImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonLastImage_MouseUp);
            // 
            // buttonInfo
            // 
            this.buttonInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonInfo.Location = new System.Drawing.Point(175, 16);
            this.buttonInfo.Name = "buttonInfo";
            this.buttonInfo.Size = new System.Drawing.Size(23, 23);
            this.buttonInfo.TabIndex = 5;
            this.buttonInfo.Text = "i";
            this.buttonInfo.UseVisualStyleBackColor = true;
            this.buttonInfo.Click += new System.EventHandler(this.ButtonInfo_Click);
            // 
            // buttonJumpBack
            // 
            this.buttonJumpBack.Font = new System.Drawing.Font("Wingdings", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.buttonJumpBack.Location = new System.Drawing.Point(6, 16);
            this.buttonJumpBack.Name = "buttonJumpBack";
            this.buttonJumpBack.Size = new System.Drawing.Size(23, 23);
            this.buttonJumpBack.TabIndex = 1;
            this.buttonJumpBack.Text = "ç";
            this.buttonJumpBack.UseVisualStyleBackColor = true;
            this.buttonJumpBack.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonJumpBack_Click);
            // 
            // panelButtons
            // 
            this.panelButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelButtons.AutoScroll = true;
            this.panelButtons.Controls.Add(this.labelNoTargets);
            this.panelButtons.Location = new System.Drawing.Point(3, 45);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(258, 382);
            this.panelButtons.TabIndex = 5;
            this.panelButtons.MouseEnter += new System.EventHandler(this.Panel2_MouseEnter);
            this.panelButtons.MouseLeave += new System.EventHandler(this.PictureBox_MouseLeave);
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
            this.buttonJumpForward.TabIndex = 2;
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
            this.buttonUndo.TabIndex = 3;
            this.buttonUndo.Text = "Õ";
            this.buttonUndo.UseVisualStyleBackColor = true;
            this.buttonUndo.Click += new System.EventHandler(this.ButtonUndo_Click);
            // 
            // buttonDeleteImage
            // 
            this.buttonDeleteImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonDeleteImage.Location = new System.Drawing.Point(6, 538);
            this.buttonDeleteImage.Name = "buttonDeleteImage";
            this.buttonDeleteImage.Size = new System.Drawing.Size(95, 23);
            this.buttonDeleteImage.TabIndex = 10;
            this.buttonDeleteImage.Text = "Löschen";
            this.buttonDeleteImage.UseVisualStyleBackColor = true;
            this.buttonDeleteImage.Click += new System.EventHandler(this.ImageDelete);
            // 
            // buttonRotate90
            // 
            this.buttonRotate90.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonRotate90.Location = new System.Drawing.Point(6, 20);
            this.buttonRotate90.Name = "buttonRotate90";
            this.buttonRotate90.Size = new System.Drawing.Size(95, 23);
            this.buttonRotate90.TabIndex = 6;
            this.buttonRotate90.Tag = "90";
            this.buttonRotate90.Text = "Drehen 90°";
            this.buttonRotate90.UseVisualStyleBackColor = true;
            this.buttonRotate90.Click += new System.EventHandler(this.ImageRotate);
            // 
            // buttonRotate180
            // 
            this.buttonRotate180.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonRotate180.Location = new System.Drawing.Point(6, 49);
            this.buttonRotate180.Name = "buttonRotate180";
            this.buttonRotate180.Size = new System.Drawing.Size(95, 23);
            this.buttonRotate180.TabIndex = 7;
            this.buttonRotate180.Tag = "180";
            this.buttonRotate180.Text = "Drehen 180°";
            this.buttonRotate180.UseVisualStyleBackColor = true;
            this.buttonRotate180.Click += new System.EventHandler(this.ImageRotate);
            // 
            // buttonRotate270
            // 
            this.buttonRotate270.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonRotate270.Location = new System.Drawing.Point(6, 78);
            this.buttonRotate270.Name = "buttonRotate270";
            this.buttonRotate270.Size = new System.Drawing.Size(95, 23);
            this.buttonRotate270.TabIndex = 8;
            this.buttonRotate270.Tag = "270";
            this.buttonRotate270.Text = "Drehen 270°";
            this.buttonRotate270.UseVisualStyleBackColor = true;
            this.buttonRotate270.Click += new System.EventHandler(this.ImageRotate);
            // 
            // buttonMirrorHorizontal
            // 
            this.buttonMirrorHorizontal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonMirrorHorizontal.Location = new System.Drawing.Point(6, 112);
            this.buttonMirrorHorizontal.Name = "buttonMirrorHorizontal";
            this.buttonMirrorHorizontal.Size = new System.Drawing.Size(95, 23);
            this.buttonMirrorHorizontal.TabIndex = 9;
            this.buttonMirrorHorizontal.Tag = "y";
            this.buttonMirrorHorizontal.Text = "Spiegeln horiz.";
            this.buttonMirrorHorizontal.UseVisualStyleBackColor = true;
            this.buttonMirrorHorizontal.Click += new System.EventHandler(this.ImageMirror);
            // 
            // buttonMirrorVertikal
            // 
            this.buttonMirrorVertikal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonMirrorVertikal.Location = new System.Drawing.Point(6, 141);
            this.buttonMirrorVertikal.Name = "buttonMirrorVertikal";
            this.buttonMirrorVertikal.Size = new System.Drawing.Size(95, 23);
            this.buttonMirrorVertikal.TabIndex = 10;
            this.buttonMirrorVertikal.Tag = "x";
            this.buttonMirrorVertikal.Text = "Spiegeln vertikal";
            this.buttonMirrorVertikal.UseVisualStyleBackColor = true;
            this.buttonMirrorVertikal.Click += new System.EventHandler(this.ImageMirror);
            // 
            // panelImageBackground
            // 
            this.panelImageBackground.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelImageBackground.BackColor = System.Drawing.SystemColors.Control;
            this.panelImageBackground.Controls.Add(this.labelNoImages);
            this.panelImageBackground.Controls.Add(this.pictureBoxImage);
            this.panelImageBackground.Location = new System.Drawing.Point(6, 6);
            this.panelImageBackground.Name = "panelImageBackground";
            this.panelImageBackground.Size = new System.Drawing.Size(682, 526);
            this.panelImageBackground.TabIndex = 3;
            this.panelImageBackground.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.ZoomInOut);
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
            this.labelNoImages.Text = "Keine Bilder im aktuellen Pfad vorhanden.\r\nBitte den Quellpfad ändern, um Bilder " +
    "zu sortieren.\r\nErlaubte Dateiformate sind (JPG, PNG, GIF, BMP, TIF).";
            this.labelNoImages.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBoxRander
            // 
            this.groupBoxRander.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxRander.Controls.Add(this.labelRander);
            this.groupBoxRander.Controls.Add(this.trackBarRander);
            this.groupBoxRander.Controls.Add(this.buttonRandLinks);
            this.groupBoxRander.Controls.Add(this.buttonRandRechts);
            this.groupBoxRander.Controls.Add(this.buttonRandUnten);
            this.groupBoxRander.Controls.Add(this.buttonRandOben);
            this.groupBoxRander.Location = new System.Drawing.Point(428, 347);
            this.groupBoxRander.Name = "groupBoxRander";
            this.groupBoxRander.Size = new System.Drawing.Size(109, 186);
            this.groupBoxRander.TabIndex = 18;
            this.groupBoxRander.TabStop = false;
            this.groupBoxRander.Text = "Ränder schneiden";
            this.groupBoxRander.Visible = false;
            // 
            // labelRander
            // 
            this.labelRander.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelRander.AutoSize = true;
            this.labelRander.Location = new System.Drawing.Point(6, 52);
            this.labelRander.Name = "labelRander";
            this.labelRander.Size = new System.Drawing.Size(30, 13);
            this.labelRander.TabIndex = 12;
            this.labelRander.Text = "1 px.";
            // 
            // trackBarRander
            // 
            this.trackBarRander.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.trackBarRander.LargeChange = 1;
            this.trackBarRander.Location = new System.Drawing.Point(6, 18);
            this.trackBarRander.Minimum = 1;
            this.trackBarRander.Name = "trackBarRander";
            this.trackBarRander.Size = new System.Drawing.Size(95, 45);
            this.trackBarRander.TabIndex = 13;
            this.trackBarRander.Value = 1;
            this.trackBarRander.Scroll += new System.EventHandler(this.TrackBarRander_Scroll);
            // 
            // buttonRandLinks
            // 
            this.buttonRandLinks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonRandLinks.Location = new System.Drawing.Point(6, 69);
            this.buttonRandLinks.Name = "buttonRandLinks";
            this.buttonRandLinks.Size = new System.Drawing.Size(95, 23);
            this.buttonRandLinks.TabIndex = 7;
            this.buttonRandLinks.Tag = "links";
            this.buttonRandLinks.Text = "links";
            this.buttonRandLinks.UseVisualStyleBackColor = true;
            this.buttonRandLinks.Click += new System.EventHandler(this.RandSchneiden_Click);
            // 
            // buttonRandRechts
            // 
            this.buttonRandRechts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonRandRechts.Location = new System.Drawing.Point(6, 98);
            this.buttonRandRechts.Name = "buttonRandRechts";
            this.buttonRandRechts.Size = new System.Drawing.Size(95, 23);
            this.buttonRandRechts.TabIndex = 8;
            this.buttonRandRechts.Tag = "rechts";
            this.buttonRandRechts.Text = "rechts";
            this.buttonRandRechts.UseVisualStyleBackColor = true;
            this.buttonRandRechts.Click += new System.EventHandler(this.RandSchneiden_Click);
            // 
            // buttonRandUnten
            // 
            this.buttonRandUnten.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonRandUnten.Location = new System.Drawing.Point(6, 156);
            this.buttonRandUnten.Name = "buttonRandUnten";
            this.buttonRandUnten.Size = new System.Drawing.Size(95, 23);
            this.buttonRandUnten.TabIndex = 10;
            this.buttonRandUnten.Tag = "unten";
            this.buttonRandUnten.Text = "unten";
            this.buttonRandUnten.UseVisualStyleBackColor = true;
            this.buttonRandUnten.Click += new System.EventHandler(this.RandSchneiden_Click);
            // 
            // buttonRandOben
            // 
            this.buttonRandOben.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonRandOben.Location = new System.Drawing.Point(6, 127);
            this.buttonRandOben.Name = "buttonRandOben";
            this.buttonRandOben.Size = new System.Drawing.Size(95, 23);
            this.buttonRandOben.TabIndex = 9;
            this.buttonRandOben.Tag = "oben";
            this.buttonRandOben.Text = "oben";
            this.buttonRandOben.UseVisualStyleBackColor = true;
            this.buttonRandOben.Click += new System.EventHandler(this.RandSchneiden_Click);
            // 
            // labelZoom2
            // 
            this.labelZoom2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelZoom2.AutoSize = true;
            this.labelZoom2.Location = new System.Drawing.Point(924, 543);
            this.labelZoom2.Name = "labelZoom2";
            this.labelZoom2.Size = new System.Drawing.Size(18, 13);
            this.labelZoom2.TabIndex = 13;
            this.labelZoom2.Text = "x1";
            // 
            // panelBanner
            // 
            this.panelBanner.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBanner.BackColor = System.Drawing.SystemColors.Highlight;
            this.panelBanner.Controls.Add(this.pictureBoxBanner2);
            this.panelBanner.Controls.Add(this.labelBanner2);
            this.panelBanner.Controls.Add(this.labelBanner1);
            this.panelBanner.Controls.Add(this.pictureBoxBanner1);
            this.panelBanner.Location = new System.Drawing.Point(0, -52);
            this.panelBanner.Name = "panelBanner";
            this.panelBanner.Size = new System.Drawing.Size(688, 52);
            this.panelBanner.TabIndex = 2;
            // 
            // pictureBoxBanner2
            // 
            this.pictureBoxBanner2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxBanner2.Location = new System.Drawing.Point(634, 3);
            this.pictureBoxBanner2.Name = "pictureBoxBanner2";
            this.pictureBoxBanner2.Size = new System.Drawing.Size(51, 47);
            this.pictureBoxBanner2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxBanner2.TabIndex = 3;
            this.pictureBoxBanner2.TabStop = false;
            // 
            // labelBanner2
            // 
            this.labelBanner2.AutoSize = true;
            this.labelBanner2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBanner2.Location = new System.Drawing.Point(56, 27);
            this.labelBanner2.Name = "labelBanner2";
            this.labelBanner2.Size = new System.Drawing.Size(194, 16);
            this.labelBanner2.TabIndex = 2;
            this.labelBanner2.Text = "\"Pfadangabe\" verschoben.";
            // 
            // labelBanner1
            // 
            this.labelBanner1.AutoSize = true;
            this.labelBanner1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBanner1.Location = new System.Drawing.Point(57, 7);
            this.labelBanner1.Name = "labelBanner1";
            this.labelBanner1.Size = new System.Drawing.Size(241, 16);
            this.labelBanner1.TabIndex = 1;
            this.labelBanner1.Text = "Bild \"Dateiname\" erfolgreich nach";
            // 
            // pictureBoxBanner1
            // 
            this.pictureBoxBanner1.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxBanner1.Name = "pictureBoxBanner1";
            this.pictureBoxBanner1.Size = new System.Drawing.Size(48, 46);
            this.pictureBoxBanner1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxBanner1.TabIndex = 0;
            this.pictureBoxBanner1.TabStop = false;
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
            // labelZoom1
            // 
            this.labelZoom1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelZoom1.AutoSize = true;
            this.labelZoom1.Location = new System.Drawing.Point(759, 543);
            this.labelZoom1.Name = "labelZoom1";
            this.labelZoom1.Size = new System.Drawing.Size(34, 13);
            this.labelZoom1.TabIndex = 15;
            this.labelZoom1.Text = "Zoom";
            // 
            // buttonDuplicate
            // 
            this.buttonDuplicate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonDuplicate.Location = new System.Drawing.Point(220, 538);
            this.buttonDuplicate.Name = "buttonDuplicate";
            this.buttonDuplicate.Size = new System.Drawing.Size(95, 23);
            this.buttonDuplicate.TabIndex = 12;
            this.buttonDuplicate.Tag = "";
            this.buttonDuplicate.Text = "Duplizieren";
            this.buttonDuplicate.UseVisualStyleBackColor = true;
            this.buttonDuplicate.Click += new System.EventHandler(this.ButtonDuplicate_Click);
            // 
            // groupBoxTransformation
            // 
            this.groupBoxTransformation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxTransformation.Controls.Add(this.buttonRotate90);
            this.groupBoxTransformation.Controls.Add(this.buttonRotate180);
            this.groupBoxTransformation.Controls.Add(this.buttonRotate270);
            this.groupBoxTransformation.Controls.Add(this.buttonMirrorVertikal);
            this.groupBoxTransformation.Controls.Add(this.buttonMirrorHorizontal);
            this.groupBoxTransformation.Location = new System.Drawing.Point(108, 362);
            this.groupBoxTransformation.Name = "groupBoxTransformation";
            this.groupBoxTransformation.Size = new System.Drawing.Size(109, 171);
            this.groupBoxTransformation.TabIndex = 17;
            this.groupBoxTransformation.TabStop = false;
            this.groupBoxTransformation.Text = "Transformation";
            this.groupBoxTransformation.Visible = false;
            // 
            // buttonTransformation
            // 
            this.buttonTransformation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonTransformation.Location = new System.Drawing.Point(113, 538);
            this.buttonTransformation.Name = "buttonTransformation";
            this.buttonTransformation.Size = new System.Drawing.Size(95, 23);
            this.buttonTransformation.TabIndex = 11;
            this.buttonTransformation.Tag = "";
            this.buttonTransformation.Text = "Transformation";
            this.buttonTransformation.UseVisualStyleBackColor = true;
            this.buttonTransformation.Click += new System.EventHandler(this.ButtonTransformation_Click);
            // 
            // buttonHintergrund
            // 
            this.buttonHintergrund.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonHintergrund.Location = new System.Drawing.Point(327, 538);
            this.buttonHintergrund.Name = "buttonHintergrund";
            this.buttonHintergrund.Size = new System.Drawing.Size(95, 23);
            this.buttonHintergrund.TabIndex = 13;
            this.buttonHintergrund.Tag = "";
            this.buttonHintergrund.Text = "hell/dunkel";
            this.buttonHintergrund.UseVisualStyleBackColor = true;
            this.buttonHintergrund.Click += new System.EventHandler(this.ButtonHintergrund_Click);
            // 
            // buttonRander
            // 
            this.buttonRander.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonRander.Location = new System.Drawing.Point(434, 538);
            this.buttonRander.Name = "buttonRander";
            this.buttonRander.Size = new System.Drawing.Size(95, 23);
            this.buttonRander.TabIndex = 14;
            this.buttonRander.Tag = "";
            this.buttonRander.Text = "Ränder";
            this.buttonRander.UseVisualStyleBackColor = true;
            this.buttonRander.Click += new System.EventHandler(this.ButtonRander_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(967, 566);
            this.Controls.Add(this.buttonHintergrund);
            this.Controls.Add(this.buttonTransformation);
            this.Controls.Add(this.groupBoxTransformation);
            this.Controls.Add(this.groupBoxRander);
            this.Controls.Add(this.buttonDuplicate);
            this.Controls.Add(this.labelZoom1);
            this.Controls.Add(this.comboBoxZoom);
            this.Controls.Add(this.panelBanner);
            this.Controls.Add(this.labelZoom2);
            this.Controls.Add(this.panelImageBackground);
            this.Controls.Add(this.buttonDeleteImage);
            this.Controls.Add(this.groupBoxZiele);
            this.Controls.Add(this.groupBoxInformationen);
            this.Controls.Add(this.buttonRander);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(983, 605);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Image Sorter v1.43 | © 2015-2020 by mk0.at";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.Shown += new System.EventHandler(this.Main_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Main_KeyDown);
            this.Resize += new System.EventHandler(this.Main_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.groupBoxInformationen.ResumeLayout(false);
            this.groupBoxInformationen.PerformLayout();
            this.groupBoxZiele.ResumeLayout(false);
            this.panelButtons.ResumeLayout(false);
            this.panelButtons.PerformLayout();
            this.panelImageBackground.ResumeLayout(false);
            this.groupBoxRander.ResumeLayout(false);
            this.groupBoxRander.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRander)).EndInit();
            this.panelBanner.ResumeLayout(false);
            this.panelBanner.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBanner2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBanner1)).EndInit();
            this.groupBoxTransformation.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxImage;
        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.Label labelQuellPath;
        private System.Windows.Forms.GroupBox groupBoxInformationen;
        private System.Windows.Forms.GroupBox groupBoxZiele;
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
        private System.Windows.Forms.Panel panelImageBackground;
        private System.Windows.Forms.Label labelZoom2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEditImage;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpenExplorer;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemImageDetails;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Label labelNoImages;
        private System.Windows.Forms.Panel panelBanner;
        private System.Windows.Forms.Label labelBanner2;
        private System.Windows.Forms.Label labelBanner1;
        private System.Windows.Forms.PictureBox pictureBoxBanner1;
        private System.Windows.Forms.PictureBox pictureBoxBanner2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCropImage;
        private System.Windows.Forms.Button buttonQuellPfad;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Label labelZielPath;
        private System.Windows.Forms.ComboBox comboBoxZoom;
        private System.Windows.Forms.Label labelZoom1;
        private System.Windows.Forms.Button buttonJumpBack;
        private System.Windows.Forms.Button buttonInfo;
        private System.Windows.Forms.Button buttonLastImage;
        private System.Windows.Forms.Button buttonDuplicate;
        private System.Windows.Forms.GroupBox groupBoxTransformation;
        private System.Windows.Forms.Button buttonTransformation;
        private System.Windows.Forms.Button buttonHintergrund;
        private System.Windows.Forms.Button buttonRander;
        private System.Windows.Forms.GroupBox groupBoxRander;
        private System.Windows.Forms.Label labelRander;
        private System.Windows.Forms.Button buttonRandLinks;
        private System.Windows.Forms.Button buttonRandRechts;
        private System.Windows.Forms.Button buttonRandUnten;
        private System.Windows.Forms.Button buttonRandOben;
        private System.Windows.Forms.TrackBar trackBarRander;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemShowEXIF;
    }
}
