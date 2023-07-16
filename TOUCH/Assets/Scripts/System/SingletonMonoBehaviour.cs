using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Sirenix.OdinInspector;
using UnityEngine;

namespace TOUCH
{
    public class SingletonMonoBehaviour<T> : MonoBehaviour
    {

        protected static T instance;
        public static T Instance
        {
            get
            {
                return instance;
            }
        }

        public virtual void OnEnable()
        {
            instance = GetComponent<T>();
        }

        public virtual void OnDisable()
        {
            instance = default(T);
        }
    }
}