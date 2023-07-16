using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.Utilities;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TOUCH
{
    public enum BULLET
    {
        ATTACK,
        LOVE
    }
    
    public class Game1_Bullet : MonoBehaviour
    {
        public Game1_Npc belonger;
        public BULLET type;
        
        public List<Sprite> spriteList;
        public SpriteRenderer SpriteRenderer;

        public float life = 6;
        
        // public LayerMask TriggerLayer;

        private void Update()
        {
            life -= Time.deltaTime;
            if (life <= 0)
            {
                Destroy(gameObject);
            }
        }

        public void Init(Game1_Npc _npc,BULLET _type)
        {
            belonger = _npc;
            type = _type;
            if (_type == BULLET.ATTACK)
            {
                SpriteRenderer.sprite = spriteList[Random.Range(1,spriteList.Count)];
            }
            else
            {
                SpriteRenderer.sprite = spriteList[0];
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            // Debug.Log("碰到物体："+other);
            Game1_Npc npc = other.gameObject.GetComponent<Game1_Npc>();
            if (npc != null && npc != belonger)
            {
                // Debug.Log("碰到物体："+npc);
                if (type == BULLET.LOVE)
                {
                    npc.CurrentHp++;
                }
                else
                {
                    npc.CurrentHp -= .2f;
                }
            
                belonger.belonger.checkComplete();
                Destroy(gameObject);
            }
        }
    }
}