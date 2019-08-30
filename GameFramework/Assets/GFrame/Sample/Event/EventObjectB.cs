using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GFrame.Sample
{

    public class EventObjectB : MonoBehaviour
    {
        private void Awake()
        {
            EventSystem.S.Register(1, OnEvent);
        }

        void OnEvent(int key, params object[] args)
        {
            Debug.LogError(args[0]);
        }

    }
}




