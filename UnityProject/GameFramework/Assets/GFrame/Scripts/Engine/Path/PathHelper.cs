using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GFrame
{

    public class PathHelper
    {
        ///无后缀的文件名
        public static string FileNameWithoutExtend(string name)
        {
            if (name == null)
                return null;

            int endIndex = name.LastIndexOf('.');
            if (endIndex > 0)
            {
                return name.Substring(0, endIndex);
            }

            return name;
        }

        //根据路径获取文件名字
        public static string Path2Name(string path)
        {
            int startIndex = path.LastIndexOf("/") + 1;
            int endIndex = path.LastIndexOf(".");
            if (endIndex > 0)
            {
                int length = endIndex - startIndex;
                return path.Substring(startIndex, length).ToLower();
            }
            return path.Substring(startIndex).ToLower();
        }
    }
}




