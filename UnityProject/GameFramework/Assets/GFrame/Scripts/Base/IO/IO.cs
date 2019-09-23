using System.IO;
using System.Text;

namespace GFrame
{

    public class IO
    {
        #region File
        public static bool IsFileExist(string filePath)
        {
            return File.Exists(filePath);
        }

        public static bool DelFile(string filePath)
        {
            if (IsFileExist(filePath))
            {
                File.Delete(filePath);
                return true;
            }

            return false;
        }

        #endregion

        #region Directory
        public static bool IsDirExist(string dirPath)
        {
            return Directory.Exists(dirPath);
        }


        public static bool DelDir(string dirPath, bool recursive)
        {
            if (IsDirExist(dirPath))
            {
                Directory.Delete(dirPath, recursive);
                return true;
            }

            return false;
        }

        public static void CheckDirAndCreate(string dirPath)
        {
            if (!IsDirExist(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
        }


        public static void WriteFile(string path, string content)
        {
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
            sw.Write(content);
            sw.Close();
            fs.Close();
        }

        #endregion
    }
}




