using UnityEngine;

public class AudioController : MonoBehaviour
{
    //audio source
    [SerializeField] private AudioSource AS;
    //min/max random sound pitch
    [SerializeField] private float minPitch, maxPitch;
    //play normal audio
    public void PlayAudio(AudioClip audio)
    {
        //playing audio
        AS.clip = audio;
        AS.Play();
    }
    //play audio with random pitch
    public void PlayAudioRandomPitch(AudioClip audio)
    {
        //getting random pitch
        float pitch = Random.Range(minPitch, maxPitch);
        AS.pitch = pitch;
        //playing audio
        AS.clip = audio;
        AS.Play();
    }
}
