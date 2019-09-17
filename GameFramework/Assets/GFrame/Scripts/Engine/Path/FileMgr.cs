using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace GFrame
{

    public class FileMgr : TSingleton<FileMgr>
    {
        public override void OnSingletonInit()
        {

        }

        public void GetFileInInner(string fileName, List<string> result)
        {
            GetFileInFolder(FilePath.streamingAssetsPath4AB, fileName, result);
        }

        public static void GetFileInFolder(string dirName, string fileName, List<string> outResult)
        {
            if (outResult == null)
            {
                return;
            }


            DirectoryInfo directory = new DirectoryInfo(dirName);
            //if(directory.Parent!=null)

            FileInfo[] files = directory.GetFiles();
            string fname = string.Empty;
            for (int i = 0; i < files.Length; i++)
            {
                fname = files[i].Name;
                if (fname == fileName)
                {
                    outResult.Add(files[i].FullName);
                }
            }

        }

        public Stream OpenReadStream(string absFilePath)
        {
            if (string.IsNullOrEmpty(absFilePath))
            {
                return null;
            }

            FileInfo fileInfo = new FileInfo(absFilePath);
            if (!fileInfo.Exists)
            {
                return null;
            }

            return fileInfo.OpenRead();
        }
    }
}




