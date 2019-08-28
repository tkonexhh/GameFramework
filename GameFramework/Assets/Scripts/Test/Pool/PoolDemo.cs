using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

public class PoolDemo : MonoBehaviour
{
    [SerializeField] GameObject m_Prefeb;
    void Start()
    {
        var pool = GameObjectPoolMgr.S.AddPool("Prefeb", m_Prefeb, 10, 5);

        for (int i = 0; i < 2; i++)
        {
            var go = pool.Allocate();
            go.transform.SetParent(transform);
        }
        Log.i("1");
        Log.w("2");
        Log.e("3");
        GameObjectPoolMgr.S.RemovePool("Prefeb");
    }


}
