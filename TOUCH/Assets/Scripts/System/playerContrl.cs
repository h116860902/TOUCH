using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.Utilities;
using Spine.Unity;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TOUCH
{
    public class playerContrl : MonoBehaviour
    {
        public float MoveSpeed = 5;

        public bool canMove = true;

        [Header("Spine控制器")] 
        public int skeletonIndex = 0;
        public List<SkeletonAnimation> skeletonList;
        public SkeletonAnimation skeletonAnimation;
        public Spine.AnimationState spineAnimationState;
        // [SpineEvent(dataField: "skeletonAnimation", fallbackToTextField: true)]
        // public string AttackeventName;

        public GameObject Black;

        protected Vector3 m_MoveVector = Vector3.zero;
        private bool moving;

        private void Start()
        {
            // DontDestroyOnLoad(this);
            // SceneManager.sceneLoaded += OnSceneLoaded;
            skeletonChange();
            spineAnimationState.TimeScale = 0.5f;
        }

        public void skeletonChange()
        {
            if (skeletonAnimation != null)
            {
                skeletonAnimation.gameObject.SetActive(false);
                if (skeletonIndex == 4)
                {
                    Black.SetActive(true);
                }
            }
            skeletonAnimation = skeletonList[skeletonIndex];
            skeletonAnimation.gameObject.SetActive(true);
            spineAnimationState = skeletonAnimation.AnimationState;
            skeletonIndex++;
        }

        private void Update()
        {
            // if (Input.GetKeyDown(KeyCode.K))
            // {
            //     GameRoot.Instance.Good();
            // }
            //
            if (canMove)
            {
                m_MoveVector.x = Input.GetAxis("Horizontal");

                moving = m_MoveVector.magnitude > .01f;

                if (moving)
                {
                    var _pos = transform.position;
                    _pos += m_MoveVector * MoveSpeed * Time.deltaTime;
                    _pos.x = Mathf.Clamp(_pos.x,GameRoot.Instance.currentLimitArea.x,GameRoot.Instance.currentLimitArea.y);
                    transform.position = _pos;

                    if (skeletonIndex < 4)
                    {
                        if (skeletonAnimation.AnimationName != "run")
                        {
                            spineAnimationState.SetAnimation(0, "run", true);
                            spineAnimationState.TimeScale = 1;
                        }
                    }
                    else
                    {
                        MoveSpeed = 4;
                        if (skeletonAnimation.AnimationName != "run2")
                        {
                            spineAnimationState.SetAnimation(0, "run2", true);
                            spineAnimationState.TimeScale = 1;
                        }
                    }


                    SpriteControl();
                }
                else
                {
                    if (skeletonIndex < 4)
                    {
                        if (skeletonAnimation.AnimationName != "idle")
                        {
                            spineAnimationState.SetAnimation(0, "idle", true);
                            spineAnimationState.TimeScale = 0.5f;
                        }
                    }
                    else
                    {
                        if (skeletonAnimation.AnimationName != "ilde2")
                        {
                            spineAnimationState.SetAnimation(0, "ilde2", true);
                            spineAnimationState.TimeScale = 0.5f;
                        }
                    }
                }
            }
            else
            {
                spineAnimationState.TimeScale = 0;
            }
        }
        
        
        protected int m_FaceOrientation = 1;
        protected int PreFaceOrientation = 1;
        public void SpriteControl()
        {
            //检查人物朝向
            if (m_MoveVector.x > 0)
            {
                m_FaceOrientation = 1;
            }
            if (m_MoveVector.x < 0)
            {
                m_FaceOrientation = -1;
            }

            if (m_FaceOrientation != PreFaceOrientation)
            {
                Vector3 scale = skeletonAnimation.transform.localScale; //设置scale变量
                scale.x = Mathf.Abs(scale.x) * m_FaceOrientation;
                skeletonAnimation.transform.localScale = scale; //重新赋值
                PreFaceOrientation = m_FaceOrientation;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            CheckPointBase _check = other.GetComponent<CheckPointBase>();
            if (_check != null)
            {
                // Debug.Log("碰撞！"+other.transform);
                _check.execute();
            }
        }

        // void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        // {
        //     // Transform _startPos = GameObject.Find("StartPos").transform;
        //     // if (_startPos != null)
        //     // {
        //     //     // GameRoot.Instance.Player.position = _startPos.position;
        //     // }
        // }
    }
}