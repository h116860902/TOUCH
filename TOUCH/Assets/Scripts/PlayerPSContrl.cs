using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TOUCH
{
    public class PlayerPSContrl : MonoBehaviour
    {
        public ParticleSystem ParticleSystem;

        // private bool PsPlay = true;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                ParticleSystem.Stop();
            }
            
            if (Input.GetKeyDown(KeyCode.J))
            {
                ParticleSystem.Play();
            }
        }
    }
}