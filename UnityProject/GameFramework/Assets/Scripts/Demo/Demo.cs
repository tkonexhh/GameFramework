using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

namespace Main.Game
{


    public class Demo : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            var s = new GameDataMgr();
            GameDataMgr.Save();

        }

        // Update is called once per frame
        void Update()
        {

        }


        public void DE()
        {
            Debug.LogError("asdasdasd");
        }
    }
}
