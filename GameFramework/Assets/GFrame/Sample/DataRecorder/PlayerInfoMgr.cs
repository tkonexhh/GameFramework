using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GFrame
{

    public class PlayerInfoMgr : DataClassHandler<GameData>
    {
        public static DataDirtyRecorder dataDirtyRecorder = new DataDirtyRecorder();

        public PlayerInfoMgr()
        {
            SetFileNameKey("PlayerInfo");
            Load();
            EnableAutoSave();

        }
    }



}




