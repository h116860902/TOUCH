using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

namespace TOUCH
{
    public class GameContrl_2 : SerializedMonoBehaviour
    {
        public int point = 0;

        public Animator back;
        public List<Transform> PuzzleSlotList;
        public List<Animator> PuzzleItemList;
        
        public GameObject showNpc1;
        public GameObject showNpc2;
        
        public Animator anim;
        public bool animPlay;
        public bool animPlayEnd;

        public DragItem dragItemPrefab;
        public Vector2 areaRange;

        public void GameStart()
        {
            GameRoot.Instance.Player.GetComponent<playerContrl>().canMove = false;
            
            for (int i = 0; i < 6; i++)
            {
                var _random = Random.Range(0, PuzzleSlotList.Count);
                var _slot = PuzzleSlotList[_random];
                DragItem _obj = Instantiate(dragItemPrefab, transform);
                         _obj.Target = _slot;
                         _obj.transform.position = transform.position + new Vector3(Random.Range(-areaRange.x,areaRange.x),Random.Range(-areaRange.y,areaRange.y),0);
                         _obj.m_Belonger = this;
                         _obj.GetComponent<SpriteRenderer>().sprite = _slot.GetComponent<SpriteRenderer>().sprite;
                         PuzzleItemList.Add(_obj.GetComponent<Animator>());
                PuzzleSlotList.RemoveAt(_random);
            }
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
            back.Play("PuzzleEnd");
            foreach (var _item in PuzzleItemList)
            {
                _item.Play("PuzzleEnd");
            }
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

        public void pointAdd()
        {
            point++;
            if (point >= 6)
            {
                // Debug.Log("小游戏通过");
                StartCoroutine(GameEnd1());
                // GameEnd();
            }
        }
        
        IEnumerator GameEnd1()
        {
            GameRoot.Instance.Good();
            
            yield return new WaitForSeconds(2f);
            
            GameEnd();
            
            yield return null;
        }
    }
}