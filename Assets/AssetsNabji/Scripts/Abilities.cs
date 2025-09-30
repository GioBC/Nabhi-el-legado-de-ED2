using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;
using MoreMountains.Feedbacks;
using UnityEngine.EventSystems;

namespace MoreMountains.CorgiEngine
{

    public class Abilities : MonoBehaviour, MMEventListener<CorgiEngineEvent>
    {

        private Transform player;
        public GameObject panelAbilidades;
        public GameObject poder01;
        public GameObject []difuminado;
        public GameObject[] glow;
        private Material material;
        int sineGlowColorPropertyID;
        private Color glowColor=new Color(2.996078f,0, 0.09990776f,0);
        private Color ConexionColor = new Color(0, 2.559343f, 2.996078f, 0);
        private Color CalorColor = new Color(2.996078f, 2.305101f, 0, 0);
        public GameObject[] areaToxica;
        public GameObject[] areaCalor;
        private GameObject camara;

        // Start is called before the first frame update
        void Awake()
        {
            //player = GameObject.FindGameObjectWithTag("Player").transform;

            panelAbilidades = GameObject.Find("Habilidades");
            poder01 = GameObject.Find("Icon_Skill01");
            camara= GameObject.Find("Main Camera");




        }


        protected virtual void Initialization()
        {
            if (LevelManager.Instance.Players.Count == 0)
            {
                return;
            }
            // we get the player
            player = LevelManager.Instance.Players[0].transform;
            difuminado = GameObject.FindGameObjectsWithTag("Difuminado");
            glow = GameObject.FindGameObjectsWithTag("Glow");
            areaToxica = GameObject.FindGameObjectsWithTag("AreaToxica");
            areaCalor = GameObject.FindGameObjectsWithTag("AreaCalor");

            //material =difuminado.GetComponent<SpriteRenderer>().material;
            sineGlowColorPropertyID = Shader.PropertyToID("_SineGlowColor");
            //material.SetColor(sineGlowColorPropertyID, glowColor);

            //panelAbilidades.SetActive(false);






        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown("joystick button 6"))
            {
                HabilitarDeshabilitar();
                //panelAbilidades.SetActive
                /*if (!panelAbilidades)
                {
                    Time.timeScale = 0;
                }*/

                

                


                


            }
        }

        void HabilitarDeshabilitar()
        {
            if (panelAbilidades.activeInHierarchy == false)
            {
                panelAbilidades.SetActive(true);
                //poder01.Select();
                player.GetComponent<CorgiController>().enabled = false;
                camara.GetComponent<CameraController>().enabled = false;


            }
            else
            {
                panelAbilidades.SetActive(false);
                player.GetComponent<CorgiController>().enabled = true;
                camara.GetComponent<CameraController>().enabled = true;
            }

            //Clear

            EventSystem.current.SetSelectedGameObject(null);

            //Reassign

            EventSystem.current.SetSelectedGameObject(poder01);

        }

        public void ShakraConexion()
        {

            for (var i = 0; i < difuminado.Length; i++)
            {
                var renderer = difuminado[i].GetComponent<SpriteRenderer>().material;
                var rendererGlow = glow[i].GetComponent<SpriteRenderer>().material;
                //See if it has a renderer on it

                if (renderer)
                {
                    //renderer.color = Color.red;
                    //renderer.color = Color.red;
                    renderer.SetColor(sineGlowColorPropertyID, ConexionColor);
                    rendererGlow.SetColor(sineGlowColorPropertyID, ConexionColor);
                }
            }
            

            for (var i = 0; i < areaToxica.Length; i++)
            {

                var toxica = areaToxica[i].GetComponent<DamageOnTouch>();


                //See if it has a renderer on it

                if (toxica)
                {
                    //renderer.color = Color.red;
                    //renderer.color = Color.red;
                    toxica.enabled = true;
                }
            }

            for (var i = 0; i < areaCalor.Length; i++)
            {

                var calor = areaCalor[i].GetComponent<DamageOnTouch>();


                //See if it has a renderer on it

                if (calor)
                {
                    //renderer.color = Color.red;
                    //renderer.color = Color.red;
                    calor.enabled = true;
                }
            }
            Time.timeScale = 1;
            HabilitarDeshabilitar();

        }

        public void ShakraFuerza()
        {

        }

        public void ShakraVelocidad()
        {

        }

        public void ShakraResistencia()
        {
            for (var i = 0; i < difuminado.Length; i++)
            {
                var renderer = difuminado[i].GetComponent<SpriteRenderer>().material;
                var rendererGlow = glow[i].GetComponent<SpriteRenderer>().material;
                //See if it has a renderer on it

                if (renderer)
                {
                    //renderer.color = Color.red;
                    //renderer.color = Color.red;
                    renderer.SetColor(sineGlowColorPropertyID, glowColor);
                    rendererGlow.SetColor(sineGlowColorPropertyID, glowColor);
                }
            }
            

            

            /*foreach (GameObject go in areaToxica)
            {
                go.SetActive(false);
            }*/

            for (var i = 0; i < areaToxica.Length; i++)
            {

                var toxica = areaToxica[i].GetComponent<DamageOnTouch>();


                //See if it has a renderer on it

                if (toxica)
                {
                    //renderer.color = Color.red;
                    //renderer.color = Color.red;
                    toxica.enabled = false;
                }
            }
            Time.timeScale = 1;
            HabilitarDeshabilitar();
        }

        public void ShakraGravedad()
        {

        }

        public void ShakraCalor()
        {
            for (var i = 0; i < difuminado.Length; i++)
            {
                var renderer = difuminado[i].GetComponent<SpriteRenderer>().material;
                var rendererGlow = glow[i].GetComponent<SpriteRenderer>().material;
                //See if it has a renderer on it

                if (renderer)
                {
                    //renderer.color = Color.red;
                    //renderer.color = Color.red;
                    renderer.SetColor(sineGlowColorPropertyID, CalorColor);
                    rendererGlow.SetColor(sineGlowColorPropertyID, CalorColor);
                }
            }
            



            /*foreach (GameObject go in areaToxica)
            {
                go.SetActive(false);
            }*/

            for (var i = 0; i < areaCalor.Length; i++)
            {

                var calor = areaCalor[i].GetComponent<DamageOnTouch>();


                //See if it has a renderer on it

                if (calor)
                {
                    //renderer.color = Color.red;
                    //renderer.color = Color.red;
                    calor.enabled = false;
                }
            }
            Time.timeScale = 1;
            HabilitarDeshabilitar();
        }

        public void ShakraAgua()
        {

        }

        public void ShowAbilities()
        {
            panelAbilidades.SetActive(true);
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
