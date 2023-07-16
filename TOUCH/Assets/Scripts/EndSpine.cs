using System;
using System.Collections;
using System.Collections.Generic;
using Spine;
using Spine.Unity;
using UnityEngine;

namespace TOUCH
{
    public class EndSpine : MonoBehaviour
    {
        public SkeletonAnimation skeletonAnimation;
        public Spine.AnimationState spineAnimationState;

        public GameObject anim;

        private void Start()
        {
            spineAnimationState = skeletonAnimation.AnimationState;
            spineAnimationState.Complete += OnSpineAnimationComplete;
        }
        
        private void OnSpineAnimationComplete(TrackEntry trackentry)
        {
            anim.SetActive(true);
            Destroy(gameObject);
        }
    }
}

