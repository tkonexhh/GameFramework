using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Demo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.LogError(Application.dataPath);
        Debug.LogError(Application.persistentDataPath);
        Debug.LogError(Application.streamingAssetsPath);
        Debug.LogError(Application.temporaryCachePath);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
