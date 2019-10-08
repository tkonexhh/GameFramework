using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

namespace Main.Game
{
    public class GameData : IDataClass
    {
        public int m_Score;

        public GameData()
        {
            SetDirtyRecorder(GameDataMgr.dataDirtyRecorder);
        }

        public override void InitWithEmptyData()
        {

        }

        public override void OnDataLoadFinish()
        {

        }
    }
}
