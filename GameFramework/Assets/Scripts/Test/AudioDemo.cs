using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

public class AudioDemo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            AudioMgr.S.PlaySound();
        }
    }
}
