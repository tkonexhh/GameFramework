using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

public class AudioDemo : MonoBehaviour
{
    [SerializeField]
    AudioClip m_MainClip;

    [SerializeField]
    AudioClip m_SoundClip;
    void Start()
    {
        //AudioMgr.S.PlayBg(m_MainClip);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            AudioMgr.S.PlaySound(m_MainClip);
        }


    }
}
