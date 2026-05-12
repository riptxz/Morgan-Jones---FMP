using UnityEngine;

public class SFXManager : MonoBehaviour
{

    public static SFXManager instance;
    public Sound[] sounds;
    public AudioClip[] audioClip;
    public AudioSource audioSource;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound()
    {
        audioSource.Play();
    }
}
