using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioSource AS;
    [SerializeField] private float minPitch, maxPitch;
    public void PlayAudio(AudioClip audio)
    {
        AS.clip = audio;
        AS.Play();
    }
    public void PlayAudioRandomPitch(AudioClip audio)
    {
        float pitch = Random.Range(minPitch, maxPitch);
        AS.pitch = pitch;
        AS.clip = audio;
        AS.Play();
    }
}
