using Microsoft.VisualBasic.FileIO;
using Mk0.GUI.Banner;
using Mk0.Software.ImageSorter.Properties;
using Mk0.Tools.Calculation;
using Mk0.Tools.FileAssociaton;
using Mk0.Tools.Images;
using Mk0.Tools.Randomization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Mk0.Software.OnlineUpdater;

namespace Mk0.Software.ImageSorter
{
    public partial class Main : Form
    {
        public string quellPath = "";
        public string zielPath = "";
        private string[] fileTypes = { "jpg", "png", "jpeg", "gif", "tif", "tiff", "bmp" };
        private int moved = 0;
        private int imageIndex;
        private List<Button> buttons = new List<Button>();
        private List<string> images = new List<string>();
        private List<string> history = new List<string>();
        private bool moving;
        private bool moveable = false;
        private Point startLocation; //verschieben
        private Cursor grabCursor = new Cursor(new MemoryStream(Resources.grab));
        private Cursor grabbingCursor = new Cursor(new MemoryStream(Resources.grabbing));
        private double xFaktor = 0.0;
        private double yFaktor = 0.0;
        private static object locker = new object();
        private Thread folderThread;
        private bool threadIsRunning = false;
        private Banner banner;
        private string startuppath;
        private string startupimage;
        public string[] Args;
        private System.Timers.Timer t1 = new System.Timers.Timer(1200);
        private FormWindowState lastState = FormWindowState.Minimized;
        private string defaultWindowName;

        public Main()
        {
            InitializeComponent();
            defaultWindowName = Text;
            banner = new Banner(components, panelBanner, pictureBoxBanner1, pictureBoxBanner2, labelBanner1, labelBanner2);
            pictureBoxImage.Cursor = grabCursor;
            DoubleBuffered = true;
            SetDefaultPath();
            comboBoxZoom.SelectedIndex = Properties.Settings.Default.zoom;

            //file assoc prüfen und in einstellungen richtig setzen
            if(FileAssociation.Check("Image_Sorter_JPG", Application.ExecutablePath, "JPG Bild", $@"{Application.StartupPath}\AssocIcons\jpg.ico") && 
                FileAssociation.Check("Image_Sorter_PNG", Application.ExecutablePath, "PNG Bild", $@"{Application.StartupPath}\AssocIcons\png.ico") &&
                FileAssociation.Check("Image_Sorter_GIF", Application.ExecutablePath, "GIF Bild", $@"{Application.StartupPath}\AssocIcons\gif.ico") &&
                FileAssociation.Check("Image_Sorter_JPEG", Application.ExecutablePath, "JPEG Bild", $@"{Application.StartupPath}\AssocIcons\jpeg.ico") &&
                FileAssociation.Check("Image_Sorter_BMP", Application.ExecutablePath, "BMP Bild", $@"{Application.StartupPath}\AssocIcons\bmp.ico") &&
                FileAssociation.Check("Image_Sorter_TIF", Application.ExecutablePath, "TIF Bild", $@"{Application.StartupPath}\AssocIcons\tif.ico") &&
                FileAssociation.Check("Image_Sorter_TIFF", Application.ExecutablePath, "TIFF Bild", $@"{Application.StartupPath}\AssocIcons\tiff.ico"))
            {
                Properties.Settings.Default.fileAssociation = true;
            }
            else
            {
                Properties.Settings.Default.fileAssociation = false;
            }
            Properties.Settings.Default.Save();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            if (Args != null)
            {
                ProcessParameters(null, Args);
                Args = null;
            }
            
            AutoUpdater.ShowSkipButton = false;
            AutoUpdater.Start("https://www.kmpr.at/update/imagesorter.xml");
        }

        public delegate void ProcessParametersDelegate(object sender, string[] args);
        public void ProcessParameters(object sender, string[] args)
        {
            if (args != null && args.Length != 0)
            {
                if (!string.IsNullOrEmpty(args[0]) && File.Exists(args[0]))
                {
                    startuppath = Path.GetDirectoryName(args[0]);
                    startupimage = Path.GetFileName(args[0]);
                    if (!string.IsNullOrEmpty(startuppath) && File.Exists(startuppath))
                    {
                        startuppath = Path.GetDirectoryName(startuppath);
                        startupimage = Path.GetFileName(startuppath);
                    }
                    SetDefaultPath();
                    SearchImages();
                    CountPicsInPath();
                    LoadPicture(GetImageIndex(Path.Combine(startuppath, startupimage)));
                    if (WindowState != FormWindowState.Normal || WindowState != FormWindowState.Maximized)
                    {
                        if (lastState != FormWindowState.Minimized) { WindowState = lastState; } else { WindowState = FormWindowState.Normal; }
                    }
                    Activate();
                    BringToFront();
                    TopMost = true;
                    TopMost = false;
                }
            }
        }

        /// <summary>
        /// Extrahiert die Icons für die Fileassociation
        /// </summary>
        private void ExtractAssocIcons()
        {
            Directory.CreateDirectory($@"{Application.StartupPath}\AssocIcons");
            WriteResource($@"{Application.StartupPath}\AssocIcons\jpg.ico", Resources.jpg);
            WriteResource($@"{Application.StartupPath}\AssocIcons\png.ico", Resources.png);
            WriteResource($@"{Application.StartupPath}\AssocIcons\gif.ico", Resources.gif);
            WriteResource($@"{Application.StartupPath}\AssocIcons\jpeg.ico", Resources.jpeg);
            WriteResource($@"{Application.StartupPath}\AssocIcons\bmp.ico", Resources.bmp);
            WriteResource($@"{Application.StartupPath}\AssocIcons\tif.ico", Resources.tif);
            WriteResource($@"{Application.StartupPath}\AssocIcons\tiff.ico", Resources.tiff);
        }

        /// <summary>
        /// Helfer um Resources auf die Platte zu schreiben
        /// </summary>
        /// <param name="path">Zielpfad</param>
        /// <param name="icon">Resource</param>
        private void WriteResource(string path, Icon icon)
        {
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                icon.Save(fileStream);
            }
        }

        /// <summary>
        /// Default: Lädt das erste Bild
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_Shown(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.fullScreen)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                if (Properties.Settings.Default.lastHeight >= MinimumSize.Height)
                {
                    Height = Properties.Settings.Default.lastHeight;
                }
                if (Properties.Settings.Default.lastWidth >= MinimumSize.Width)
                {
                    Width = Properties.Settings.Default.lastWidth;
                }
                if (Properties.Settings.Default.lastTop <= Screen.PrimaryScreen.Bounds.Height && Properties.Settings.Default.lastTop >= 0)
                {
                    Top = Properties.Settings.Default.lastTop;
                }
                if (Properties.Settings.Default.lastLeft <= Screen.PrimaryScreen.Bounds.Width && Properties.Settings.Default.lastLeft >= 0)
                {
                    Left = Properties.Settings.Default.lastLeft;
                }
            }
            groupBoxInformationen.Visible = Properties.Settings.Default.showInfo;
            if (!groupBoxInformationen.Visible)
            {
                groupBoxZiele.Location = new Point(groupBoxZiele.Location.X, 12);
                groupBoxZiele.Height = groupBoxZiele.Height + 87;
            }
            CheckSubfolders();
            SearchImages();
            CountPicsInPath();
            if (string.IsNullOrEmpty(startupimage))
            {
                LoadPicture(0);
            }
            else
            {
                LoadPicture(GetImageIndex(Path.Combine(startuppath, startupimage)));
            }
            ResetUndo();
            ToolTip t1 = new ToolTip
            {
                AutoPopDelay = 5000,
                InitialDelay = 1000,
                ReshowDelay = 500
            };
            t1.SetToolTip(buttonJumpBack, "Voriges Bild");
            ToolTip t2 = new ToolTip
            {
                AutoPopDelay = 5000,
                InitialDelay = 1000,
                ReshowDelay = 500
            };
            t2.SetToolTip(buttonJumpForward, "Nächstes Bild");
            ToolTip t3 = new ToolTip
            {
                AutoPopDelay = 5000,
                InitialDelay = 1000,
                ReshowDelay = 500
            };
            t3.SetToolTip(buttonUndo, "Aktion Rückgängig machen");
            ToolTip t4 = new ToolTip
            {
                AutoPopDelay = 5000,
                InitialDelay = 1000,
                ReshowDelay = 500
            };
            t4.SetToolTip(buttonSettings, "Einstellungen öffnen");
            ToolTip t5 = new ToolTip
            {
                AutoPopDelay = 5000,
                InitialDelay = 1000,
                ReshowDelay = 500
            };
            t5.SetToolTip(buttonQuellPfad, "Quellpfad festlegen");
            ToolTip t6 = new ToolTip
            {
                AutoPopDelay = 5000,
                InitialDelay = 1000,
                ReshowDelay = 500
            };
            t6.SetToolTip(buttonInfo, "Informationen ein-/ausblenden");
            ToolTip t7 = new ToolTip
            {
                AutoPopDelay = 5000,
                InitialDelay = 1000,
                ReshowDelay = 500
            };
            t7.SetToolTip(buttonLastImage, "Letztes Bild anzeigen");
        }

        /// <summary>
        /// Startpfad auf letzten Pfad legen, wenn Bilder vorhanden sind, sonst auf Bild-Bibliothek, wenn da auch keine sind, dann den Applikationspfad
        /// </summary>
        private void SetDefaultPath()
        {
            string tmpPath = Application.StartupPath;

            if (string.IsNullOrEmpty(startuppath))
            {
                if (!string.IsNullOrEmpty(Properties.Settings.Default.lastPath) && Directory.Exists(Properties.Settings.Default.lastPath))
                {
                    tmpPath = Properties.Settings.Default.lastPath;
                }

                int picsHere = 0;
                foreach (string type in fileTypes)
                {
                    var list = Directory.GetFiles(tmpPath, "*." + type);
                    if (list.Length > 0)
                    {
                        picsHere += list.Length;
                    }
                }

                string myPics = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                if (Directory.Exists(myPics) && picsHere == 0)
                {
                    tmpPath = myPics;
                }
            }
            else
            {
                tmpPath = startuppath;
            }

            quellPath = tmpPath;
            labelQuellPath.Text = tmpPath;

            if (!string.IsNullOrEmpty(Properties.Settings.Default.targetPath))
            {
                zielPath = Properties.Settings.Default.targetPath;
                labelZielPath.Text = Properties.Settings.Default.targetPath;
            }
        }

        /// <summary>
        /// Wenn Subfolders vorhanden, Text ausblenden und für jeden Subfolder einen Button anlegen
        /// </summary>
        private void CheckSubfolders()
        {
            if (!threadIsRunning)
            {
                folderThread = new Thread(new ThreadStart(CheckSubfoldersThread))
                {
                    IsBackground = true
                };
                folderThread.Start();
            }
        }

        private void CheckSubfoldersThread()
        {
            threadIsRunning = true;
            try
            {
                var folders = Directory.GetDirectories(zielPath, "*", System.IO.SearchOption.TopDirectoryOnly);
                DirectoryInfo di = new DirectoryInfo(zielPath);
                int dircount = di.GetDirectories().Length;
                Invoke(new dlgRefreshButtons(RefreshButtons), dircount, folders);
            }
            catch (Exception)
            {
            }
            finally
            {
                threadIsRunning = false;
            }
        }

        /// <summary>
        /// Erstellt für jeden Subfolder einen Button zum verschieben
        /// </summary>
        /// <param name="dircount"></param>
        /// <param name="folders"></param>
        private void RefreshButtons(int dircount, string[] folders)
        {
            RemoveButtons(buttons);
            buttons.Clear();
            if (dircount > 0)
            {
                labelNoTargets.Visible = false;
                AddButtons(folders);
            }
            else
            {
                labelNoTargets.Visible = true;
            }
        }

        public delegate void dlgRefreshButtons(int dircount, string[] folders);

        /// <summary>
        /// Fügt Buttons aus array hinzu
        /// </summary>
        /// <param name="folders"></param>
        private void AddButtons(string[] folders, int top = 9, int left = 9)
        {
            Array.Sort(folders);
            foreach (string folder in folders)
            {
                if (Path.GetFileNameWithoutExtension(folder).ToString() != "$RECYCLE" && Path.GetFileNameWithoutExtension(folder).ToString() != "System Volume Information" && Path.GetFileNameWithoutExtension(folder).ToString() != "ImageSorter" && Path.GetFileNameWithoutExtension(folder).ToString() != "Image Sorter" && Path.GetFileNameWithoutExtension(folder).ToString() != "AssocIcons")
                {
                    Button button = new Button
                    {
                        Left = left,
                        Top = top
                    };
                    int count = 0;
                    foreach (string type in fileTypes)
                    {
                        try
                        {
                            count += Directory.GetFiles(folder, "*." + type).Count();
                        }
                        catch (Exception)
                        {
                        }
                    }
                    button.Text = Path.GetFileNameWithoutExtension(folder).ToString() + " (" + count + ")";
                    button.Size = new Size(225, 30);
                    button.Click += new EventHandler(MovePicture);
                    System.Timers.Timer tx = new System.Timers.Timer(35);
                    tx.Elapsed += new System.Timers.ElapsedEventHandler((sender1, e1) => ButtonFade(button, tx));
                    button.Tag = tx;
                    buttons.Add(button);
                    top += button.Height + 2;
                }
            }

            foreach (Button button in this.buttons)
            {
                panelButtons.Controls.Add(button);
            }
        }

        /// <summary>
        /// Entfernt alle Buttons aus Liste
        /// </summary>
        /// <param name="list"></param>
        private void RemoveButtons(List<Button> list)
        {
            foreach (Button button in list)
            {
                panelButtons.Controls.Remove(button);
            }
        }

        /// <summary>
        /// Einstellungen ändern
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSettings_Click(object sender, EventArgs e)
        {
            Settings s = new Settings();
            s.ShowDialog();

            zielPath = Properties.Settings.Default.targetPath;
            labelZielPath.Text = zielPath;
            imageIndex = 0;

            if (Properties.Settings.Default.fileAssociation)
            {
                ExtractAssocIcons();
                FileAssociation.Add("Image_Sorter_JPG", ".jpg", Application.ExecutablePath, "JPG Bild", $@"{Application.StartupPath}\AssocIcons\jpg.ico");
                FileAssociation.Add("Image_Sorter_PNG", ".png", Application.ExecutablePath, "PNG Bild", $@"{Application.StartupPath}\AssocIcons\png.ico");
                FileAssociation.Add("Image_Sorter_GIF", ".gif", Application.ExecutablePath, "GIF Bild", $@"{Application.StartupPath}\AssocIcons\gif.ico");
                FileAssociation.Add("Image_Sorter_JPEG", ".jpeg", Application.ExecutablePath, "JPEG Bild", $@"{Application.StartupPath}\AssocIcons\jpeg.ico");
                FileAssociation.Add("Image_Sorter_BMP", ".bmp", Application.ExecutablePath, "BMP Bild", $@"{Application.StartupPath}\AssocIcons\bmp.ico");
                FileAssociation.Add("Image_Sorter_TIF", ".tif", Application.ExecutablePath, "TIF Bild", $@"{Application.StartupPath}\AssocIcons\tif.ico");
                FileAssociation.Add("Image_Sorter_TIFF", ".tiff", Application.ExecutablePath, "TIFF Bild", $@"{Application.StartupPath}\AssocIcons\tiff.ico");
            }
            else
            {
                if(Directory.Exists($@"{Application.StartupPath}\AssocIcons"))
                {
                    Directory.Delete($@"{Application.StartupPath}\AssocIcons", true);
                    FileAssociation.Remove("Image_Sorter_JPG");
                    FileAssociation.Remove("Image_Sorter_PNG");
                    FileAssociation.Remove("Image_Sorter_GIF");
                    FileAssociation.Remove("Image_Sorter_JPEG");
                    FileAssociation.Remove("Image_Sorter_BMP");
                    FileAssociation.Remove("Image_Sorter_TIF");
                    FileAssociation.Remove("Image_Sorter_TIFF");
                }
            }

            CheckSubfolders();
            SearchImages();
            CountPicsInPath();
            ResetUndo();
        }

        /// <summary>
        /// Fügt alle Bilder des aktuellen Verzeichnisses der Liste hinzu
        /// </summary>
        private void SearchImages()
        {
            images.Clear();
            foreach (string type in fileTypes)
            {
                var list = Directory.GetFiles(quellPath, "*." + type).OrderBy(d => new FileInfo(d).Name);
                foreach (string image in list)
                {
                    images.Add(image);
                }
            }
        }

        /// <summary>
        /// Gibt den Index des Bildes in der Bilderliste zurück
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        private int GetImageIndex(string image)
        {
            int index = images.IndexOf(image);
            return index;
        }

        /// <summary>
        /// Zählt die Bilddateien im Pfad
        /// </summary>
        private void CountPicsInPath()
        {
            Thread thread = new Thread(new ThreadStart(CountPicsInPathThread))
            {
                IsBackground = true
            };
            thread.Start();
        }

        private void CountPicsInPathThread()
        {
            Monitor.Enter(locker);
            try
            {
                int counted = 0;
                counted = images.Count();
                Invoke(new dlgRefreshCounters(RefreshCounters), counted);
            }
            catch (Exception)
            {
            }
            finally
            {
                Monitor.Exit(locker);
            }
        }

        public delegate void dlgRefreshCounters(int counted);

        /// <summary>
        /// aktualisiert die Zähler zur Bilderaktionsstatistik
        /// </summary>
        /// <param name="total"></param>
        private void RefreshCounters(int total)
        {
            if (total == 0)
            {
                labelCounter.Text = "keine Bilder vorhanden";
                SetButtonsEnabled(false);
            }
            else if (total == 1)
            {
                labelCounter.Text = "1 Bild gesamt";
                SetButtonsEnabled(true);
            }
            else
            {
                labelCounter.Text = total.ToString() + " Bilder gesamt";
                SetButtonsEnabled(true);
            }

            if (moved == 0)
            {
                labelCounter.Text += Environment.NewLine + "keines verschoben";
            }
            else
            {
                labelCounter.Text += Environment.NewLine + this.moved.ToString() + " bereits verschoben";
            }
        }

        /// <summary>
        /// Subdirectory-Ordner Buttons aktivieren/dekativieren
        /// </summary>
        /// <param name="enabled"></param>
        private void SetButtonsEnabled(bool enabled)
        {
            foreach (Button b in buttons)
            {
                b.Enabled = enabled;
            }
            buttonDeleteImage.Enabled = enabled;
            buttonMirrorHorizontal.Enabled = enabled;
            buttonMirrorVertikal.Enabled = enabled;
            buttonRotate180.Enabled = enabled;
            buttonRotate270.Enabled = enabled;
            buttonRotate90.Enabled = enabled;
            comboBoxZoom.Enabled = enabled;
            buttonJumpForward.Enabled = enabled;
            labelNoImages.Visible = !enabled;
        }

        /// <summary>
        /// Lädt das Bild in die Picturebox
        /// </summary>
        /// <param name="index"></param>
        private void LoadPicture(int index)
        {
            if (images.Count() > 0)
            {
                imageIndex = index;
                if (imageIndex >= images.Count() || imageIndex < 0)
                {
                    imageIndex = 0;
                }
                pictureBoxImage.ImageLocation = CropImageBorders(images.ElementAt(imageIndex));
                Text = defaultWindowName + " - " + Path.GetFileName(pictureBoxImage.ImageLocation);
            }
            else
            {
                pictureBoxImage.Image = null;
                Text = defaultWindowName;
            }
        }

        /// <summary>
        /// Entfernt gleichfarbige Rahmen automatisch von Bildern
        /// </summary>
        /// <param name="imagepath"></param>
        private string CropImageBorders(string imagepath)
        {
            try
            {
                Bitmap p = new Bitmap(imagepath);
                Bitmap x = BorderCropper.CropUnwantedBackground(p);
                p.Dispose();
                if (x != null)
                {
                    x.Save(imagepath);
                    Image myImg = CopyImage.GetCopyImage(imagepath);
                    ShowAutoBorderChopMessage(myImg, imagepath);
                }
            }
            catch (Exception)
            {
            }
            return imagepath;
        }

        /// <summary>
        /// Löscht die Undo-History
        /// </summary>
        private void ResetUndo()
        {
            history.Clear();
            CheckUndo();
        }

        /// <summary>
        /// Prüft ob Undo möglich ist
        /// </summary>
        private void CheckUndo()
        {
            if (history.Count() > 0)
            {
                buttonUndo.Enabled = true;
            }
            else
            {
                buttonUndo.Enabled = false;
            }
        }

        /// <summary>
        /// Verschiebt ein Bild in ein Unterverzeichnis
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MovePicture(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string[] folderButton = btn.Text.Split('(');
            int count = int.Parse(folderButton[1].Substring(0, folderButton[1].Length - 1)) + 1;
            string targetPath = Path.Combine(zielPath, folderButton[0].Substring(0, folderButton[0].Length - 1));

            try
            {
                string fullTargetPath = Path.Combine(targetPath, CleanFileName(Path.GetFileName(pictureBoxImage.ImageLocation)));
                Image myImg = CopyImage.GetCopyImage(pictureBoxImage.ImageLocation);
                if (File.Exists(fullTargetPath))
                {
                    using (var form = new Vergleicher("Das zu verschiebende Bild \"" + CleanFileName(Path.GetFileName(pictureBoxImage.ImageLocation)) + "\"" + "existiert im Zielverzeichnis \"" + btn.Text + "\" bereits." + Environment.NewLine + Environment.NewLine + "Soll eine Kopie angelegt werden? Nein überschreibt die Datei, Abbrechen bricht den Vorgang ab.", pictureBoxImage.ImageLocation, fullTargetPath))
                    {
                        var result = form.ShowDialog();
                        if (result == DialogResult.Yes)
                        {
                            fullTargetPath = Path.Combine(targetPath, CleanFileName(Path.GetFileNameWithoutExtension(pictureBoxImage.ImageLocation)) + Randomize.NumbersAndDigits(5, "_") + Path.GetExtension(pictureBoxImage.ImageLocation));
                        }
                        else if (result == DialogResult.No)
                        {
                            File.Copy(pictureBoxImage.ImageLocation, fullTargetPath, true);
                            File.Delete(pictureBoxImage.ImageLocation);
                            images.Remove(pictureBoxImage.ImageLocation);
                            history.Add(fullTargetPath);
                            moved++;
                            ShowMovedMessage(myImg, fullTargetPath, btn.Text);
                            CheckSubfolders();
                            CountPicsInPath();
                            LoadPicture(imageIndex);
                            CheckUndo();
                            return;
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                File.Move(pictureBoxImage.ImageLocation, fullTargetPath);
                images.Remove(pictureBoxImage.ImageLocation);
                history.Add(fullTargetPath);
                moved++;
                ShowMovedMessage(myImg, fullTargetPath, btn.Text);
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            btn.Text = folderButton[0] + "(" + count + ")";
            CountPicsInPath();
            LoadPicture(imageIndex);
            CheckUndo();

            if(Properties.Settings.Default.fading)
            {
                btn.BackColor = Color.LightSalmon;
                btn.ForeColor = Color.MediumSeaGreen;
                btn.Font = new Font(btn.Font, FontStyle.Bold);
                System.Timers.Timer t = new System.Timers.Timer(700);
                t.Elapsed += new System.Timers.ElapsedEventHandler((sender1, e1) => ButtonBlink(sender, e, btn, t));
                t.Start();
            }
        }

        private string CleanFileName(string filename)
        {
            string fn = filename;
            fn = fn.Replace("_crp", "");
            fn = fn.Replace("_cut", "");
            return fn;
        }

        /// <summary>
        /// Blinkender Button nach erfolgreichem Verschieben
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="btn"></param>
        private void ButtonBlink(object sender, EventArgs e, Button btn, System.Timers.Timer t)
        {
            btn.BeginInvoke(new MethodInvoker(() =>
            {
                System.Timers.Timer tx = btn.Tag as System.Timers.Timer;
                if (tx.Enabled)
                {
                    tx.Stop();
                    btn.BackColor = Color.LightSalmon;
                }
                btn.ForeColor = SystemColors.ControlText;
                btn.Font = new Font(btn.Font, FontStyle.Regular);
                tx.Start();
            }));
            t.Stop();
        }

        /// <summary>
        /// Hintergrundfarbe des Buttons langsam nach Transparent blenden
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="btn"></param>
        private void ButtonFade(Button btn, System.Timers.Timer tx)
        {
            btn.BeginInvoke(new MethodInvoker(() =>
            {
                int speed = Properties.Settings.Default.fadingSpeed * (Properties.Settings.Default.fadingSpeed / 3) + 1;
                int alpha = btn.BackColor.A;
                if (alpha - speed >= 0)
                {
                    btn.BackColor = Color.FromArgb(btn.BackColor.A - speed, btn.BackColor.R, btn.BackColor.G, btn.BackColor.B);
                }
                else
                {
                    btn.BackColor = Color.Transparent;
                    tx.Stop();
                }
            }));
        }

        /// <summary>
        /// Macht die letzte Aktion rückgängig
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonUndo_Click(object sender, EventArgs e)
        {
            string targetPath = Path.Combine(this.quellPath, Path.GetFileName(history.ElementAt(history.Count() - 1)));
            if (Path.GetFullPath(history.ElementAt(history.Count() - 1)).StartsWith("C:\\img-tmp"))
            {
                targetPath = pictureBoxImage.ImageLocation;
            }

            try
            {
                Image myImg = CopyImage.GetCopyImage(history.ElementAt(history.Count() - 1));
                File.Copy(history.ElementAt(history.Count() - 1), targetPath, true);
                File.Delete(history.ElementAt(history.Count() - 1));
                history.Remove(history.ElementAt(history.Count() - 1));
                images.Insert(imageIndex, targetPath);
                moved--;
                ShowUndoMessage(myImg, targetPath);
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            CheckSubfolders();
            CountPicsInPath();
            LoadPicture(imageIndex);
            CheckUndo();
        }

        /// <summary>
        /// Dreht das Bild und überschreibt es
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageRotate(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string rotateString = btn.Tag.ToString();
            int rotation = int.Parse(rotateString);

            Image subject = Image.FromFile(images.ElementAt(imageIndex));

            if (rotation == 90)
            {
                subject.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }
            else if (rotation == 180)
            {
                subject.RotateFlip(RotateFlipType.Rotate180FlipNone);
            }
            else
            {
                subject.RotateFlip(RotateFlipType.Rotate270FlipNone);
            }

            string ext = Path.GetExtension(images.ElementAt(imageIndex));
            if (ext == ".png")
            {
                subject.Save(images.ElementAt(imageIndex), ImageFormat.Png);
            }
            else if (ext == ".gif")
            {
                subject.Save(images.ElementAt(imageIndex), ImageFormat.Gif);
            }
            else
            {
                subject.Save(images.ElementAt(imageIndex), ImageFormat.Jpeg);
            }

            LoadPicture(imageIndex);
            groupBoxTransformation.Visible = false;
        }

        /// <summary>
        /// Spiegelt ein Bild und überschreibt es
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageMirror(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string mirrorString = btn.Tag.ToString();

            Image subject = Image.FromFile(images.ElementAt(imageIndex));

            if (mirrorString == "x")
            {
                subject.RotateFlip(RotateFlipType.RotateNoneFlipX);
            }
            else
            {
                subject.RotateFlip(RotateFlipType.RotateNoneFlipY);
            }

            string ext = Path.GetExtension(images.ElementAt(imageIndex));
            if (ext == ".png")
            {
                subject.Save(images.ElementAt(imageIndex), ImageFormat.Png);
            }
            else if (ext == ".gif")
            {
                subject.Save(images.ElementAt(imageIndex), ImageFormat.Gif);
            }
            else
            {
                subject.Save(images.ElementAt(imageIndex), ImageFormat.Jpeg);
            }

            LoadPicture(imageIndex);
            groupBoxTransformation.Visible = false;
        }

        /// <summary>
        /// Verschiebt ein Bild in den Papierkorb
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageDelete(object sender, EventArgs e)
        {
            Image myImg = CopyImage.GetCopyImage(pictureBoxImage.ImageLocation);
            string pfad = Path.GetFileName(pictureBoxImage.ImageLocation);
            FileSystem.DeleteFile(pictureBoxImage.ImageLocation, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin, UICancelOption.DoNothing);
            images.Remove(pictureBoxImage.ImageLocation);

            CheckSubfolders();
            CountPicsInPath();
            LoadPicture(imageIndex);
            ShowDeletedMessage(myImg, pfad);
        }

        /// <summary>
        /// Zoom-Optionen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Zoom()
        {
            string zoom = comboBoxZoom.SelectedItem.ToString();

            if (zoom == "Original")
            {
                pictureBoxImage.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBoxImage.Size = new Size(pictureBoxImage.Image.Width, pictureBoxImage.Image.Height);
                if (pictureBoxImage.Image.Width > panelImageBackground.Width) { pictureBoxImage.Left = (panelImageBackground.Width / 2) - (pictureBoxImage.Width / 2); } else { pictureBoxImage.Left = (panelImageBackground.Width / 2) - (pictureBoxImage.Image.Width / 2); }
                if (pictureBoxImage.Image.Height > panelImageBackground.Height) { pictureBoxImage.Top = (panelImageBackground.Height / 2) - (pictureBoxImage.Height / 2); } else { pictureBoxImage.Top = (panelImageBackground.Height / 2) - (pictureBoxImage.Image.Height / 2); }
                moveable = true;
            }
            else if (zoom == "Vollbild")
            {
                pictureBoxImage.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBoxImage.Size = new Size(panelImageBackground.Width, panelImageBackground.Height);
                pictureBoxImage.Top = 0;
                pictureBoxImage.Left = 0;
                moveable = false;
            }
            else if (zoom == "Auto")
            {
                pictureBoxImage.SizeMode = PictureBoxSizeMode.Zoom;
                if(pictureBoxImage.Image.Width>panelImageBackground.Width || pictureBoxImage.Image.Height>panelImageBackground.Height)
                {
                    pictureBoxImage.Size = new Size(panelImageBackground.Width, panelImageBackground.Height);
                    pictureBoxImage.Top = 0;
                    pictureBoxImage.Left = 0;
                    moveable = false;
                }
                else
                {
                    pictureBoxImage.Size = new Size(pictureBoxImage.Image.Width, pictureBoxImage.Image.Height);
                    if (pictureBoxImage.Image.Width > panelImageBackground.Width) { pictureBoxImage.Left = (panelImageBackground.Width / 2) - (pictureBoxImage.Width / 2); } else { pictureBoxImage.Left = (panelImageBackground.Width / 2) - (pictureBoxImage.Image.Width / 2); }
                    if (pictureBoxImage.Image.Height > panelImageBackground.Height) { pictureBoxImage.Top = (panelImageBackground.Height / 2) - (pictureBoxImage.Height / 2); } else { pictureBoxImage.Top = (panelImageBackground.Height / 2) - (pictureBoxImage.Image.Height / 2); }
                    moveable = true;
                }
            }
            else
            {
                return;
            }

            xFaktor = pictureBoxImage.Width / (double)pictureBoxImage.Image.Width;
            yFaktor = pictureBoxImage.Height / (double)pictureBoxImage.Image.Height;
            labelZoom2.Text = "x" + Math.Round(yFaktor, 1);
        }

        /// <summary>
        /// Mausklicks in picturebox verwalten
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (moveable)
                {
                    moving = true;
                    startLocation = e.Location;
                    pictureBoxImage.Cursor = grabbingCursor;
                }
                else
                {
                    pictureBoxImage.Cursor = Cursors.No;
                }
            }
            if (e.Button == MouseButtons.Middle)
            {
                if (moveable)
                {
                    pictureBoxImage.Top = (panelImageBackground.Height / 2) - (pictureBoxImage.Height / 2);
                    pictureBoxImage.Left = (panelImageBackground.Width / 2) - (pictureBoxImage.Width / 2);
                }
                else
                {
                    pictureBoxImage.Cursor = Cursors.No;
                }
            }
        }

        /// <summary>
        /// Mausklicks in picturebox verwalten
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (moveable && moving)
            {
                moving = false;
                if (pictureBoxImage.Top > 0) { pictureBoxImage.Top = 0; }
                if (pictureBoxImage.Top < -pictureBoxImage.Height + panelImageBackground.Height) { pictureBoxImage.Top = -pictureBoxImage.Height + panelImageBackground.Height; }
                if (pictureBoxImage.Left > 0) { pictureBoxImage.Left = 0; }
                if (pictureBoxImage.Left < -pictureBoxImage.Width + panelImageBackground.Width) { pictureBoxImage.Left = -pictureBoxImage.Width + panelImageBackground.Width; }
            }
            pictureBoxImage.Cursor = grabCursor;
        }

        /// <summary>
        /// Bildausschnitt verschieben
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (moving)
            {
                if (pictureBoxImage.Top > 0) { pictureBoxImage.Top = 0; }
                if (pictureBoxImage.Top < -pictureBoxImage.Height + panelImageBackground.Height) { pictureBoxImage.Top = -pictureBoxImage.Height + panelImageBackground.Height; }
                if (pictureBoxImage.Left > 0) { pictureBoxImage.Left = 0; }
                if (pictureBoxImage.Left < -pictureBoxImage.Width + panelImageBackground.Width) { pictureBoxImage.Left = -pictureBoxImage.Width + panelImageBackground.Width; }
                pictureBoxImage.Top += e.Location.Y - startLocation.Y;
                pictureBoxImage.Left += e.Location.X - startLocation.X;
            }
        }

        /// <summary>
        /// Bild Zoom
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ZoomInOut(object sender, MouseEventArgs e)
        {
            if (e.Delta != 0 && pictureBoxImage.Image != null)
            {
                double xstep = pictureBoxImage.Width * 0.01;
                double ystep = pictureBoxImage.Height * 0.01;
                if (xstep < 1.0) { xstep = 1.0; }
                if (ystep < 1.0) { ystep = 1.0; }

                int maxWidth = pictureBoxImage.Image.Width * 8;
                int minWidth = pictureBoxImage.Image.Width / 8;

                int newWidth = pictureBoxImage.Width - (pictureBoxImage.Width / (int)xstep * (e.Delta / 120));
                int newHeight = pictureBoxImage.Height - (pictureBoxImage.Height / (int)xstep * (e.Delta / 120));

                if (newWidth <= maxWidth && newWidth >= minWidth)
                {
                    pictureBoxImage.Width = newWidth;
                    pictureBoxImage.Height = newHeight;
                }

                if (pictureBoxImage.Width > panelImageBackground.Width || pictureBoxImage.Height > panelImageBackground.Height)
                {
                    moveable = true;
                    if (pictureBoxImage.Right < panelImageBackground.Width) { pictureBoxImage.Left += -pictureBoxImage.Right + panelImageBackground.Width; }
                    if (pictureBoxImage.Bottom < panelImageBackground.Height) { pictureBoxImage.Top += -pictureBoxImage.Bottom + panelImageBackground.Height; }
                }
                else
                {
                    moveable = false;
                    pictureBoxImage.Top = (panelImageBackground.Height / 2) - (pictureBoxImage.Height / 2);
                    pictureBoxImage.Left = (panelImageBackground.Width / 2) - (pictureBoxImage.Width / 2);
                }

                xFaktor = pictureBoxImage.Width / (double)pictureBoxImage.Image.Width;
                yFaktor = pictureBoxImage.Height / (double)pictureBoxImage.Image.Height;
                labelZoom2.Text = "x" + Math.Round(yFaktor, 1);
            }
        }

        /// <summary>
        /// Focus auf Panel1 bei MouseEnter in Picturebox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBox_MouseEnter(object sender, EventArgs e)
        {
            panelImageBackground.Focus();
        }

        /// <summary>
        /// Focus auf Buttons bei MouseLeave von Picturebox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBox_MouseLeave(object sender, EventArgs e)
        {
            groupBoxInformationen.Focus();
        }

        /// <summary>
        /// Bild in picturebox vollständig geladen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBox_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Zoom();
        }

        /// <summary>
        /// Maus-Fokus auf Panel2 bei MouseEnter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Panel2_MouseEnter(object sender, EventArgs e)
        {
            panelButtons.Focus();
        }

        /// <summary>
        /// Öffnet im Explorer den Ordner des Bildes und legt den Fokus auf das aktuelle Bild, wenn es existiert
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemOpenExplorer_Click(object sender, EventArgs e)
        {
            if (File.Exists(pictureBoxImage.ImageLocation))
            {
                Process.Start("explorer.exe", @"/select, " + pictureBoxImage.ImageLocation);
            }

            else if (Directory.Exists(Path.GetDirectoryName(pictureBoxImage.ImageLocation)))
            {
                Process.Start("explorer.exe", Path.GetDirectoryName(pictureBoxImage.ImageLocation));
            }
        }

        /// <summary>
        /// Zeigt Details (Eigenschaften) zum aktuellen Bild an
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemImageDetails_Click(object sender, EventArgs e)
        {
            using (Image img = Image.FromFile(pictureBoxImage.ImageLocation))
            {
                FileInfo info = new FileInfo(pictureBoxImage.ImageLocation);
                ImageFormat format = img.RawFormat;
                MessageBox.Show("Dateiname: " + info.Name + Environment.NewLine +
                                "Pfad: " + info.DirectoryName + Environment.NewLine +
                                "Erstellt: " + info.CreationTime + Environment.NewLine +
                                "Geändert: " + info.LastWriteTime + Environment.NewLine +
                                "Bildformat: " + new ImageFormatConverter().ConvertToString(format) + Environment.NewLine +
                                "Abmessungen: " + img.Width + " x " + img.Height + Environment.NewLine +
                                "Breite: " + img.Width + " Px" + Environment.NewLine +
                                "Höhe: " + img.Height + " Px" + Environment.NewLine +
                                "Auflösung: " + Resolution.GetImageResolution(img) + Environment.NewLine +
                                "Größe: " + FileSize.GetFileSize(info.Length) + Environment.NewLine +
                                "Bittiefe: " + Image.GetPixelFormatSize(img.PixelFormat) + " bit", "Bildeigenschaften", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Zeigt die EXIF-Daten vom aktuellen Bild an
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemShowEXIF_Click(object sender, EventArgs e)
        {
            using (Image img = Image.FromFile(pictureBoxImage.ImageLocation))
            {
                EXIF exif = new EXIF(img.PropertyItems);
                exif.ShowDialog();
            }
        }

        /// <summary>
        /// Öffnet Paint zum Bearbeiten des Bildes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemEditImage_Click(object sender, EventArgs e)
        {
            FileInfo info = new FileInfo(pictureBoxImage.ImageLocation);
            ProcessStartInfo pi = new ProcessStartInfo
            {
                FileName = ("mspaint.exe"),
                UseShellExecute = false,
                Arguments = "\"" + info.FullName + "\""
            };
            Process p = new Process
            {
                StartInfo = pi
            };
            p.Start();
            p.WaitForExit();
            LoadPicture(imageIndex);
        }

        /// <summary>
        /// Öffnet das Cropping-Form um Bilder zuzuschneiden
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BildZuschneidenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cropper cropper = new Cropper(pictureBoxImage.ImageLocation);
            DialogResult result = cropper.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                string del = pictureBoxImage.ImageLocation;
                images[imageIndex] = cropper.NewFileLocation;
                LoadPicture(imageIndex);
                FileSystem.DeleteFile(del, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin, UICancelOption.DoNothing);
            }
        }

        /// <summary>
        /// Größe, Position in Settings speichern vor dem Schließen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.lastPath = quellPath;
            Properties.Settings.Default.lastWidth = Width;
            Properties.Settings.Default.lastHeight = Height;
            Properties.Settings.Default.lastTop = Top;
            Properties.Settings.Default.lastLeft = Left;
            Properties.Settings.Default.showInfo = groupBoxInformationen.Visible;
            Properties.Settings.Default.fullScreen = (WindowState == FormWindowState.Maximized ? true : false);
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Anzeige eines Banners bei verschobenem Bild
        /// </summary>
        /// <param name="bildpfad"></param>
        /// <param name="ordnername"></param>
        private void ShowMovedMessage(Image bild, string bildpfad, string ordnername)
        {
            banner.Enqueue("Bild \"" + Path.GetFileName(bildpfad) + "\" erfolgreich nach", "\"" + ordnername + "\" verschoben.", bild, Properties.Resources.move);
            banner.ShowMessages();
        }

        /// <summary>
        /// Anzeige eines Banners bei gelöschtem Bild
        /// </summary>
        /// <param name="bild"></param>
        /// <param name="bildname"></param>
        private void ShowDeletedMessage(Image bild, string bildname)
        {
            banner.Enqueue("Bild \"" + bildname + "\" erfolgreich gelöscht.", "", bild, Properties.Resources.delete);
            banner.ShowMessages();
        }

        /// <summary>
        /// Anzeige eines Banners bei rückgängig gemachter Aktion
        /// </summary>
        /// <param name="bildpfad"></param>
        private void ShowUndoMessage(Image bild, string bildpfad)
        {
            banner.Enqueue("Bildaktion für \"" + Path.GetFileName(bildpfad) + "\" erfolgreich", "rückgängig gemacht.", bild, Properties.Resources.undo);
            banner.ShowMessages();
        }

        /// <summary>
        /// Anzeige eines Banners bei automatischem zuschneiden der Ränder
        /// </summary>
        /// <param name="bildpfad"></param>
        private void ShowAutoBorderChopMessage(Image bild, string bildpfad)
        {
            banner.Enqueue("Die Ränder für \"" + Path.GetFileName(bildpfad) + "\" wurden", "automatisch zugeschnitten.", bild, Properties.Resources.crop);
            banner.ShowMessages();
        }

        /// <summary>
        /// Anzeige eines Banners bei erstelltem Duplikat
        /// </summary>
        /// <param name="bild"></param>
        /// <param name="bildpfad"></param>
        private void ShowDuplicatedMessage(Image bild, string bildpfad)
        {
            banner.Enqueue("Das Duplikat \"" + Path.GetFileName(bildpfad) + "\"", "wurde erstellt.", bild, Properties.Resources.duplicate);
            banner.ShowMessages();
        }

        /// <summary>
        /// Bild wieder neu zentrieren und skalieren nach Größenänderung des Fensters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_Resize(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Minimized)
            {
                lastState = WindowState;
            }
            try
            {
                Zoom();
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Globale Tasten-Events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                buttonDeleteImage.PerformClick();
                e.Handled = true;
            }

            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Down)
            {
                CountPicsInPath();
                LoadPicture(imageIndex - 1);
                CheckUndo();
                e.Handled = true;
            }

            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Up)
            {
                CountPicsInPath();
                LoadPicture(imageIndex + 1);
                CheckUndo();
                e.Handled = true;
            }

            if (e.KeyCode == Keys.F2)
            {
                toolStripMenuItemCropImage.PerformClick();
                e.Handled = true;
            }

            if (e.KeyCode == Keys.F3)
            {
                toolStripMenuItemEditImage.PerformClick();
                e.Handled = true;
            }

            if (e.KeyCode == Keys.F4)
            {
                toolStripMenuItemOpenExplorer.PerformClick();
                e.Handled = true;
            }

            if (e.KeyCode == Keys.F5)
            {
                toolStripMenuItemImageDetails.PerformClick();
                e.Handled = true;
            }

            if (e.KeyCode == Keys.F6)
            {
                toolStripMenuItemShowEXIF.PerformClick();
                e.Handled = true;
            }

            if (e.KeyCode == Keys.Back)
            {
                buttonUndo.PerformClick();
                e.Handled = true;
            }
        }

        /// <summary>
        /// Quellpfad auswählen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonQuellPfad_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                quellPath = folderBrowserDialog.SelectedPath;
                labelQuellPath.Text = quellPath;
            }

            CheckSubfolders();
            SearchImages();
            CountPicsInPath();
            LoadPicture(0);
            ResetUndo();
        }

        /// <summary>
        /// Zoom-Combobox geändert
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxZoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.zoom = comboBoxZoom.SelectedIndex;
            Properties.Settings.Default.Save();

            if(pictureBoxImage.Image != null)
            {
                Zoom();
            }
        }

        /// <summary>
        /// Zu vorherigem Bild springen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonJumpBack_Click(object sender, MouseEventArgs e)
        {
            CountPicsInPath();
            LoadPicture(imageIndex - 1);
            CheckUndo();
        }

        /// <summary>
        /// Zu nächstem Bild springen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonJumpForward_Click(object sender, MouseEventArgs e)
        {
            CountPicsInPath();
            LoadPicture(imageIndex + 1);
            CheckUndo();
        }

        /// <summary>
        /// Informationen ein-/ausblenden
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonInfo_Click(object sender, EventArgs e)
        {
            if(groupBoxInformationen.Visible)
            {
                //ausblenden
                groupBoxInformationen.Visible = false;
                groupBoxZiele.Location = new Point(groupBoxZiele.Location.X, 12);
                groupBoxZiele.Height = groupBoxZiele.Height + 87;
            }
            else
            {
                //einblenden
                groupBoxInformationen.Visible = true;
                groupBoxZiele.Location = new Point(groupBoxZiele.Location.X, 99);
                groupBoxZiele.Height = groupBoxZiele.Height - 87;
            }
        }

        /// <summary>
        /// Blendet letztes Bild ein
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonLastImage_MouseDown(object sender, MouseEventArgs e)
        {
            //todo vorheriges Bild anzeigen
        }

        /// <summary>
        /// Blendet letztes Bild aus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonLastImage_MouseUp(object sender, MouseEventArgs e)
        {
            //todo vorheriges Bild ausblenden
        }

        /// <summary>
        /// Duplikat von aktuellem Bild erzeugen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDuplicate_Click(object sender, EventArgs e)
        {
            //aktuelles bild kopieren
            string targetPath = Path.Combine(Path.GetDirectoryName(pictureBoxImage.ImageLocation), Path.GetFileNameWithoutExtension(pictureBoxImage.ImageLocation) + Randomize.NumbersAndDigits(5, "_") + Path.GetExtension(pictureBoxImage.ImageLocation));
            File.Copy(pictureBoxImage.ImageLocation, targetPath, true);

            //duplikat als nächstes bild in liste aufnehmen
            images.Insert(imageIndex + 1, targetPath);
            CountPicsInPath();

            //duplikat-message anzeigen
            Image myImg = CopyImage.GetCopyImage(targetPath);
            ShowDuplicatedMessage(myImg, targetPath);
        }

        /// <summary>
        /// Untermenü für Transformation ein-/ausblenden
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonTransformation_Click(object sender, EventArgs e)
        {
            groupBoxTransformation.Visible = !groupBoxTransformation.Visible;
        }

        /// <summary>
        /// Hintergrund hell/dunkel schalten
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonHintergrund_Click(object sender, EventArgs e)
        {
            if(panelImageBackground.BackColor==Color.Black)
            {
                panelImageBackground.BackColor = SystemColors.Control;
                pictureBoxImage.BackColor = SystemColors.Control;
            }
            else
            {
                panelImageBackground.BackColor = Color.Black;
                pictureBoxImage.BackColor = Color.Black;
            }
        }

        /// <summary>
        /// Ränder schneiden Untermenü ein-/ausblenden
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonRander_Click(object sender, EventArgs e)
        {
            groupBoxRander.Visible = !groupBoxRander.Visible;
        }

        /// <summary>
        /// Rand von Bild schneiden
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RandSchneiden_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string cutString = btn.Tag.ToString();
            Image im = pictureBoxImage.Image;

            int move = trackBarRander.Value;
            int x = 0, y = 0, width = im.Width, height = im.Height;

            if (cutString == "links")
            {
                x += move;
                width -= move;
            }
            else if (cutString == "rechts")
            {
                width -= move;
            }
            else if (cutString == "oben")
            {
                y += move;
                height -= move;
            }
            else if (cutString == "unten")
            {
                height -= move;
            }

            Rectangle r = new Rectangle(x, y, width, height);
            Image res = CropImage(im, r);

            string folder = Path.GetDirectoryName(pictureBoxImage.ImageLocation);
            string file = Path.GetFileNameWithoutExtension(pictureBoxImage.ImageLocation) + "_cut";
            string ext = Path.GetExtension(pictureBoxImage.ImageLocation);
            string newFileLocation = Path.Combine(folder, file + ext);
            string del = pictureBoxImage.ImageLocation;
            if (ext == ".png")
            {
                res.Save(newFileLocation, ImageFormat.Png);
            }
            else if (ext == ".gif")
            {
                res.Save(newFileLocation, ImageFormat.Gif);
            }
            else
            {
                res.Save(newFileLocation, ImageFormat.Jpeg);
            }
            images[imageIndex] = newFileLocation;
            LoadPicture(imageIndex);
            FileSystem.DeleteFile(del, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin, UICancelOption.DoNothing);

            groupBoxRander.Visible = false;
        }

        /// <summary>
        /// schneidet Bilder aus
        /// </summary>
        /// <param name="img"></param>
        /// <param name="cropArea"></param>
        /// <returns></returns>
        private static Image CropImage(Image img, Rectangle cropArea)
        {
            Bitmap bmpImage = new Bitmap(img);
            Bitmap bmpCrop = bmpImage.Clone(cropArea,
            bmpImage.PixelFormat);
            return (Image)(bmpCrop);
        }

        /// <summary>
        /// Ändert das Pixel-Label auf den aktuellen Wert
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrackBarRander_Scroll(object sender, EventArgs e)
        {
            labelRander.Text = trackBarRander.Value + " px.";
        }
    }
}