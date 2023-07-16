using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TOUCH
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;

        // public float moveSpeed = 10f;

        public float yPos;

        public float limitX;

        // public void init()
        // {
        //     // target = GameRoot.Instance.Player.transform;
        // }

        private void Start()
        {
            // DontDestroyOnLoad(this);
            yPos = transform.position.y;
        }

        void Update()
        {
            if (target != null)
            {
                //使用 Time.unscaledTime 时间暂停的时候摄像头不会被停止
                // transform.position = Vector3.Lerp(transform.position, target.position, 
                //     Time.deltaTime*moveSpeed);
                limitX = Mathf.Clamp(target.position.x,0, GameRoot.Instance.currentLimitArea.y - 8f);
                
                transform.position = new Vector3(limitX,yPos, -10);
            }
        }
    }
}