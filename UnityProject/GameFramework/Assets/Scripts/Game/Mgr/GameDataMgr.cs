using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

namespace Main.Game
{

    public class GameDataMgr : DataClassHandler<GameData>
    {
        public static DataDirtyRecorder dataDirtyRecorder = new DataDirtyRecorder();

        public GameDataMgr()
        {
            Load();
        }

    }
}
