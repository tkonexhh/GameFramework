using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GFrame
{

    public class Timer : TMonoSingleton<Timer>
    {
        private float m_CurrentUnScaleTime = -1;
        private float m_CuurentScaleTime = -1;

        public override void OnSingletonInit()
        {
            m_CurrentUnScaleTime = Time.unscaledTime;
            m_CuurentScaleTime = Time.time;
        }
    }
}




