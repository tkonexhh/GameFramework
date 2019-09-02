using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GFrame.Sample
{

    public class TimerDemo : MonoBehaviour
    {

        private void Awake()
        {
            Time.timeScale = 0.5f;
            //Timer.S.Post2Really((int i) => { Log.e("AReally" + i + "--" + Time.unscaledTime); }, 1.0f, 5);
            Timer.S.Post2Really((int i) => { Log.e("BReally" + i + "--" + Time.unscaledTime); }, 1.5f, -1);

            // Timer.S.Post2Scale((int i) => { Log.e("BScale" + i + "--" + Time.time); }, 1.5f, -1);
        }
    }
}




