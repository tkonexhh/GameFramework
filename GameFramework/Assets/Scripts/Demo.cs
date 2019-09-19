using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GFrame;

public class Demo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        //m_renderer.Clear
        Timer.S.Post2Scale((int i) =>
        {
            var loader = ResLoader.Allocate("Demo");
            var s = loader.LoadSync("bg_main");
            Debug.LogError(s);
            AudioMgr.S.PlayBg(s as AudioClip);
        }, 2.0f);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
