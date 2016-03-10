using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODBLib.Configure
{
    class Settings
    {
        private string _rootPath;
        private string _fileSettingName;
        private string _fullFileName;
        private string _connectionString;
        public static string DefaultConnectionString = "";

        public string RootPath
        {
            get { return _rootPath; }
        }

        public string FullFileName
        {
            get { return _fullFileName; }
        }

        public string FileSettingName
        {
            get { return _fileSettingName; }
        }

        public string ConnectionString
        {
            get { return _connectionString; }
        }

        private static Settings _instance = new Settings();

        public static Settings Instance
        {
            get { return _instance; }
        }

        public void Log(String message)
        {
            
        }
    }
}
