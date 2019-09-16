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

        public static void GetFileInInner(string path, List<string> result)
        {
            FilePath.GetFileInFolder(FilePath.streamingAssetsPath, path, result);
        }


    }
}




