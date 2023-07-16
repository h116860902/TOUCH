using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.Utilities;
using UnityEngine;

namespace TOUCH
{
    public class DragItem : MonoBehaviour
    {
        private bool isFinished;

        public GameContrl_2 m_Belonger;

        // private Vector3 TargetPos;

        public Transform Target;

        private void OnMouseDrag()
        {
            if (!isFinished)
            {
                // Debug.Log("拖拽");
                transform.position = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            }
        }
        
        private void OnMouseUp()
        {
            if (isFinished) return;
            // Debug.Log("鼠标抬起");
            if (Vector3.Distance(transform.position, Target.position) < 0.5f)
            {
                // Debug.Log("完成配对");
                isFinished = true;
                transform.position = Target.position;
                GetComponent<Collider2D>().enabled = false;
                GetComponent<SpriteRenderer>().sortingOrder = 4;
                m_Belonger.pointAdd();
            }
        }

        private void Update()
        {
            // if (Input.GetMouseButtonDown(0))
            // {
            //     Vector3 ClickPos = Input.mousePosition;
            //     // ClickPos.z = Camera.main.transform.position.z;
            //     TargetPos = Camera.main.ScreenToWorldPoint(ClickPos);
            //     TargetPos.z = 0;
            //     Debug.Log("从"+transform.position+"移动到"+TargetPos);
            // }
            
            // if (transform.position != TargetPos)
            // {
            //     transform.position = Vector3.MoveTowards(transform.position, TargetPos,5*Time.deltaTime);
            // }
        }



        private void OnMouseEnter()
        {
            // Debug.Log("鼠标进入");
        }
    }
}