using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TOUCH
{
    public class SystemPlayBgm : SingletonMonoBehaviour<SystemPlayBgm>
    {
        public AudioSource m_AudioSource;
        public AudioClip m_Bgm;

        void Start()
        {
            m_AudioSource = GetComponent<AudioSource>();
            PlaySound(m_Bgm);
        }

        public void PlaySound(AudioClip _sound)
        {
            m_AudioSource.clip = _sound;
            m_AudioSource.loop = true;
            m_AudioSource.Play();
        }
    }
}
