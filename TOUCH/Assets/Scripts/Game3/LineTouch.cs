using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TOUCH
{
    public class LineTouch : MonoBehaviour
    {
        public GameContrl_3 m_Belonger;

        // private void OnMouseDown()
        // {
        //     m_Belonger.gameStart = true;
        //     // Debug.Log(transform+"游戏开始");
        // }

        private void OnMouseDown()
        {
            // Debug.Log(transform+"拖拽中");
            m_Belonger.touch = true;
        }

        private void OnMouseUp()
        {
            m_Belonger.touch = false;
        }
    }
}