﻿using System.Collections;
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
                Debug.LogError(1111 + PlayerInfoMgr.data.ToString());
                PlayerInfoMgr.Save();
            }
        }
    }
}




