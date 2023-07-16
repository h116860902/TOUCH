using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TOUCH
{
    public class Tombstone : MonoBehaviour
    {
        public GameContrl_4 m_Belonger;
        public float dust = 0;
        public SpriteRenderer SpriteRenderer;
        public List<Sprite> spriteList;
        private bool GameEnd = false;
        // private Vector3 mousePos;
        private Vector3 mousePosPre;

        public float Dust
        {
            get => dust;
            set
            {
                dust = value;
                if (value < 5)
                {
                    var _value = (int) Mathf.Floor(value);
                    // Debug.Log(_value);
                    SpriteRenderer.sprite = spriteList[_value];
                }
                else
                {
                    if (!GameEnd)
                    {
                        SpriteRenderer.sprite = null;
                        GameEnd = true;
                        
                        // m_Belonger.GameEnd();
                        
                        StartCoroutine(end());
                    }
                }
            }
        }
        
        IEnumerator end()
        {
            GameRoot.Instance.Good();
            
            yield return new WaitForSeconds(2f);
            
            m_Belonger.GameEnd();
            
            yield return null;
        }

        // private void OnMouseDrag()
        // {
        //     if (GameEnd) return;
        //     if (mousePosPre != Input.mousePosition)
        //     {
        //         Dust += 0.01f;
        //         mousePosPre = Input.mousePosition;
        //         if (Dust > 5)
        //         {
        //             SpriteRenderer = null;
        //             GameEnd = true;
        //             m_Belonger.GameEnd();
        //         }
        //     }
        // }
    }
}