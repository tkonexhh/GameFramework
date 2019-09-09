using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GFrame.Sample
{

    public class InputModule : AbstractInputModule
    {
        protected override void RegisterKeyboard()
        {
            m_KeyBoardInputer.RegisterKeyCodeMonitor(KeyCode.F1, OnClickF1, OnPressF1, OnPressF1);
            m_KeyBoardInputer.RegisterShortcuts(new KeyCode[] { KeyCode.Q, KeyCode.W }, OnPressF1);
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


        public int[] TwoSum(int[] nums, int target)
        {

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {

                    if (nums[i] + nums[j] == target)
                    {
                        return new int[] { i, j };
                    }
                }
            }

            return null;
        }
    }
}




