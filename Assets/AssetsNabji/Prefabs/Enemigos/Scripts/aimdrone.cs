using UnityEngine;
using System.Collections;
using MoreMountains.Tools;

namespace MoreMountains.CorgiEngine
{
	/// <summary>
	/// Add this script to a CharacterBehavior+CorgiController2D object to make it follow (or try to follow) Player1
	/// So far the Follower will move horizontally towards the player, and use a jetpack to reach it, or jump above obstacles.
	/// </summary>

	public class aimdrone : MonoBehaviour, MMEventListener<CorgiEngineEvent>
	{
		

		// private stuff 
		protected Transform _target;
		private Vector3 thisPos;
		private Vector3 targetPos;
		private float angle;
		public float minZRot;
		public float maxZRot;
		public float offset;
		private float turret;
		private Transform localTransform;
		public bool _facing;

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
			_target = LevelManager.Instance.Players[0].transform;
			localTransform = GetComponent<Transform>();
			

		}

        

        /// <summary>
        /// Every frame, we make the agent move towards the player
        /// </summary>
        protected virtual void Update()
		{
			thisPos = localTransform.position;
			targetPos = _target.position;
			targetPos.x = targetPos.x - thisPos.x;
			targetPos.y = targetPos.y - thisPos.y;
			angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
			_facing = this.transform.parent.GetComponent<Waypoints>().isFacingRight;

			if (_facing && (angle >= -90 && angle <= 90))
			{
				transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Clamp(angle, -90, 90)));
			}
			
			

			else if (!_facing && (angle >= -180 && angle <= -90))
			{
				transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Clamp(angle, -180, -90)));
			}

            
            
			else if (!_facing && (angle >= 90 && angle <= 180))
			{
				transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Clamp(angle, 90, 180)));
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