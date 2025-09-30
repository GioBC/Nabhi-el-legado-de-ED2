using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;
using MoreMountains.Feedbacks;
using UnityEngine.EventSystems;
using static UnityEngine.Rendering.DebugUI;

namespace MoreMountains.CorgiEngine
{


    public class MuerteAcorazado : MonoBehaviour
    {
        [SerializeField] private Health healthAcorazado;
        [SerializeField] private Health healthCharacter;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (healthAcorazado.CurrentHealth<=0) 
            {
                healthCharacter.enabled = true;
                healthCharacter.CurrentHealth=0;
                healthCharacter.Kill();
            }
        }
    }
}