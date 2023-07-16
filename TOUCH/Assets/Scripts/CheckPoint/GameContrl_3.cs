using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Spine.Unity;
using Spine;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

namespace TOUCH
{
    public class GameContrl_3 : SerializedMonoBehaviour
    {
        public Animator back;

        [Header("人物与剧情")]
        public GameObject showNpc1;
        public GameObject showNpc2;
        
        public Animator anim;
        public bool animPlay;
        public bool animPlayEnd;

        // [Header("游戏相关")]
        // // public float carPosLimit = 4.5f;
        private float carDis;
        public Transform car;
        public float carStartPosX;

        private bool gameEnd;
        // private float carTargetX;

        // public float mouseX = 10;//玩家鼠标所在位置

        public SkeletonAnimation skeletonAnimation;
        public Spine.AnimationState spineAnimationState;

        // public float carChangePosTime = 1f;
        // private float timer = 0;

        // public bool gameStart;
        public bool touch;
        public GameObject tip;

        public void GameStart()
        {
            GameRoot.Instance.Player.GetComponent<playerContrl>().canMove = false;
            carStartPosX = car.transform.localPosition.x;
            // gameStart = true;
            skeletonAnimation.timeScale = 0;
            spineAnimationState = skeletonAnimation.AnimationState;
            spineAnimationState.Complete += OnSpineAnimationComplete;
            // GameEnd();
        }

        private void OnSpineAnimationComplete(TrackEntry trackentry)
        {
            // Debug.Log("spine动画播放完毕");
            gameEnd = true;
            StartCoroutine(GameEnd1());
            // GameEnd();
        }
        
        IEnumerator GameEnd1()
        {
            GameRoot.Instance.Good();
            
            yield return new WaitForSeconds(2f);
            
            GameEnd();
            
            yield return null;
        }


        private void Update()
        {
            // if (gameStart)
            // {
            //     timer -= Time.deltaTime;
            //     if (timer <= 0)
            //     {
            //         var _pos = carStartPosX + Random.Range(-100,100) * 0.01f * carPosLimit;
            //         carTargetX = Mathf.Clamp(_pos,-carPosLimit,carPosLimit);
            //         timer = carChangePosTime;
            //     }
            //
            //     if (car.transform.localPosition.x != carTargetX)
            //     {
            //         car.transform.localPosition = new Vector3(Mathf.Lerp(car.transform.localPosition.x, carTargetX, 0.005f), car.transform.localPosition.y, car.transform.localPosition.z);
            //     }
            //
            //     // Debug.Log(mouseX+"/"+car.transform.localPosition.x);
            //     var _value = Mathf.Abs(mouseX - car.transform.localPosition.x);
            //     if (_value < 1)
            //     {
            //         skeletonAnimation.timeScale = 1-_value;
            //     }
            // }


            if (!gameEnd)
            {
                if (touch)
                {
                    if (tip.activeSelf)
                    {
                        tip.SetActive(false);
                    }
                    skeletonAnimation.timeScale = 0.5f;
                    carDis += 1.35f * Time.deltaTime;
                    car.transform.localPosition = new Vector3(carStartPosX+carDis, car.transform.localPosition.y, car.transform.localPosition.z);
                }
                else
                {
                    skeletonAnimation.timeScale = 0;
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
            // gameStart = false;
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