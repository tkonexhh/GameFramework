using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GFrame
{

    public interface IResLoader
    {
        bool Add2Load(string name);
        void ReleaseAllRes();
    }
}




