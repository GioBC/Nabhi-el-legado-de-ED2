using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;
namespace MoreMountains.CorgiEngine
{
    public class EnemyFollower : MonoBehaviour, MMEventListener<CorgiEngineEvent>
    {
        public float speed;
        public float stoppingDistance;
        public float retreatDistance;
        public float range;
        bool isFacingRight;
        protected Transform _target;




        protected virtual void Initialization()
        {
            if (LevelManager.Instance.Players.Count == 0)
            {
                return;
            }
            // we get the player
            _target = LevelManager.Instance.Players[0].transform;




        }

        // Update is called once per frame
        protected virtual void LateUpdate()
        {



            if (Vector2.Distance(transform.position, _target.position) < range)
            {
                if (Vector2.Distance(transform.position, _target.position) > stoppingDistance)
                {
                    transform.position = Vector2.MoveTowards(transform.position, _target.position, speed * Time.deltaTime);
                }
                else if (Vector2.Distance(transform.position, _target.position) < stoppingDistance && Vector2.Distance(transform.position, _target.position) > retreatDistance)
                {
                    transform.position = this.transform.position;
                }
                else if (Vector2.Distance(transform.position, _target.position) < retreatDistance)
                {
                    transform.position = Vector2.MoveTowards(transform.position, _target.position, -speed * Time.deltaTime);
                }

                if (_target.position.x > transform.position.x)
                {
                    //face right
                    if (!isFacingRight)
                    {
                        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                        isFacingRight = true;
                    }
                }
                else if (_target.position.x < transform.position.x)
                {
                    //face left
                    if (isFacingRight)
                    {
                        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                        isFacingRight = false;
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
