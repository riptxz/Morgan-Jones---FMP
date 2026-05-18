using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;
    public Sound[] sounds;
    public float MusicVolume, SFXVolume;
    public AudioMixer AudioMixer;
    public AudioSource audioSource;

    public const string MUSIC_KEY = "MusicVolume";
    public const string SFX_KEY = "SfxVolume";


    private void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;


            s.source.volume = s.volume;
            float pitch = s.pitch;
            s.source.pitch = pitch;
            s.source.loop = s.loop;

            s.source.outputAudioMixerGroup = s.mixerGroup;
        }


        // if instance is null, store a reference to this instance
        if (instance == null)
        {
            // a reference does not exist, so store it
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Another instance of this gameobject has been made so destroy it
            // as we already have one
            Destroy(gameObject);
        }

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (PlayerPrefs.HasKey("MusicVolume") == true)
        {

            //retrieve it and store it in a variable
            MusicVolume = PlayerPrefs.GetFloat("MusicVolume");
        }
        else
        {
            // the key is null 
            PlayerPrefs.SetFloat("MusicVolume", 1);
        }

        LoadVolume();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadVolume()
    {
        float MusicVolume = PlayerPrefs.GetFloat(MUSIC_KEY, 1f);
        float SFXVolume = PlayerPrefs.GetFloat(SFX_KEY, 1f);

        AudioMixer.SetFloat(Sliders.MIXER_MUSIC, Mathf.Log10(MusicVolume) * 20);
        AudioMixer.SetFloat(Sliders.MIXER_SFX, Mathf.Log10(SFXVolume) * 20);
    }

    public void Mute()
    {
        audioSource.mute = true;
    }

    public void Unmute()
    {
        audioSource.mute = false;
    }

    
}
