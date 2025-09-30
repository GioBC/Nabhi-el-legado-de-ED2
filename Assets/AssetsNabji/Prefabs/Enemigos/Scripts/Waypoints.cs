using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;
using MoreMountains.Feedbacks;


namespace MoreMountains.CorgiEngine
{
    public class Waypoints : MonoBehaviour, MMEventListener<CorgiEngineEvent>
    {

        public GameObject[] waypoints;
        public GameObject player;
        int current = 0;
        public float speed;
        public float WPradius = 1;
        public bool isFacingRight;


        protected virtual void Initialization()
        {
          




        }

        void LateUpdate()
        {
            if (Vector3.Distance(waypoints[current].transform.position, transform.position) < WPradius)
            {
                current = Random.Range(0, waypoints.Length);
                if (current >= waypoints.Length)
                {
                    current = 0;
                }
            }
            transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);

            if (waypoints[current].transform.position.x > transform.position.x)
            {
                //face right
                if (!isFacingRight)
                {
                    transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                    isFacingRight = true;
                }
            }
            else if (waypoints[current].transform.position.x < transform.position.x)
            {
                //face left
                if (isFacingRight)
                {
                    transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                    isFacingRight = false;
                }
            }

        }

        /*void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.tag == "Player")
            {
                GetComponent<Health>().DeathFeedbacks?.PlayFeedbacks();
                Destroy(gameObject);
            }


        }*/

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