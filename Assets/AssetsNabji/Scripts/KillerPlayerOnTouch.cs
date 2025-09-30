using System.Collections;
using UnityEngine;
using MoreMountains.Tools;
using MoreMountains.CorgiEngine;

public class KillerPlayerOnTouch : MonoBehaviour
{
    
		/// <summary>
		/// When a collision is triggered, check if the thing colliding is actually the player. If yes, kill it.
		/// </summary>
		/// <param name="collider">The object that collides with the KillPlayerOnTouch object.</param>
	
		protected virtual void OnTriggerEnter3D(Collider3D collider)
	{
		Character character = collider.GetComponent<Character>();

		if (character == null)
		{
			return;
		}

		if (character.CharacterType != Character.CharacterTypes.Player)
		{
			return;
		}

		if (character.ConditionState.CurrentState != CharacterStates.CharacterConditions.Dead)
		{
			LevelManager.Instance.KillPlayer(character);
		}
	}
}

