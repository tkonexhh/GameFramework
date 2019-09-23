using System.IO;

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


        // 上一级目录
        public static string GetParentDir(string dir, int floor = 1)
        {
            string subDir = dir;

            for (int i = 0; i < floor; ++i)
            {
                int last = subDir.LastIndexOf('/');
                subDir = subDir.Substring(0, last);
            }

            return subDir;
        }

        #endregion
    }
}




