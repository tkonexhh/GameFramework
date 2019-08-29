using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GFrame
{

    public class RecordMOno : MonoBehaviour
    {
        PlayerInfoMgr infoMgr;
        private void Awake()
        {
            infoMgr = new PlayerInfoMgr();
        }


        private void Update()
        {

            if (Input.GetKeyDown(KeyCode.W))
            {
                PlayerInfoMgr.Save();
            }
        }
    }
}




