using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

namespace TOUCH
{
    public class GameContrl_4 : SerializedMonoBehaviour
    {
        public Animator back;

        public GameObject showNpc1;
        public GameObject showNpc2;
        
        public Animator anim;
        public bool animPlay;
        public bool animPlayEnd;

        public void GameStart()
        {
            GameRoot.Instance.Player.GetComponent<playerContrl>().canMove = false;
            // GameEnd();
        }

        private void Update()
        {
            if (animPlay && animPlayEnd == false)
            {
                var info = anim.GetCurrentAnimatorStateInfo(0);
                if (info.normalizedTime >= 1) // 判断动画播放结束normalizedTime的值为0~1，0为开始，1为结束。
                {
                    animEnd();
                    animPlayEnd = true;
                }
            }
        }
        
        public void animEnd()
        {
            // back.Play("PuzzleEnd");
            // foreach (var _item in PuzzleItemList)
            // {
            //     _item.Play("PuzzleEnd");
            // }
            StartCoroutine(end());
        }

        public void GameEnd()
        {
            animPlay = true;
            anim.gameObject.SetActive(true);
            // back.Play("PuzzleEnd");
            // SystemPlaySE.Instance.PlaySingleSound(GameRoot.Instance.GameSuccessfulSe);
            // foreach (var _item in PuzzleItemList)
            // {
            //     _item.Play("PuzzleEnd");
            // }
            // StartCoroutine(end());
        }

        IEnumerator end()
        {
            yield return new WaitForSeconds(0.2f);
            var _player = GameRoot.Instance.Player.GetComponent<playerContrl>();
            _player.canMove = true;
            _player.skeletonChange();
            
            showNpc1.SetActive(false);
            showNpc2.SetActive(true);
            
            Destroy(gameObject);
            yield return null;
        }
    }
}