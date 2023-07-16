using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.Utilities;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace TOUCH
{
    public class Game1_Npc : MonoBehaviour
    {
        public GameContrl_1 belonger;
        public int face;//射击方向

        public float power = 0.2f;
        
        public bool GameStart;
        
        private float currentHp = 0;
        public float CurrentHp
        {
            get => currentHp;
            set => currentHp = Mathf.Clamp(0, value, maxHp);
        }

        public int maxHp;
        
        public Image hpBar;

        public Transform shootPos;
        public Game1_Bullet Bullet;
        public float shootTime;
        public float shootTimer;

        private void Update()
        {
            if (!GameStart) return;
            
            hpBar.fillAmount = CurrentHp / maxHp;

            shootTimer -= Time.deltaTime;
            if (shootTimer <= 0)
            {
                shootTimer = shootTime;
                
                var _chance = Random.Range(0, 100);
                var _obj = Instantiate(Bullet, shootPos);
                if (_chance < 50)
                {
                    _obj.Init(this,BULLET.LOVE);
                }
                else
                {
                    _obj.Init(this,BULLET.ATTACK);
                }

                Rigidbody2D _rigidbody2D = _obj.GetComponent<Rigidbody2D>();
                _rigidbody2D.AddForce(new Vector2(8*face, Random.Range(-3,3))*power, ForceMode2D.Impulse);
                // _rigidbody2D.velocity = new Vector2(2, 0);
                
            }
        }


        // private void OnCollisionEnter(Collision other)
        // {
        //     Debug.Log("碰到物体："+other);
        //     Game1_Bullet _item = other.gameObject.GetComponent<Game1_Bullet>();
        //     if (_item != null && _item.belonger != this)
        //     {
        //         Debug.Log("碰到物体："+_item);
        //         if (_item.type == BULLET.LOVE)
        //         {
        //             CurrentHp++;
        //         }
        //         else
        //         {
        //             CurrentHp -= .2f;
        //         }
        //
        //         belonger.checkComplete();
        //         Destroy(_item.gameObject);
        //     }
        // }

        // private void OnTriggerEnter(Collider other)
        // {
        //     Debug.Log("碰到物体："+other);
        //     Game1_Bullet _item = other.gameObject.GetComponent<Game1_Bullet>();
        //     if (_item != null && _item.belonger != this)
        //     {
        //         Debug.Log("碰到物体："+_item);
        //         if (_item.type == BULLET.LOVE)
        //         {
        //             CurrentHp++;
        //         }
        //         else
        //         {
        //             CurrentHp -= .2f;
        //         }
        //
        //         belonger.checkComplete();
        //         Destroy(_item.gameObject);
        //     }
        // }
    }
}