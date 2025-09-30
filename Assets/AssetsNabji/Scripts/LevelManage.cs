using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine.UI;


public class LevelManage : MonoBehaviour
{
    public Slider volumeFX;
    public Slider volumeMaster;
    public Toggle mute;
    public AudioMixer mixer;
    public AudioSource fxSource;
    public AudioClip clickSound;
    private float lastvolume;

    private void Awake()
    {
        volumeFX.onValueChanged.AddListener(ChangevolumeFX);
        volumeMaster.onValueChanged.AddListener(ChangevolumeMaster);
    }

    public void SetMute()
    {

        if (mute.isOn)
        {
            mixer.GetFloat("VolMaster", out lastvolume);
            mixer.SetFloat("VolMaster", -80);
        }
        else
            mixer.SetFloat("VolMaster", lastvolume);
    }

    public void OpenPanel(GameObject panel)
    {
        PlaySoundButton();
    }
    public void CargarNivel(string NombreNivel)
    {
        SceneManager.LoadScene(NombreNivel);
    }

    public void Salir()
    {
        Application.Quit();
    }

   public void ChangevolumeMaster(float v)
    {
        mixer.SetFloat("VolMaster", v);
    }
    
    public void ChangevolumeFX(float v)
    {
        mixer.SetFloat("VolFX", v);
    }

    public void PlaySoundButton()
    {
        fxSource.PlayOneShot(clickSound);
    }
}
