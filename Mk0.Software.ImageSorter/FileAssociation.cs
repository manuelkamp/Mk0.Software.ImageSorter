using Microsoft.Win32;
using System;

namespace Mk0.Tools.FileAssociaton
{
    class FileAssociation
    {
        [System.Runtime.InteropServices.DllImport("Shell32.dll")]
        private static extern int SHChangeNotify(int eventId, int flags, IntPtr item1, IntPtr item2);

        private const int SHCNE_ASSOCCHANGED = 0x8000000;
        private const int SHCNF_FLUSH = 0x1000;

        public static void Add(string progId, string extension, string applicationFilePath, string fileTypeDescription, string iconPath)
        {
            bool madeChanges = false;
                madeChanges |= SetAssociation(
                    extension,
                    progId,
                    fileTypeDescription,
                    applicationFilePath,
                    iconPath);

            if (madeChanges)
            {
                SHChangeNotify(SHCNE_ASSOCCHANGED, SHCNF_FLUSH, IntPtr.Zero, IntPtr.Zero);
            }
        }

        public static void Remove(string progId, string extension, string applicationFilePath, string fileTypeDescription, string iconPath)
        {
            //remove reg
        }

        public static void Check(string progId, string extension, string applicationFilePath, string fileTypeDescription, string iconPath)
        {
            //add or update reg
        }

        private static bool SetAssociation(string extension, string progId, string fileTypeDescription, string applicationFilePath, string iconPath)
        {
            //todo add file assoc icon
            bool madeChanges = false;
            madeChanges |= SetKeyDefaultValue(@"Software\Classes\" + extension, progId);
            madeChanges |= SetKeyDefaultValue(@"Software\Classes\" + progId, fileTypeDescription);
            madeChanges |= SetKeyDefaultValue($@"Software\Classes\{progId}\shell\open\command", "\"" + applicationFilePath + "\" \"%1\"");
            madeChanges |= SetKeyDefaultValue($@"Software\Classes\{progId}\DefaultIcon", "\"" + iconPath + "\"");
            return madeChanges;
        }

        private static bool SetKeyDefaultValue(string keyPath, string value)
        {
            using (var key = Registry.CurrentUser.CreateSubKey(keyPath))
            {
                if (key.GetValue(null) as string != value)
                {
                    key.SetValue(null, value);
                    return true;
                }
            }

            return false;
        }
    }
}
