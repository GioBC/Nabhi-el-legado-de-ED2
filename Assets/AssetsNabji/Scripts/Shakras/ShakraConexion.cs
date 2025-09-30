using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;
using MoreMountains.Feedbacks;
using UnityEngine.EventSystems;
using static UnityEngine.Rendering.DebugUI;

namespace MoreMountains.CorgiEngine
{

    public class ShakraConexion : MonoBehaviour, MMEventListener<CorgiEngineEvent>
    {

        private Transform player;
        public GameObject[] glow;
        private Material material;
        int sineGlowColorPropertyID;
        private Color glowColor = new Color(2.996078f, 0, 0.09990776f, 0);
        private Color ConexionColor = new Color(0.628272176f, 0, 10.6806269f, 0);
        private Color CalorColor = new Color(2.996078f, 2.305101f, 0, 0);
        public bool habilitarShakraConexion=false;



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
            if (PlayerPrefs.GetInt("PrefShakraConexion") == 1)
            { 
                habilitarShakraConexion= true;
            }
            sineGlowColorPropertyID = Shader.PropertyToID("_SineGlowColor");






        }

        // Update is called once per frame
        void Update()
        {
            
        }





        private void OnTriggerEnter2D(Collider2D other)
        {
            // Check if the collided game object has the DamageOnTouch component
            DamageOnTouch damageOnTouch = other.GetComponent<DamageOnTouch>();
            if (other.CompareTag("Shakra") && other.gameObject.name == "Conexion")
            {
                PlayerPrefs.SetInt("PrefShakraConexion", 1);
            }
            if (PlayerPrefs.GetInt("PrefShakraConexion") == 1)
            {
                habilitarShakraConexion= true;
            }
            if (other.CompareTag("AreaToxica"))
            {
                if (habilitarShakraConexion)
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
                            rendererGlow.SetColor(sineGlowColorPropertyID, CalorColor);
                            
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

