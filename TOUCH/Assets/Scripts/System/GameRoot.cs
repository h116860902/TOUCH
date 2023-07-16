using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TOUCH
{
    [Serializable]
    public class GameRoot : SerializedMonoBehaviour
    {
        public static GameRoot Instance = null;//做成单例
        // public Transform PlayerPrefab;
        public playerContrl Player;
        
        public AudioClip TitleBgm;

        // public CameraFollow CameraFollow;

        public Excessive ExcessivePrefab;

        public int area = 0;
        public List<Vector2> limitArea;
        public Vector2 currentLimitArea;
        
        public AudioClip GameSuccessfulSe;

        public GameObject GoodPrefab;

        private string ChangeRoomName;
        
        // public Dictionary<FIGURE_RANK, FigureCardBattle> FigureRankSprite = new Dictionary<FIGURE_RANK, FigureCardBattle>();
        
        // [Header("拖拽的显示")]
        // public Color CanPutColor = Color.green;
        // public Color CanNotPutColor = Color.red;
        
        void Start()
        {
            DontDestroyOnLoad(this);
            Instance = this;

            // Player = Instantiate(PlayerPrefab);
            // CameraFollow.init();
            currentLimitArea = limitArea[area];
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        public void End()
        {
            Destroy(Camera.main.gameObject);
            Destroy(gameObject);
        }

        public void Good()
        {
            Vector3 _pos = Camera.main.transform.position;
            _pos.z = 0;
            var _obj = Instantiate(GoodPrefab);
            _obj.transform.position = _pos;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#else
				Application.Quit();
#endif
            }
        }

        public void ChangeRoom(string _sceneName)
        {
            ChangeRoomName = _sceneName;
            StartCoroutine(ChangeRoom());
        }

        IEnumerator ChangeRoom()
        {
            Player.canMove = false;
            Excessive _obj;
            _obj = Instantiate(ExcessivePrefab);
            _obj.GetComponent<Excessive>().Alpha01();
                
            yield return new WaitForSeconds(1.2f);
            
            SceneManager.LoadSceneAsync(ChangeRoomName);
            
            area++;
            if (area < 2)
            {
                currentLimitArea = limitArea[area];
            }
            
            yield return null;
        }
        
        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            // Transform _startPos = GameObject.Find("StartPos").transform;
            // if (_startPos != null)
            // {
            //     // GameRoot.Instance.Player.position = _startPos.position;
            // }
            if (area < 2)
            {
                Player = GameObject.Find("Player").GetComponent<playerContrl>();
            }
        }
    }
}