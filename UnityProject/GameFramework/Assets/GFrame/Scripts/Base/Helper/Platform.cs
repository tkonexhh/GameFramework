using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace GFrame
{

    public class Platform
    {
        public static bool IsAndroid
        {
            get
            {
                bool value = false;
#if UNITY_ANDROID
                value = true;
#endif
                return value;
            }
        }

        public static bool IsEditor
        {
            get
            {
                bool value = false;
#if UNITY_EDITOR
                value = true;
#endif
                return value;
            }
        }

        public static bool IsIOS
        {
            get
            {
                bool value = false;
#if UNITY_IOS
                value = true;
#endif
                return value;
            }
        }


        private static bool IsLinuxSystem()
        {
            PlatformID platformID = System.Environment.OSVersion.Platform;

            if (platformID == PlatformID.MacOSX || platformID == PlatformID.Unix)
            {
                return true;
            }

            return false;
        }
    }
}




