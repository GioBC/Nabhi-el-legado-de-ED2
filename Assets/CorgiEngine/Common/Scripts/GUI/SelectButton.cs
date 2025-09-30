using System.Collections;
using System.Collections.Generic;
using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.CorgiEngine
{
	/// <summary>
	/// A simple component meant to be added to the pause button
	/// </summary>
	public class SelectButton : MonoBehaviour
	{
		/// Puts the game on pause
		public virtual void SelectButtonAction()
		{
			StartCoroutine(SelectButtonCo());
		}

		/// <summary>
		/// A coroutine used to trigger the pause event
		/// </summary>
		/// <returns></returns>
		protected virtual IEnumerator SelectButtonCo()
		{
			yield return null;
			// we trigger a Pause event for the GameManager and other classes that could be listening to it too
			CorgiEngineEvent.Trigger(CorgiEngineEventTypes.TogglePause);
		}
	}
}