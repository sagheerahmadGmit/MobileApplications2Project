using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    //name of the sound
    public string name;
    //AudioClip used for the sound
    public AudioClip clip;

    //decide the volume and pitch of the audio to match preference
    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;
    
    //to loop the audio if needed
    public bool loop;

    //get the audio source
    [HideInInspector]
    public AudioSource source;
}
