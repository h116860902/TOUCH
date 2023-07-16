using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TOUCH
{
    public class CheckPoint_Puzzle : CheckPointBase
    {
        private bool isExecute;
        public GameObject ActiveGameObject;
        
        public override void execute()
        {
            if (!isExecute)
            {
                ActiveGameObject.SetActive(true);
                Vector3 _pos = Camera.main.transform.position;
                _pos.z = 0;
                ActiveGameObject.transform.position = _pos;
                ActiveGameObject.GetComponent<GameContrl_2>().GameStart();
                
                isExecute = true;
            }
        }
    }
}