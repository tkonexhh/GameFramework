using System.IO;

namespace GFrame
{

    public class IO
    {
        public static void CheckDirAndCreate(string dirPath)
        {
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
        }
    }
}




