using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TOUCH
{
    public class CheckPoint_Title : CheckPointBase
    {
        private bool isExecute;

        public SpriteRenderer SpriteRenderer;
        public Sprite Sprite;

        public AudioClip EffectSe;
        
        public override void execute()
        {
            if (!isExecute)
            {
                if (EffectSe != null)
                {
                    SystemPlaySE.Instance.PlaySingleSound(EffectSe);
                }
                SpriteRenderer.sprite = Sprite;
                GameRoot.Instance.Player.canMove = false;
                GameRoot.Instance.ChangeRoom("Scene_1");
                isExecute = true;
            }
        }
    }
}