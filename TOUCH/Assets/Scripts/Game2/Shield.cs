using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.Utilities;
using UnityEngine;

namespace TOUCH
{
    public class Shield : MonoBehaviour
    {
        public Vector2 StartPos;

        public GameObject tip;

        private void Start()
        {
            StartPos = new Vector2(transform.position.x,transform.position.y);
        }

        private void OnMouseDown()
        {
            tip.SetActive(false);
        }

        private void OnMouseDrag()
        {
            transform.position = new Vector2(StartPos.x,Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        }
    }
}