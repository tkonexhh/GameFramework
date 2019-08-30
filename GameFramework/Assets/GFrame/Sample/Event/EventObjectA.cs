using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GFrame.Sample
{

    public class EventObjectA : MonoBehaviour
    {
        private void Awake()
        {

        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                EventSystem.S.Send(1, 22222);
            }
        }
    }
}




