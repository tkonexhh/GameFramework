using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

public class MirrorTest : MonoBehaviour

{
    [SerializeField] MirrorImage img;

    // Start is called before the first frame update
    void Start()
    {
        img.SetNativeSize();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
