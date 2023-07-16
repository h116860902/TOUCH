using UnityEngine;
using UnityEngine.SceneManagement;

namespace TOUCH
{
    public class EndContrl : MonoBehaviour
    {
        public AudioClip bgm;
        public GameObject tip;
        private float timer = 16;
        private bool show;
        
        void Start()
        {
            SystemPlayBgm.Instance.PlaySound(bgm);
        }
        
        void Update()
        {
            if (show == false)
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    if (tip != null)
                    {
                        tip.SetActive(true);
                    }
                    show = true;
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    GameRoot.Instance.End();
                    SceneManager.LoadSceneAsync("Title");
                }
            }
        }
    }
}
