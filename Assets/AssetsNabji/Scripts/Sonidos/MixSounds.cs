using UnityEngine;
using UnityEngine.Audio;

public class MixSounds : MonoBehaviour
{
    public AudioMixer masterMixer;
    public AudioSource efxSource;

    //referencia a exposed parameters in the mixers
    public void SetEfectosVolumen(float fxVolume)
    {
        masterMixer.SetFloat("VolumenEffectos", fxVolume);
    }

    //referencia a exposed parameters in the mixers
    public void SetMusicaVolumen(float musicVolume)
    {
        masterMixer.SetFloat("VolumeMusica", musicVolume);
    }

    public void PlaySingle(AudioClip clip)
    {
        efxSource.clip = clip;
        efxSource.Play();
    }
}
