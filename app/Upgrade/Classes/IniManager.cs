using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Upgrade
{
    class INIManager
    {
        private static string Path;
        private static string EXE = Assembly.GetExecutingAssembly().GetName().Name;

        [DllImport("kernel32", CharSet = CharSet.Auto)]
        static extern int WritePrivateProfileString(string Section, string Key, string Value, string FilePath);

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1060:MovePInvokesToNativeMethodsClass")]
        [DllImport("kernel32", CharSet = CharSet.Auto)]
        static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);

        public static void SetFile(string IniPath = null)
        {
            Path = new FileInfo(IniPath ?? EXE + ".ini").FullName.ToString();
        }

        public static string Read(string Section, string Key)
        {
            var RetVal = new StringBuilder(255);
            GetPrivateProfileString(Section ?? EXE, Key, "", RetVal, 255, Path);
            return RetVal.ToString();
        }

        public static void WriteString(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section ?? EXE, Key, Value, Path);
        }

        public static void WriteInt(string Section, string Key, int Value)
        {
            WritePrivateProfileString(Section ?? EXE, Key, Convert.ToString(Value), Path);
        }

        public static void DeleteSection(string Section = null)
        {
            WriteString(Section ?? EXE, null, null);
        }

        public static void DeleteKey(string Section, string Key)
        {
            WriteString(Section ?? EXE, Key, null);
        }

        public static bool KeyExists(string Section, string Key)
        {
            return Read(Section, Key).Length > 0;
        }
    }
}
