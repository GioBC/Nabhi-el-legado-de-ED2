using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;
using MoreMountains.Feedbacks;
using UnityEngine.EventSystems;
using static UnityEngine.Rendering.DebugUI;

namespace MoreMountains.CorgiEngine
{

    public class ShakraGarganta : MonoBehaviour, MMEventListener<CorgiEngineEvent>
    {
        private Transform player;
        public GameObject[] glow;
        private Material material;
        int sineGlowColorPropertyID;
        private Color conexionColor = new Color(0.628272176f, 0, 10.6806269f, 0);
        private Color gargantaColor = new Color(0, 4.04013443f, 10.6806269f, 0);
        public bool habilitarShakraGarganta = false;



        // Start is called before the first frame update
        void Awake()
        {
            //player = GameObject.FindGameObjectWithTag("Player").transform;




        }


        protected virtual void Initialization()
        {
            if (LevelManager.Instance.Players.Count == 0)
            {
                return;
            }
            // we get the player
            player = LevelManager.Instance.Players[0].transform;
            if (PlayerPrefs.GetInt("PrefShakraGarganta") == 1)
            {
                habilitarShakraGarganta = true;
            }
            sineGlowColorPropertyID = Shader.PropertyToID("_SineGlowColor");
            glow = GameObject.FindGameObjectsWithTag("Glow");

        }


        void Start()
        {
            
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
        private void OnTriggerEnter2D(Collider2D other)
        {
            // Check if the collided game object has the DamageOnTouch component
            DamageOnTouch damageOnTouch = other.GetComponent<DamageOnTouch>();
            if (other.CompareTag("Shakra") && other.gameObject.name == "Garganta")
            {
                PlayerPrefs.SetInt("PrefShakraGarganta", 1);
            }
            if (PlayerPrefs.GetInt("PrefShakraGarganta") == 1)
            {
                habilitarShakraGarganta = true;
            }
            if (other.CompareTag("AreaToxica"))
            {
                if (habilitarShakraGarganta && PlayerPrefs.GetInt("PrefShakraGarganta") == 1)
                {
                    if (damageOnTouch != null)
                    {
                        // Disable the DamageOnTouch component
                        damageOnTouch.enabled = false;
                    }
                    for (var i = 0; i < glow.Length; i++)
                    {

                        var rendererGlow = glow[i].GetComponent<SpriteRenderer>().material;
                        //See if it has a renderer on it

                        if (rendererGlow)
                        {
                            //renderer.color = Color.red;
                            //renderer.color = Color.red;
                            //renderer.SetColor(sineGlowColorPropertyID, ConexionColor);
                            rendererGlow.SetColor(sineGlowColorPropertyID, gargantaColor);

                        }
                    }
                }
            }




        }


        private void OnTriggerExit2D(Collider2D other)
        {
            StartCoroutine(BacktoConexionShakra());
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.CompareTag("AreaToxica"))
            {
                if (habilitarShakraGarganta)
                {
                    
                    for (var i = 0; i < glow.Length; i++)
                    {

                        var rendererGlow = glow[i].GetComponent<SpriteRenderer>().material;
                        //See if it has a renderer on it

                        if (rendererGlow)
                        {
                            rendererGlow.SetColor(sineGlowColorPropertyID, gargantaColor);

                        }
                    }
                }
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

