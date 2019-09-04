using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerPrefTools
{
    [MenuItem("PlayerPref Tools/Clear Saved Data")]
	static public void ClearSavedData()
    {
        PlayerPrefs.DeleteAll();
    }
}
