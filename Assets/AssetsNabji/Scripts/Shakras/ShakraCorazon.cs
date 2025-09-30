using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;
using MoreMountains.Feedbacks;
using UnityEngine.EventSystems;
using static UnityEngine.Rendering.DebugUI;
using UnityEngine.TextCore.Text;

namespace MoreMountains.CorgiEngine
{

    public class ShakraCorazon : MonoBehaviour, MMEventListener<CorgiEngineEvent>
    {
        private Character player;
        public GameObject[] glow;
        private Material material;
        int sineGlowColorPropertyID;
        private Color conexionColor = new Color(0.628272176f, 0, 10.6806269f, 0);
        private Color corazonColor = new Color(0, 7.60505342f, 0, 0);
        public bool habilitarShakraCorazon = false;
        protected InputManager _inputManager;
        private bool _stillFuelLeft;
        CharacterJetpack2 jetpack;
        


        public bool JetPackOnlyIfNoJumpsLeft = true;

        protected bool _gliding;
        protected CharacterJump _characterJump;
        protected CharacterWalljump _characterWallJump;
        protected CharacterSwim _characterSwim;

        // Start is called before the first frame update
        void Awake()
        {
            //player = GameObject.FindGameObjectWithTag("Player").transform;




        }


        protected virtual void Initialization()
        {
            // we get the player
            player = LevelManager.Instance.Players[0];

            if (LevelManager.Instance.Players.Count == 0)
            {
                return;
            }

            jetpack = player.FindAbility<CharacterJetpack2>();

            _characterJump = player.FindAbility<CharacterJump>();
            _characterWallJump = player?.FindAbility<CharacterWalljump>();
            _characterSwim = player?.FindAbility<CharacterSwim>();




        }

        private void Start()
        {
            Initialization();
            if (PlayerPrefs.GetInt("PrefShakraCorazon") == 1 && _characterJump.NumberOfJumpsLeft == 0)
            {
                habilitarShakraCorazon = true;
            }
            sineGlowColorPropertyID = Shader.PropertyToID("_SineGlowColor");
            glow = GameObject.FindGameObjectsWithTag("Glow");

            
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



        public void Update()
        {
            

            /*if (JetPackOnlyIfNoJumpsLeft
                && (_characterJump != null))
            {
                if ((_characterJump.NumberOfJumpsLeft > 0) || (_characterJump.JumpHappenedThisFrame))
                {
                    return;
                }
            }*/

            if (habilitarShakraCorazon && _characterJump.NumberOfJumpsLeft == 0)
            {
                //Debug.Log(_characterJump.NumberOfJumpsLeft);
                
                if (jetpack != null)
                {
                    // Disable the DamageOnTouch component
                    jetpack.enabled = true;
                }
                for (var i = 0; i < glow.Length; i++)
                {

                    var rendererGlow = glow[i].GetComponent<SpriteRenderer>().material;

                    if (rendererGlow)
                    {
                        rendererGlow.SetColor(sineGlowColorPropertyID, corazonColor);

                    }
                }
            }
            else
            {
                if (jetpack != null)
                {
                    // Disable the DamageOnTouch component
                    jetpack.enabled = false;
                }
            }
        
}

        private void OnTriggerEnter2D(Collider2D other)
        {
            // Check if the collided game object has the DamageOnTouch component
            DamageOnTouch damageOnTouch = other.GetComponent<DamageOnTouch>();
            CharacterJetpack2 jetpack = GetComponent<CharacterJetpack2>();
            if (other.CompareTag("Shakra") && other.gameObject.name == "Corazon")
            {
                PlayerPrefs.SetInt("PrefShakraCorazon", 1);
            }
            if (PlayerPrefs.GetInt("PrefShakraCorazon") == 1)
            {
                habilitarShakraCorazon = true;
            }

        }


        private void OnTriggerExit2D(Collider2D other)
        {
            StartCoroutine(BacktoConexionShakra());
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.CompareTag("AreaAgua"))
            {
                if (habilitarShakraCorazon && PlayerPrefs.GetInt("PrefShakraCorazon") == 1)
                {
                    
                    for (var i = 0; i < glow.Length; i++)
                    {

                        var rendererGlow = glow[i].GetComponent<SpriteRenderer>().material;
                        //See if it has a renderer on it

                        if (rendererGlow)
                        {
                            rendererGlow.SetColor(sineGlowColorPropertyID, corazonColor);

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

