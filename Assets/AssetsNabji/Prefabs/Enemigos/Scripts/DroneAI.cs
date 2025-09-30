
using UnityEngine;
using System.Collections;
using MoreMountains.Tools;
using System.Collections.Generic;

namespace MoreMountains.CorgiEngine
{
    /// <summary>
    /// Add this script to a CharacterBehavior+CorgiController2D object to make it follow (or try to follow) Player1
    /// So far the Follower will move horizontally towards the player, and use a jetpack to reach it, or jump above obstacles.
    /// </summary>

    public class DroneAI : MonoBehaviour, MMEventListener<CorgiEngineEvent>
    {


        // List of patrol points for the drone
        public List<Transform> patrolPoints;

        // The current patrol point the drone is moving towards
        private int currentPatrolPoint = 0;

        // The speed at which the drone moves
        public float speed = 2f;

        // The radio of detection of the drone
        public float detectionRadius = 5f;

        // A reference to the player game object
        protected Character _character;
        protected Transform player;

        /// <summary>
        /// Initialization
        /// </summary>
        protected virtual void Initialization()
        {
            if (LevelManager.Instance.Players.Count == 0)
            {
                return;
            }
            // we get the player
            player = LevelManager.Instance.Players[0].transform;


        }

        /// <summary>
        /// Every frame, we make the agent move towards the player
        /// </summary>
        protected virtual void Update()
        {
            // Check if the player is within the detection radius of the drone
            if (Vector2.Distance(transform.position, player.transform.position) <= detectionRadius)
            {
                // If the player is within the detection radius, stop moving and face the player
                transform.position = transform.position;
                //transform.up = player.transform.position - transform.position;
            }
            else
            {
                // If the player is not within the detection radius, move towards the next patrol point
                transform.position = Vector2.MoveTowards(transform.position, patrolPoints[currentPatrolPoint].position, speed * Time.deltaTime);

                // If the drone has reached the patrol point, move to the next one
                if (Vector2.Distance(transform.position, patrolPoints[currentPatrolPoint].position) < 0.1f)
                {
                    currentPatrolPoint = (currentPatrolPoint + 1) % patrolPoints.Count;
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

