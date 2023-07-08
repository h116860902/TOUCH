using System;
using Sirenix.OdinInspector;

namespace TOUCH
{
    [Serializable]
    public class GameRoot : SerializedMonoBehaviour
    {
        public static GameRoot Instance = null;//做成单例
        
        // public Dictionary<FIGURE_RANK, FigureCardBattle> FigureRankSprite = new Dictionary<FIGURE_RANK, FigureCardBattle>();
        
        // [Header("拖拽的显示")]
        // public Color CanPutColor = Color.green;
        // public Color CanNotPutColor = Color.red;
        
        void Start()
        {
            Instance = this;
        }

        public void ChangeRoom()
        {
            SceneManager.LoadSceneAsync(sceneName)
        }
    }
}