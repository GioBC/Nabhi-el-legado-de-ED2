using UnityEngine;

public class Settings : MonoBehaviour
{
    void Awake()
    {
        Application.backgroundLoadingPriority = ThreadPriority.Low;
        Application.targetFrameRate = 60;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
}
