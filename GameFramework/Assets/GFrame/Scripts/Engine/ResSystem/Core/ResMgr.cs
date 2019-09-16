using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GFrame
{

    public class ResMgr : TMonoSingleton<ResMgr>
    {

        private Dictionary<string, IRes> m_ResMap = new Dictionary<string, IRes>();
        private List<IRes> m_ResList = new List<IRes>();


        public int totalResCount
        {
            get { return m_ResList.Count; }
        }


        public override void OnSingletonInit()
        {

        }


        public void InitResMgr()
        {
            Log.i("#Init[ResMgr]");
            ReloadABTable();
        }

        private void ReloadABTable()
        {
            AssetDataTable.S.Reset();
            List<string> outResult = new List<string>();

            //FileMgr.S.GetFileInInner(ProjectPathConfig.abRelativePath, outResult);


            //FilePath.GetFileInFolder(FilePath.persistentDataPath4Recorder);
        }
    }
}




