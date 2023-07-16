using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.Utilities;
using UnityEngine;

namespace TOUCH
{
    public class Rag: MonoBehaviour
    {
        private bool isFinished;

        public GameContrl_4 m_Belonger;

        // private Vector3 TargetPos;

        public Tombstone Target;
        
        private Vector3 mousePosPre;

        public GameObject tip;

        // public GameObject Dust;

        public ParticleSystem Dust1;
        public ParticleSystem Dust2;
        private float Timer;

        private bool DustPlay;
        
        private void Start()
        {
            // Dust1.Pause(true);
            // Dust2.Pause(true);
            Dust1.Stop();
            Dust2.Stop();
            DustPlay = false;
        }

        private void Update()
        {
            if (Timer > 0)
            {
                Timer -= Time.deltaTime;
                if (Timer <= 0)
                {
                    // Dust.SetActive(false);
                    Dust1.Stop();
                    Dust2.Stop();
                    DustPlay = false;
                }
            }
        }

        private void OnMouseDown()
        {
            tip.SetActive(false);
        }

        private void OnMouseDrag()
        {
            if (!isFinished)
            {
                // Debug.Log("拖拽");
                transform.position = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            }
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (mousePosPre != Input.mousePosition)
            {
                var _tombstone = other.GetComponent<Tombstone>();
                if (_tombstone != null)
                {
                    Target = _tombstone;
                    _tombstone.Dust += 0.01f;
                    mousePosPre = Input.mousePosition;
                    // Dust.SetActive(true);
                    if (!DustPlay)
                    {
                        Dust1.Play();
                        Dust2.Play();
                        DustPlay = true;
                    }
                    Timer = 0.1f;
                }
            }
        }

        // private void OnMouseUp()
        // {
        //     if (isFinished) return;
        //     // Debug.Log("鼠标抬起");
        //     if (Vector3.Distance(transform.position, Target.position) < 0.5f)
        //     {
        //         // Debug.Log("完成配对");
        //         isFinished = true;
        //         transform.position = Target.position;
        //         GetComponent<Collider2D>().enabled = false;
        //         GetComponent<SpriteRenderer>().sortingOrder = 2;
        //         m_Belonger.pointAdd();
        //     }
        // }
    }
}