using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

public class ObjectPoolDemo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ObjectPool<TestObject>.S.Init(10, 5);
        Log.e(ObjectPool<TestObject>.S.currentCount);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

public class TestObject
{

}
