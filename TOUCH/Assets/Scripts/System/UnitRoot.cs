using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TOUCH
{
    [Serializable]
    public class UnitRoot : SerializedMonoBehaviour
    {
        public Transform playerStartPos;

        private void Start()
        {
            // setPlayerPos();
        }

        // public void setPlayerPos()
        // {
        //     GameRoot.Instance.Player.position = playerStartPos.position;
        // }
    }
}