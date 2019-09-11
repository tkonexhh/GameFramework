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
    }
}




