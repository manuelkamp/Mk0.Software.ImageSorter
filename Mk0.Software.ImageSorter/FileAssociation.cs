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

        public static void Remove(string progId)
        {
            bool madeChanges = false;
            madeChanges |= RemoveAssociation(progId);

            if (madeChanges)
            {
                SHChangeNotify(SHCNE_ASSOCCHANGED, SHCNF_FLUSH, IntPtr.Zero, IntPtr.Zero);
            }
        }

        public static bool Check(string progId, string applicationFilePath, string fileTypeDescription, string iconPath)
        {
            bool exists = false;
            exists |= CheckAssociation(progId, applicationFilePath, fileTypeDescription, iconPath);
            return exists;
        }

        private static bool SetAssociation(string extension, string progId, string fileTypeDescription, string applicationFilePath, string iconPath)
        {
            bool madeChanges = false;
            madeChanges |= SetKeyDefaultValue(@"Software\Classes\" + extension, progId);
            madeChanges |= SetKeyDefaultValue(@"Software\Classes\" + progId, fileTypeDescription);
            madeChanges |= SetKeyDefaultValue($@"Software\Classes\{progId}\shell\open\command", "\"" + applicationFilePath + "\" \"%1\"");
            madeChanges |= SetKeyDefaultValue($@"Software\Classes\{progId}\DefaultIcon", "\"" + iconPath + "\"");
            return madeChanges;
        }

        private static bool RemoveAssociation(string progId)
        {
            bool madeChanges = false;
            madeChanges |= DeleteKeyDefaultValue($@"Software\Classes\", progId);
            return madeChanges;
        }

        private static bool CheckAssociation(string progId, string applicationFilePath, string fileTypeDescription, string iconPath)
        {
            bool exists = false;
            exists |= CheckKeyDefaultValue($@"Software\Classes\{progId}\shell\open\command", "\"" + applicationFilePath + "\" \"%1\"");
            return exists;
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

        private static bool DeleteKeyDefaultValue(string keyPath, string value)
        {
            bool erfolg = false;
            using (var key = Registry.CurrentUser.OpenSubKey(keyPath, writable: true))
            {
                if (key != null)
                {
                    key.DeleteSubKeyTree(value, false);
                    erfolg = true;
                }
            }

            return erfolg;
        }

        private static bool CheckKeyDefaultValue(string keyPath, string value)
        {
            bool exists = false;
            using (var key = Registry.CurrentUser.OpenSubKey(keyPath, writable: true))
            {
                if (key != null)
                {
                    string x = (string)key.GetValue("");
                    if (!string.IsNullOrEmpty(x) && x == value)
                    {
                        exists = true;
                    }
                }
            }

            return exists;
        }
    }
}
