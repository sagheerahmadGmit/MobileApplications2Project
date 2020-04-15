using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    //make a Sound array from the sound class
    public Sound[] sounds;

    //get the audio manager instance
    public static AudioManager instance;

    // Start is called before the first frame update
    void Awake()
    {
        //destroy the second instance of the gameobject
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        //dont destroy the theme sound when a new scene is loaded
        DontDestroyOnLoad(gameObject);

        //loop through the sound array list
        foreach(Sound s in sounds)
        {
            //add a audio source component to the current object
            s.source = gameObject.AddComponent<AudioSource>();

            //control the audio source variables
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    //play the theme music in the background
    void Start()
    {
        Play("Theme");
    }

    // Update is called once per frame
    public void Play(string name)
    {
        //get the sound with the following name from the array
        Sound s = Array.Find(sounds, sound => sound.name == name);
        
        //If the script is asking for a name that doesn't exist then print out the error
        if (s == null)
        {
            Debug.LogWarning("Sound " + name + " not found");
            return;
        }

        //play the sound
        s.source.Play();
    }
}
