using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TOUCH
{
    public class CheckPoint_Game4 : CheckPointBase
    {
        private bool isExecute;
        public GameObject ActiveGameObject;
        
        // public AudioClip bgm;
        
        public override void execute()
        {
            if (!isExecute)
            {
                // SystemPlayBgm.Instance.PlaySound(bgm);
                ActiveGameObject.SetActive(true);
                Vector3 _pos = Camera.main.transform.position;
                _pos.z = 0;
                ActiveGameObject.transform.position = _pos;
                ActiveGameObject.GetComponent<GameContrl_4>().GameStart();
                
                isExecute = true;
            }
        }
    }
}