using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace Mk0.Software.ImageSorter
{
    public partial class EXIF : Form
    {
        private List<Exifdata> exifData;

        public EXIF(PropertyItem[] propertyItems)
        {
            InitializeComponent();
            exifData = new List<Exifdata>();
            foreach (PropertyItem propItem in propertyItems)
            {
                Exifdata ed = new Exifdata(propItem.Id, propItem.Type, propItem.Len, propItem.Value);
                exifData.Add(ed);
            }
        }

        private void EXIF_Shown(object sender, EventArgs e)
        {
            treeViewExif.BeginUpdate();
            foreach (Exifdata ed in exifData)
            {
                if (ed.ID != "ThumbnailData")
                {
                    TreeNode node = new TreeNode(ed.ID);
                    node.Nodes.Add(new TreeNode(ed.Value));

                    node.Nodes.Add(new TreeNode(ed.Type));
                    node.Nodes.Add(new TreeNode(ed.Length));

                    treeViewExif.Nodes.Add(node);
                    node.Expand();
                }
            }
            treeViewExif.TreeViewNodeSorter = new Sorter();
            treeViewExif.Sort();
            treeViewExif.EndUpdate();
        }
    }

    public class Exifdata
    {
        private const string DOUBLETYPE_FORMAT = "0.0####";
        private const int BYTEJUMP_SHORT = 2;
        private const int BYTEJUMP_LONG = 4;
        private const int BYTEJUMP_RATIONAL = 8;
        private const int BYTEJUMP_SLONG = 4;
        private const int BYTEJUMP_SRATIONAL = 8;
        public string ID, Type, Length, Value;
        public short TypeOriginal;

        public Exifdata(int id, short type, int len, byte[] value)
        {
            ID = new Exifid("0x" + id.ToString("x4")).Readable;
            TypeOriginal = type;
            Type = ExifType(type);
            Length = len.ToString() + " bytes";
            Value = ExifValue(value, type, len);
        }

        public string ExifValue(byte[] value, short type, int len)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            string ev = "";

            if (type == 1)
            {
                ev = BitConverter.ToString(value, 0, len);
            }
            else if (type == 2)
            {
                ev = encoding.GetString(value, 0, len - 1);
            }
            else if (type == 3)
            {
                for (int i = 0; i < len; i = i + BYTEJUMP_SHORT)
                {
                    ushort val = BitConverter.ToUInt16(value, i);
                    ev += val.ToString();
                    if (i + BYTEJUMP_SHORT < len)
                        ev += " ";
                }
            }
            else if (type == 4)
            {
                for (int i = 0; i < len; i = i + BYTEJUMP_LONG)
                {
                    uint val = BitConverter.ToUInt32(value, i);
                    ev += val.ToString();
                    if (i + BYTEJUMP_LONG < len)
                        ev += " ";
                }
            }
            else if (type == 5)
            {
                for (int i = 0; i < len; i = i + BYTEJUMP_RATIONAL)
                {
                    uint numer = BitConverter.ToUInt32(value, i);
                    uint denom = BitConverter.ToUInt32(value, i + BYTEJUMP_LONG);
                    //if (formatInstr == FormatInstr.FRACTION)
                    if(false)
                    {
                        UFraction frac = new UFraction(numer, denom);
                        ev += frac.ToString();
                    }
                    else
                    {
                        double dbl;
                        if (denom == 0)
                            dbl = 0.0;
                        else
                            dbl = (double)numer / (double)denom;
                        ev += dbl.ToString(DOUBLETYPE_FORMAT);
                    }
                    if (i + BYTEJUMP_RATIONAL < len)
                        ev += " ";
                }
            }
            else if (type == 6)
            {
                //if (formatInstr == FormatInstr.ALLCHAR)
                if (false)
                {
                    ev = encoding.GetString(value, 0, len);
                }
                else
                {
                    ev = BitConverter.ToString(value, 0, len);
                }
            }
            else if (type == 7)
            {
                try
                {
                    for (int i = 0; i < len; i = i + BYTEJUMP_SLONG)
                    {
                        int val = BitConverter.ToInt32(value, i);
                        ev += val.ToString();
                        if (i + BYTEJUMP_SLONG < len)
                            ev += " ";
                    }
                }
                catch (Exception ex)
                {
                    ev = ex.ToString();
                }
            }
            else if (type == 10)
            {
                for (int i = 0; i < len; i = i + BYTEJUMP_SRATIONAL)
                {
                    int numer = BitConverter.ToInt32(value, i);
                    int denom = BitConverter.ToInt32(value, i + BYTEJUMP_SLONG);
                    //if (formatInstr == FormatInstr.FRACTION)
                    if (false)
                    {
                        Fraction frac = new Fraction(numer, denom);
                        ev += frac.ToString();
                    }
                    else
                    {
                        double dbl;
                        if (denom == 0)
                            dbl = 0.0;
                        else
                            dbl = (double)numer / (double)denom;
                        ev += dbl.ToString(DOUBLETYPE_FORMAT);
                    }
                    if (i + BYTEJUMP_SRATIONAL < len)
                        ev += " ";
                }
            }
            else
            {
                ev = "unlesbarer Typ";
            }

            return ev;
        }

        public string ExifType(short type)
        {
            switch (type)
            {
                case 1:
                    return "unsigned array of bytes";
                case 2:
                    return "ASCII string";
                case 3:
                    return "array of unsigned short (16-bit) integers";
                case 4:
                    return "array of unsigned long (32-bit) integers";
                case 5:
                    return "array of pairs of unsigned long integers";
                case 6:
                    return "signed array of bytes";
                case 7:
                    return "array of signed long (32-bit) integers";
                case 10:
                    return "array of pairs of signed long integers";
                default:
                    return "unknown";
            }
        }
    }

    public class Exifid
    {
        public string Readable;
        public Dictionary<string, string> ids = new Dictionary<string, string>();

        public Exifid(string id)
        {
            ids.Add("0x0000", "GPS Version");
            ids.Add("0x0001", "GPS Latitude Nord- oder Südhalbkugel");
            ids.Add("0x0002", "GPS Latitude");
            ids.Add("0x0003", "GPS Longitude Ost oder West");
            ids.Add("0x0004", "GPS Longitude");
            ids.Add("0x0005", "GPS AltitudeRef");
            ids.Add("0x0006", "GPS Altitude");
            ids.Add("0x0007", "GPS Time");
            ids.Add("0x0008", "GPS Satellites");
            ids.Add("0x0009", "GPS Status");
            ids.Add("0x000a", "GPS MeasureMode");
            ids.Add("0x000b", "GPS Dop");
            ids.Add("0x000c", "GPS SpeedRef");
            ids.Add("0x000d", "GPS Speed");
            ids.Add("0x000e", "GPS TrackRef");
            ids.Add("0x000f", "GPS Track");
            ids.Add("0x0010", "GPS ImgDirRef");
            ids.Add("0x0011", "GPS ImgDir");
            ids.Add("0x0012", "GPS MapDatum");
            ids.Add("0x0013", "GPS DestLatRef");
            ids.Add("0x0014", "GPS DestLat");
            ids.Add("0x0015", "GPS DestLongRef");
            ids.Add("0x0016", "GPS DestLong");
            ids.Add("0x0017", "GPS DestBearRef");
            ids.Add("0x0018", "GPS DestBear");
            ids.Add("0x0019", "GPS DestDistRef");
            ids.Add("0x001a", "GPS DestDist");
            ids.Add("0x00fe", "NewSubfileType");
            ids.Add("0x00ff", "SubfileType");
            ids.Add("0x0100", "ImageWidth");
            ids.Add("0x0101", "ImageHeight");
            ids.Add("0x0102", "BitsPerSample");
            ids.Add("0x0103", "Compression");
            ids.Add("0x0106", "PhotometricInterp");
            ids.Add("0x0107", "ThreshHolding");
            ids.Add("0x0108", "CellWidth");
            ids.Add("0x0109", "CellHeight");
            ids.Add("0x010a", "FillOrder");
            ids.Add("0x010d", "DocumentName");
            ids.Add("0x010e", "ImageDescription");
            ids.Add("0x010f", "EquipMake");
            ids.Add("0x0110", "EquipModel");
            ids.Add("0x0111", "StripOffsets");
            ids.Add("0x0112", "Orientation");
            ids.Add("0x0115", "SamplesPerPixel");
            ids.Add("0x0116", "RowsPerStrip");
            ids.Add("0x0117", "StripBytesCount");
            ids.Add("0x0118", "MinSampleValue");
            ids.Add("0x0119", "MaxSampleValue");
            ids.Add("0x011a", "XResolution");
            ids.Add("0x011b", "YResolution");
            ids.Add("0x011c", "PlanarConfig");
            ids.Add("0x011d", "PageName");
            ids.Add("0x011e", "XPosition");
            ids.Add("0x011f", "YPosition");
            ids.Add("0x0120", "FreeOffset");
            ids.Add("0x0121", "FreeByteCounts");
            ids.Add("0x0122", "GrayResponseUnit");
            ids.Add("0x0123", "GrayResponseCurve");
            ids.Add("0x0124", "T4Option");
            ids.Add("0x0125", "T6Option");
            ids.Add("0x0128", "ResolutionUnit");
            ids.Add("0x0129", "PageNumber");
            ids.Add("0x012d", "TransferFunction");
            ids.Add("0x0131", "SoftwareUsed");
            ids.Add("0x0132", "DateTime");
            ids.Add("0x013b", "Artist");
            ids.Add("0x013c", "HostComputer");
            ids.Add("0x013d", "Predictor");
            ids.Add("0x013e", "WhitePoint");
            ids.Add("0x013f", "PrimaryChromaticities");
            ids.Add("0x0140", "ColorMap");
            ids.Add("0x0141", "HalftoneHints");
            ids.Add("0x0142", "TileWidth");
            ids.Add("0x0143", "TileLength");
            ids.Add("0x0144", "TileOffset");
            ids.Add("0x0145", "TileByteCounts");
            ids.Add("0x014c", "InkSet");
            ids.Add("0x014d", "InkNames");
            ids.Add("0x014e", "NumberOfInks");
            ids.Add("0x0150", "DotRange");
            ids.Add("0x0151", "TargetPrinter");
            ids.Add("0x0152", "ExtraSamples");
            ids.Add("0x0153", "SampleFormat");
            ids.Add("0x0154", "SMinSampleValue");
            ids.Add("0x0155", "SMaxSampleValue");
            ids.Add("0x0156", "TransferRange");
            ids.Add("0x0200", "JPEGProc");
            ids.Add("0x0201", "JPEGInterFormat");
            ids.Add("0x0202", "JPEGInterLength");
            ids.Add("0x0203", "JPEGRestartInterval");
            ids.Add("0x0205", "JPEGLosslessPredictors");
            ids.Add("0x0206", "JPEGPointTransforms");
            ids.Add("0x0207", "JPEGQTables");
            ids.Add("0x0208", "JPEGDCTables");
            ids.Add("0x0209", "JPEGACTables");
            ids.Add("0x0211", "YCbCrCoefficients");
            ids.Add("0x0212", "YCbCrSubsampling");
            ids.Add("0x0213", "YCbCrPositioning");
            ids.Add("0x0214", "REFBlackWhite");
            ids.Add("0x0301", "Gamma");
            ids.Add("0x0302", "ICCProfileDescriptor");
            ids.Add("0x0303", "SRGBRenderingIntent");
            ids.Add("0x0320", "ImageTitle");
            ids.Add("0x5001", "ResolutionXUnit");
            ids.Add("0x5002", "ResolutionYUnit");
            ids.Add("0x5003", "ResolutionXLengthUnit");
            ids.Add("0x5004", "ResolutionYLengthUnit");
            ids.Add("0x5005", "PrintFlags");
            ids.Add("0x5006", "PrintFlagsVersion");
            ids.Add("0x5007", "PrintFlagsCrop");
            ids.Add("0x5008", "PrintFlagsBleedWidth");
            ids.Add("0x5009", "PrintFlagsBleedWidthScale");
            ids.Add("0x500a", "HalftoneLPI");
            ids.Add("0x500b", "HalftoneLPIUnit");
            ids.Add("0x500c", "HalftoneDegree");
            ids.Add("0x500d", "HalftoneShape");
            ids.Add("0x500e", "HalftoneMisc");
            ids.Add("0x500f", "HalftoneScreen");
            ids.Add("0x5010", "JPEGQuality");
            ids.Add("0x5011", "GridSize");
            ids.Add("0x5012", "ThumbnailFormat");
            ids.Add("0x5013", "ThumbnailWidth");
            ids.Add("0x5014", "ThumbnailHeight");
            ids.Add("0x5015", "ThumbnailColorDepth");
            ids.Add("0x5016", "ThumbnailPlanes");
            ids.Add("0x5017", "ThumbnailRawBytes");
            ids.Add("0x5018", "ThumbnailSize");
            ids.Add("0x5019", "ThumbnailCompressedSize");
            ids.Add("0x501a", "ColorTransferFunction");
            ids.Add("0x501b", "ThumbnailData");
            ids.Add("0x5020", "ThumbnailImageWidth");
            ids.Add("0x5021", "ThumbnailImageHeight");
            ids.Add("0x5022", "ThumbnailBitsPerSample");
            ids.Add("0x5023", "ThumbnailCompression");
            ids.Add("0x5024", "ThumbnailPhotometricInterp");
            ids.Add("0x5025", "ThumbnailImageDescription");
            ids.Add("0x5026", "ThumbnailEquipMake");
            ids.Add("0x5027", "ThumbnailEquipModel");
            ids.Add("0x5028", "ThumbnailStripOffsets");
            ids.Add("0x5029", "ThumbnailOrientation");
            ids.Add("0x502a", "ThumbnailSamplesPerPixel");
            ids.Add("0x502b", "ThumbnailRowsPerStrip");
            ids.Add("0x502c", "ThumbnailStripBytesCount");
            ids.Add("0x502d", "ThumbnailResolutionX");
            ids.Add("0x502e", "ThumbnailResolutionY");
            ids.Add("0x502f", "ThumbnailPlanarConfig");
            ids.Add("0x5030", "ThumbnailResolutionUnit");
            ids.Add("0x5031", "ThumbnailTransferFunction");
            ids.Add("0x5032", "ThumbnailSoftwareUsed");
            ids.Add("0x5033", "ThumbnailDateTime");
            ids.Add("0x5034", "ThumbnailArtist");
            ids.Add("0x5035", "ThumbnailWhitePoint");
            ids.Add("0x5036", "ThumbnailPrimaryChromaticities");
            ids.Add("0x5037", "ThumbnailYCbCrCoefficients");
            ids.Add("0x5038", "ThumbnailYCbCrSubsampling");
            ids.Add("0x5039", "ThumbnailYCbCrPositioning");
            ids.Add("0x503a", "ThumbnailRefBlackWhite");
            ids.Add("0x503b", "ThumbnailCopyRight");
            ids.Add("0x5041", "InteroperabilityIndex");
            ids.Add("0x5042", "ExifInteroperabilityVersion");
            ids.Add("0x5090", "LuminanceTable");
            ids.Add("0x5091", "ChrominanceTable");
            ids.Add("0x5100", "FrameDelay");
            ids.Add("0x5101", "LoopCount");
            ids.Add("0x5102", "GlobalPalette");
            ids.Add("0x5103", "IndexBackground");
            ids.Add("0x5104", "IndexTransparent");
            ids.Add("0x5110", "PixelUnit");
            ids.Add("0x5111", "PixelPerUnitX");
            ids.Add("0x5112", "PixelPerUnitY");
            ids.Add("0x5113", "PaletteHistogram");
            ids.Add("0x8298", "Copyright");
            ids.Add("0x829a", "ExifExposureTime");
            ids.Add("0x829d", "ExifFNumber");
            ids.Add("0x8769", "ExifIFD");
            ids.Add("0x8773", "ICCProfile");
            ids.Add("0x8822", "ExifExposureProg");
            ids.Add("0x8824", "ExifSpectralSense");
            ids.Add("0x8825", "GPS IFD");
            ids.Add("0x8827", "ExifISOSpeed");
            ids.Add("0x8828", "ExifOECF");
            ids.Add("0x9000", "ExifVer");
            ids.Add("0x9003", "ExifDTOrig");
            ids.Add("0x9004", "ExifDTDigitized");
            ids.Add("0x9101", "ExifCompConfig");
            ids.Add("0x9102", "ExifCompBPP");
            ids.Add("0x9201", "ExifShutterSpeed");
            ids.Add("0x9202", "ExifAperture");
            ids.Add("0x9203", "ExifBrightness");
            ids.Add("0x9204", "ExifExposureBias");
            ids.Add("0x9205", "ExifMaxAperture");
            ids.Add("0x9206", "ExifSubjectDist");
            ids.Add("0x9207", "ExifMeteringMode");
            ids.Add("0x9208", "ExifLightSource");
            ids.Add("0x9209", "ExifFlash");
            ids.Add("0x920a", "ExifFocalLength");
            ids.Add("0x927c", "ExifMakerNote");
            ids.Add("0x9286", "ExifUserComment");
            ids.Add("0x9290", "ExifDTSubsec");
            ids.Add("0x9291", "ExifDTOrigSS");
            ids.Add("0x9292", "ExifDTDigSS");
            ids.Add("0xa000", "ExifFPXVer");
            ids.Add("0xa001", "ExifColorSpace");
            ids.Add("0xa002", "ExifPixXDim");
            ids.Add("0xa003", "ExifPixYDim");
            ids.Add("0xa004", "ExifRelatedWav");
            ids.Add("0xa005", "ExifInterop");
            ids.Add("0xa20b", "ExifFlashEnergy");
            ids.Add("0xa20c", "ExifSpatialFR");
            ids.Add("0xa20e", "ExifFocalXRes");
            ids.Add("0xa20f", "ExifFocalYRes");
            ids.Add("0xa210", "ExifFocalResUnit");
            ids.Add("0xa214", "ExifSubjectLoc");
            ids.Add("0xa215", "ExifExposureIndex");
            ids.Add("0xa217", "ExifSensingMethod");
            ids.Add("0xa300", "ExifFileSource");
            ids.Add("0xa301", "ExifSceneType");
            ids.Add("0xa302", "ExifCfaPattern");
            ids.Add("0xa402", "ExposureMode");
            ids.Add("0xa403", "WhiteBalance");
            ids.Add("0xa404", "DigitalZoomRatio");
            ids.Add("0xa405", "FocalLengthIn35mmFilm");
            ids.Add("0xa406", "SceneCaptureType");
            ids.Add("0xa407", "GainControl");
            ids.Add("0xa408", "Contrast");
            ids.Add("0xa409", "Saturation");
            ids.Add("0xa40a", "Sharpness");
            ids.Add("0xa40c", "SubjectDistanceRange");

            if (ids.TryGetValue(id.ToLower(), out Readable))
            {
                //
            }
            else
            {
                Readable = id;
            }
        }
    }

    public class Fraction
    {
        private Int32 _numer;
        private Int32 _denom;

        public Fraction(Int32 numer, Int32 denom)
        {
            _numer = numer;
            _denom = denom;
        }

        /// <summary>
        /// Converts the signed numerator and denominator values
        /// to its equivalent string representation.
        /// A fraction (x/y) is returned when applicable.</summary>
        public override string ToString()
        {
            Int32 numer = _numer;
            Int32 denom = (_denom == 0) ? 1 : _denom;

            // Make the numerator "store" the sign
            if (denom < 0)
            {
                numer = numer * -1;
                denom = denom * -1;
            }

            Reduce(ref numer, ref denom);

            string result;
            if (numer == 0)
                result = "0";
            else if (denom == 1)
                result = numer + "";
            else
                result = numer + "/" + denom;

            return result;
        }

        /// <summary>
        /// Reduces the rational number by dividing both the numerator
        /// and the denominator by their greatest common divisor.</summary>
        private static void Reduce(ref Int32 numer, ref Int32 denom)
        {
            if (numer != 0)
            {
                Int32 common = GCD(Math.Abs(numer), denom);

                numer = numer / common;
                denom = denom / common;
            }
        }

        /// <summary>
        /// Computes and returns the greatest common divisor of the two
        /// positive parameters. Uses Euclid's algorithm.</summary>
        private static Int32 GCD(Int32 num1, Int32 num2)
        {
            while (num1 != num2)
                if (num1 > num2)
                    num1 = num1 - num2;
                else
                    num2 = num2 - num1;

            return num1;
        }
    }

    public class UFraction
    {
        private UInt32 _numer;
        private UInt32 _denom;

        public UFraction(UInt32 numer, UInt32 denom)
        {
            _numer = numer;
            _denom = denom;
        }

        /// <summary>
        /// Converts the unsigned numerator and denominator values
        /// to its equivalent string representation.
        /// A fraction is used when applicable.</summary>
        public override string ToString()
        {
            UInt32 numer = _numer;
            UInt32 denom = (_denom == 0) ? 1 : _denom;

            Reduce(ref numer, ref denom);

            string result;
            if (numer == 0)
                result = "0";
            else if (denom == 1)
                result = numer + "";
            else
                result = numer + "/" + denom;

            return result;
        }

        /// <summary>
        /// Reduces the rational number by dividing both the numerator
        /// and the denominator by their greatest common divisor.</summary>
        private static void Reduce(ref UInt32 numer, ref UInt32 denom)
        {
            if (numer != 0)
            {
                UInt32 common = GCD(numer, denom);

                numer = numer / common;
                denom = denom / common;
            }
        }

        /// <summary>
        /// Computes and returns the greatest common divisor of the two
        /// positive parameters. Uses Euclid's algorithm.</summary>
        private static UInt32 GCD(UInt32 num1, UInt32 num2)
        {
            while (num1 != num2)
                if (num1 > num2)
                    num1 = num1 - num2;
                else
                    num2 = num2 - num1;

            return num1;
        }
    }

    public class Sorter : System.Collections.IComparer
    {
        public int Compare(object x, object y)
        {
            TreeNode tx = x as TreeNode;
            TreeNode ty = y as TreeNode;

            // If this is a child node, preserve the same order by comparing the node Index, not the text
            if (tx.Parent != null && ty.Parent != null)
                return tx.Index - ty.Index;

            // This is a root node, compare by name.
            return string.Compare(tx.Text, ty.Text);
        }
    }
}
