using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class ManagerScene : MonoBehaviour 
{
	
	public static ManagerScene instance = null;
    [SerializeField]private Animator fadeAnimation;
	[SerializeField]private SceneController control;
	[SerializeField] private AudioMixer masterMixer;

    public void loadScene(string NameSceneToLoad)
	{
		StartCoroutine(_loadScene(NameSceneToLoad));
    }
    

    private IEnumerator _loadScene(string sceneName)
    {
        yield return new WaitForEndOfFrame();
		//masterMixer.SetFloat("VolumeMaster",Mathf.Lerp(0, -80, Time.deltaTime));
        fadeAnimation.SetTrigger("FadeIn");
		yield return new WaitForSeconds(1f);
        yield return StartCoroutine(control.IUnloadAllScenes());
        //EditorUtility.UnloadUnusedAssetsImmediate();
        Resources.UnloadUnusedAssets();
        yield return StartCoroutine(control.ILoadScene(sceneName, true));
        yield return new WaitForEndOfFrame();
        //masterMixer.SetFloat("VolumeMaster", Mathf.Lerp(0, 80, Time.deltaTime));
		fadeAnimation.SetTrigger ("FadeOut");
     }

    public void reloadScene(string nameNameSceneToReLoad)
    {
        StartCoroutine(_ReloadScene(nameNameSceneToReLoad));

    }

    private IEnumerator _ReloadScene(string sceneName)
    {
        yield return new WaitForEndOfFrame();
        fadeAnimation.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        yield return control.IReloadScene(sceneName);
        yield return new WaitForEndOfFrame();
        fadeAnimation.SetTrigger("FadeOut");
    }

}
