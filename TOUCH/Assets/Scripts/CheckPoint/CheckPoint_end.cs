using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TOUCH
{
    public class CheckPoint_end : CheckPointBase
    {
        private bool isExecute;
        
        public AudioClip EffectSe;
        
        public override void execute()
        {
            if (!isExecute)
            {
                if (EffectSe != null)
                {
                    SystemPlaySE.Instance.PlaySingleSound(EffectSe);
                }
                
                GameRoot.Instance.ChangeRoom("End");
                isExecute = true;
            }
        }
    }
}