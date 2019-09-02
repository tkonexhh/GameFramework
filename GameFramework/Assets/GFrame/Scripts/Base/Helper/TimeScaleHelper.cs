using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GFrame
{

    public class TimeScaleHelper
    {
        private static float m_ScaleDefault = 1.0f;
        public static void SetTimerScale(float scale)
        {
            Time.timeScale = scale;
        }

        //短暂的暂停,然后在回复
        public static void ShootPause(float time)
        {
            SetTimerScale(0);
            Timer.S.Post2Scale((int i) => { SetTimerScale(m_ScaleDefault); }, time);
        }


    }
}




