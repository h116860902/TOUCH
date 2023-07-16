using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TOUCH
{
    public class Excessive : MonoBehaviour
    {
        public Animator Animator;

        public void Alpha01()
        {
            Animator.Play("Alpha01");
        }
        
        public void Alpha10()
        {
            Animator.Play("Alpha10");
        }

        // private void Update()
        // {
        //     var info = Animator.GetCurrentAnimatorStateInfo(0);
        //     if (info.normalizedTime >= 1) // 判断动画播放结束normalizedTime的值为0~1，0为开始，1为结束。
        //     {
        //         Destroy(gameObject);
        //     }
        // }
    }
}