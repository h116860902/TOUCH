using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TOUCH
{
    /// <summary>
    /// 控制粒子效果播放结束后的回调，现在主要用于池子中攻击特效的回收
    /// </summary>
    public class PSEffectBase : MonoBehaviour
    {
        // [Tooltip("出现时播放音效")]
        // public AudioClip EffectSe;
        
        // Action deactivateAction;
        // public void SetDeactivateAction(Action deactivateAction)
        // {
        //     this.deactivateAction = deactivateAction;
        // }
        
        void Start()
        {
            SystemPlaySE.Instance.PlaySingleSound(GameRoot.Instance.GameSuccessfulSe);
            //这里是开启粒子系统结束的回调功能，并结束重复播放
            ParticleSystem particle = GetComponent<ParticleSystem>();
            ParticleSystem.MainModule mainModule = particle.main;
            mainModule.loop = false;
            mainModule.stopAction = ParticleSystemStopAction.Callback;
        }
        
        //粒子系统结束时的回调
        void OnParticleSystemStopped()
        {
            // Debug.Log("特效消失"+this);
            if (gameObject.activeSelf)
            {
                Destroy(gameObject);
            }
        }
    }
}