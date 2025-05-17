using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    //variables
    [SerializeField] AudioSource audioSource;

    //properties
    protected override bool persistent => false;

    //methods
    public void PlayAudio(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }

}
