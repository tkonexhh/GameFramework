using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

public class Demo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var type = ReflectionHelper.GetType(this.GetType().ToString());
        Debug.LogError(type);


    }

    // Update is called once per frame
    void Update()
    {

    }


    public void DE()
    {
        Debug.LogError("asdasdasd");
    }
}
