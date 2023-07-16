using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TOUCH
{
    public class SystemPlaySE : SingletonMonoBehaviour<SystemPlaySE>
    {
        private AudioSource m_AudioSource;
        
        public Dictionary<string, AudioClip> SystemSound = new Dictionary<string, AudioClip>();

        public AudioSource SfxItemTemp;
        public Dictionary<string, AudioSource> SingleSfxList = new Dictionary<string, AudioSource>();

        void Start()
        {
            m_AudioSource = GetComponent<AudioSource>();
        }

        // //用于播放没有限制的音效
        // public void PlaySound(AudioClip _sound)
        // {
        //     m_AudioSource.PlayOneShot(_sound,m_AudioSource.volume);
        // }

        //用于播放系统音效
        public void PlaySystemSound(string _key)
        {
            var _sound = SystemSound[_key];
            if (_sound != null)
            {
                m_AudioSource.PlayOneShot(_sound);
            }
        }

        //用于播放只能同时存在一个的音效,用音频的名称做索引
        public void PlaySingleSound(AudioClip _clip)
        {
            if (SingleSfxList.ContainsKey(_clip.name))
            {
                var _AudioClip = SingleSfxList[_clip.name];
                    _AudioClip.clip = _clip;
                    _AudioClip.Play();
            }
            else
            {
                var _AudioClip = Instantiate(SfxItemTemp, transform);
                    _AudioClip.clip = _clip;
                    _AudioClip.volume = m_AudioSource.volume;
                    _AudioClip.Play();
                
                SingleSfxList.Add(_clip.name,_AudioClip);
            }
        }
    }
}
