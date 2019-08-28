using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GFrame
{

    //实现全局音乐播放
    //控制音乐开关
    //控制全局音乐音量
    public class AudioMgr : TMonoSingleton<AudioMgr>
    {
        private const string SOUND_SAVE_KEY = "soundEnable";//0->关 1->开
        private const string MUSIC_SAVE_KEY = "musicEnable";
        private bool m_IsSoundEnable = true;
        private bool m_IsMusicEnable = true;

        public bool IsSoundEnable
        {
            get { return m_IsSoundEnable; }
            set
            {
                if (m_IsSoundEnable == value)
                    return;

                m_IsSoundEnable = value;
                PlayerPrefs.SetInt(SOUND_SAVE_KEY, m_IsSoundEnable ? 1 : 0);

            }
        }

        public bool IsMusicEnable
        {
            get { return m_IsMusicEnable; }
            set
            {
                if (m_IsMusicEnable == value)
                    return;

                m_IsMusicEnable = value;
                PlayerPrefs.SetInt(MUSIC_SAVE_KEY, m_IsMusicEnable ? 1 : 0);

            }
        }

        public override void OnSingletonInit()
        {
            m_IsSoundEnable = PlayerPrefs.GetInt(SOUND_SAVE_KEY, 1) == 1;
            m_IsMusicEnable = PlayerPrefs.GetInt(MUSIC_SAVE_KEY, 1) == 1;
        }
        public void PlaySound()
        {

        }

        public void PlayBg()
        {

        }
    }
}
