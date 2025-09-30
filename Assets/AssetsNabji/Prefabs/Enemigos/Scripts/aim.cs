using UnityEngine;
using System.Collections;
using MoreMountains.Tools;

namespace MoreMountains.CorgiEngine
{
	/// <summary>
	/// Add this script to a CharacterBehavior+CorgiController2D object to make it follow (or try to follow) Player1
	/// So far the Follower will move horizontally towards the player, and use a jetpack to reach it, or jump above obstacles.
	/// </summary>

	public class aim : MonoBehaviour, MMEventListener<CorgiEngineEvent>
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
			turret = this.transform.parent.rotation.eulerAngles.z;
			localTransform = GetComponent<Transform>();


		}

		/// <summary>
		/// Every frame, we make the agent move towards the player
		/// </summary>
		protected virtual void LateUpdate()
		{
			
			thisPos = localTransform.position;
			targetPos = _target.position;
			targetPos.x = targetPos.x - thisPos.x;
			targetPos.y = targetPos.y - thisPos.y;
			angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
			

			
			if (turret <90)
			{
				transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Clamp(angle, minZRot+turret, maxZRot + turret)));
			}
			
			else if(angle<0)
			{
				transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Clamp(angle+360, minZRot+turret, maxZRot+turret+offset)));
			}

			else 
			{
				transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Clamp(angle, minZRot + turret, maxZRot + turret+offset)));
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