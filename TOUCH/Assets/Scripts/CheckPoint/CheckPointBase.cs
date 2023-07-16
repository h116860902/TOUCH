using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TOUCH
{
    public class CheckPointBase : SerializedMonoBehaviour
    {
        public virtual void execute()
        {
            
        }

        // public void OnTriggerEnter2D(Collider2D other)
        // {
        //     playerContrl _item = other.GetComponent<playerContrl>();
        //     if (_item != null)
        //     {
        //         execute();
        //     }
        // }
    }
}