using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;
using MoreMountains.Feedbacks;


namespace MoreMountains.CorgiEngine
{

    public class interruptor : MonoBehaviour, MMEventListener<CorgiEngineEvent>
    {

        private Transform player;
        public GameObject torreta;
        public GameObject encendido;
        public GameObject apagado;
        private bool interrupto;
        // Start is called before the first frame update
        void Start()
        {
            //player = GameObject.FindGameObjectWithTag("Player").transform;
            interrupto = false;
            encendido.SetActive(true);
            apagado.SetActive(false);
            

        }
        

        protected virtual void Initialization()
        {
            if (LevelManager.Instance.Players.Count == 0)
            {
                return;
            }
            // we get the player
            player = LevelManager.Instance.Players[0].transform;
            



        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                if (torreta != null)
                {
                    
                    torreta.GetComponent<Health>().DeathFeedbacks?.PlayFeedbacks();
                    Destroy(torreta);
                }
                interrupto = true;
                encendido.SetActive(false);
                apagado.SetActive(true);


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
