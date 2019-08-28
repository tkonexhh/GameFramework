using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GFrame
{

    public static class GameObjectExtension
    {
        public static void DestroySelf(this GameObject go)
        {
            GameObject.Destroy(go);
        }

        // public static GameObject SetActive(this GameObject go, bool enable)
        // {
        //     go.SetActive(enable);
        //     return go;
        // }


    }
}




