using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

public class Demo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Timer.S.Post2Scale((int i) =>
        {
            var resloader = ResLoader.Allocate();
            var obj = resloader.LoadSync(NetImgRes.PREFIX_KEY + "https://upload.jianshu.io/users/upload_avatars/5919334/bbccebb8-13d8-4b29-8949-df2e3cfd2635.jpg?imageMogr2/auto-orient/strip|imageView2/1/w/90/h/90/format/webp");
            Debug.LogError(obj);
        }, 2.0f);


        ReflectionHelper.Invoke(this, this.GetType(), "DE");
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
