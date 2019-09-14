using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Demo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var str = DateTime.Now.ToShortDateString();
        Debug.LogError(str);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
