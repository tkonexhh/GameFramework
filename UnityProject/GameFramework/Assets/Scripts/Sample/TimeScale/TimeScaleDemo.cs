using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GFrame.Sample
{

    public class TimeScaleDemo : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                TimeScaleHelper.ShootPause(0.7f);
            }

            if (Input.GetKeyDown(KeyCode.F2))
            {
                TimeScaleHelper.ShootPause(0.2f);
            }
        }
    }
}




