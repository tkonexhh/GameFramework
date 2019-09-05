using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;

namespace GFrame.UnityEditor
{
    public class PlayerPrefTools
    {
        [MenuItem("Custom/PlayerData Tools/Clear All Saved Data")]
        static public void ClearSavedData()
        {
            PlayerPrefs.DeleteAll();
            DirectoryInfo forder = new DirectoryInfo(FilePath.persistentDataPath4Recorder);
            forder.Delete(true);
        }


    }
}
