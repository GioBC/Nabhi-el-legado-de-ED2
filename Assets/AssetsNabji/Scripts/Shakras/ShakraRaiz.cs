using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;
using MoreMountains.Feedbacks;
using UnityEngine.EventSystems;
using static UnityEngine.Rendering.DebugUI;

namespace MoreMountains.CorgiEngine
{

    public class ShakraRaiz : MonoBehaviour, MMEventListener<CorgiEngineEvent>
    {
        private Transform player;
        public GameObject[] glow;
        private Material material;
        int sineGlowColorPropertyID;
        private Color conexionColor = new Color(0.628272176f, 0, 10.6806269f, 0);
        private Color raizColor = new Color(10.6806269f, 0.948478162f, 0, 0);
        public bool habilitarShakraRaiz = false;
        private Animator animator;
        protected virtual void Initialization()
        {
            if (LevelManager.Instance.Players.Count == 0)
            {
                return;
            }
            // we get the player
            player = LevelManager.Instance.Players[0].transform;
            if (PlayerPrefs.GetInt("PrefShakraRaiz") == 1)
            {
                habilitarShakraRaiz = true;
            }
            else
            {
                habilitarShakraRaiz = false;
            }
            sineGlowColorPropertyID = Shader.PropertyToID("_SineGlowColor");
            glow = GameObject.FindGameObjectsWithTag("Glow");

            animator = GetComponentInChildren<Animator>();

        }

        void Start()
        {
            Initialization();
        }

        IEnumerator BacktoConexionShakra()
        {
            // Wait for 3 seconds
            yield return new WaitForSeconds(3);

            for (var i = 0; i < glow.Length; i++)
            {
                var rendererGlow = glow[i].GetComponent<SpriteRenderer>().material;
                //See if it has a renderer on it

                if (rendererGlow)
                {
                    rendererGlow.SetColor(sineGlowColorPropertyID, conexionColor);
                }
            }
        }

        IEnumerator PlayRaizShakra()
        {
            // Wait for 3 seconds
            yield return new WaitForSeconds(0.2f);

            for (var i = 0; i < glow.Length; i++)
            {
                var rendererGlow = glow[i].GetComponent<SpriteRenderer>().material;
                //See if it has a renderer on it

                if (rendererGlow)
                {
                    rendererGlow.SetColor(sineGlowColorPropertyID, raizColor);
                }
            }
        }





        void Update()
        {
            


            if (animator.GetCurrentAnimatorStateInfo(0).IsName("RetroCorgiPush"))
            {
                StartCoroutine(PlayRaizShakra());
            }
            else
            {
                StartCoroutine(BacktoConexionShakra());
            }
        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            // Check if the collided game object has the DamageOnTouch component
            DamageOnTouch damageOnTouch = other.GetComponent<DamageOnTouch>();
            CharacterJetpack2 jetpack = GetComponent<CharacterJetpack2>();
            if (other.CompareTag("Shakra") && other.gameObject.name == "Raiz")
            {
                PlayerPrefs.SetInt("PrefShakraRaiz", 1);
            }
            if (PlayerPrefs.GetInt("PrefShakraRaiz") == 1)
            {
                habilitarShakraRaiz = true;
            }

        }



        public virtual void OnMMEvent(CorgiEngineEvent corgiEngineEvent)
        {
            switch (corgiEngineEvent.EventType)
            {
                case CorgiEngineEventTypes.LevelStart:
                    Initialization();
                    break;
            }
        }

        /// <summary>
        /// On enable, we start listening to events
        /// </summary>
        protected virtual void OnEnable()
        {
            this.MMEventStartListening<CorgiEngineEvent>();
        }

        /// <summary>
        /// On disable, we stop listening to events
        /// </summary>
        protected virtual void OnDisable()
        {
            this.MMEventStopListening<CorgiEngineEvent>();
        }
    }

}

