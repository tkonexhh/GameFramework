using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

namespace Main.Game
{

    public class InputModule : AbstractInputModule
    {
        protected override void RegisterKeyboard()
        {
            m_KeyBoardInputer.RegisterKeyCodeMonitor(KeyCode.F1, OnClickF1, OnPressF1, OnEndF1);
            m_KeyBoardInputer.RegisterShortcuts(new KeyCode[] { KeyCode.Q, KeyCode.W }, OnEndF1);
            m_KeyBoardInputer.RegisterKeyCodeQueue(new KeyCode[] { KeyCode.Q, KeyCode.W, KeyCode.E, KeyCode.R }, OnPressF1);
        }

        private void OnClickF1()
        {
            Log.e("OnClickF1");
        }

        private void OnPressF1()
        {
            Log.e("OnPressF1");
        }

        private void OnEndF1()
        {
            Log.e("OnEndF1");
        }
    }
}




