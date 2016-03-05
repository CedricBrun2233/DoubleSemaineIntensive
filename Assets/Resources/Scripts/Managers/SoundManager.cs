using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{

    static SoundManager instance;
    public static SoundManager Instance
    {
        get
        {
            return instance;
        }
    }
    void Awake()
    {
        instance = this;
    }
    AudioSource source;
    public AudioClip[] boing;
    public AudioClip[] destruction;
    public AudioClip diceShuffle;
    public AudioClip explosion;
    public AudioClip[] impact;


    public void PlaySound(GameObject target, AudioClip ac, float vol, bool changePitch)
    {
        if (!target.GetComponent<AudioSource>())
        {
            source = target.AddComponent<AudioSource>();
        }
        else
        {
            source = target.GetComponent<AudioSource>();
        }
        if (changePitch)
        {
            source.pitch = Random.Range(0.7f, 1.3f);
        }
        source.clip = ac;
        source.volume = vol;
        source.loop = false;
        source.Play();
    }
}