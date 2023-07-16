using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

namespace TOUCH
{
    public class GameContrl_1 : SerializedMonoBehaviour
    {
        private bool gameEnd = false;

        public Animator back;

        public List<Game1_Npc> npcList;
        
        public List<GameObject> showNpcList;
        public GameObject showNpc;

        public Animator anim;
        public bool animPlay;
        public bool animPlayEnd;

        public float timer = 1;
        public bool gameS = false;

        public void GameStart()
        {
            GameRoot.Instance.Player.GetComponent<playerContrl>().canMove = false;
            // GameEnd();
        }

        private void Update()
        {
            if (!gameS)
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    foreach (var _item in npcList)
                    {
                        _item.GameStart = true;
                    }
                    gameS = true;
                }
            }


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

        public void checkComplete()
        {
            if (gameEnd) return;
            
            var _complete = true;
            foreach (var _item in npcList)
            {
                if (_item.CurrentHp < _item.maxHp)
                {
                    _complete = false;
                }
            }

            if (_complete)
            {
                // Debug.Log("成功");
                // GameEnd();
                gameEnd = true;
                StartCoroutine(GameEnd1());
            }
        }
        
        IEnumerator GameEnd1()
        {
            GameRoot.Instance.Good();
            
            yield return new WaitForSeconds(2f);
            
            GameEnd();
            
            yield return null;
        }

        public void GameEnd()
        {
            // gameEnd = true;
            // SystemPlaySE.Instance.PlaySingleSound(GameRoot.Instance.GameSuccessfulSe);

            animPlay = true;
            anim.gameObject.SetActive(true);
            // foreach (var _item in npcList)
            // {
            //     _item.GetComponent<Animator>().Play("PuzzleEnd");
            // }
            
        }

        public void animEnd()
        {
            back.Play("PuzzleEnd");
            StartCoroutine(end());
        }

        IEnumerator end()
        {
            yield return new WaitForSeconds(0.2f);
            var _player = GameRoot.Instance.Player.GetComponent<playerContrl>();
            _player.canMove = true;
            _player.skeletonChange();

            foreach (var _item in showNpcList)
            {
                _item.SetActive(false);
            }
            showNpc.SetActive(true);
            
            Destroy(gameObject);
            yield return null;
        }
    }
}