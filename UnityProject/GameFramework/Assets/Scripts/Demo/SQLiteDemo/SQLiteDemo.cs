using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

public class SQLiteDemo : MonoBehaviour
{
    void Start()
    {
        string table = "Test";
        // SqliteMgr.S.Init();
        // TestClass data = new TestClass();//(1, 20, 20);
        // data.ID = 1;
        // data.Name1 = 10;
        // data.Name2 = 20;
        // SqliteMgr.S.Insert(table, data);
        // List<TestClass> s = SqliteMgr.S.ReadTableData<TestClass>(table);
        // for (int i = 0; i < s.Count; i++)
        // {
        //     Debug.LogError(s[i].ID);
        // }

        //SqliteMgr.S.UpdateData(table, 1);

    }

}

public class TestClass : AbstractSqliteDataClass
{
    public int ID;
    public int Name1;
    public int Name2;

    // public TestClass(int ID, int Name1, int Name2)
    // {
    //     this.ID = ID;
    //     this.Name1 = Name1;
    //     this.Name2 = Name2;
    // }
}
