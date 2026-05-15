using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class Sliders : MonoBehaviour
{
    public Slider MusicSlider;
    public Slider SFXSlider;
    public AudioMixer AudioMixer;

    public TextMeshProUGUI MusicText;
    public TextMeshProUGUI SFXText;

    public const string MIXER_MUSIC = "MusicVolume";
    public const string MIXER_SFX = "SfxVolume";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MusicSlider.onValueChanged.AddListener(SetMusicVolume);

        SFXSlider.onValueChanged.AddListener(SetSFXVolume);

        MusicSlider.onValueChanged.AddListener((v) => {
            MusicText.text = v.ToString("0%");
        });

        SFXSlider.onValueChanged.AddListener((v) => {
            SFXText.text = v.ToString("0%");
        });

        MusicSlider.value = PlayerPrefs.GetFloat(AudioManager.MUSIC_KEY, 1f);
        SFXSlider.value = PlayerPrefs.GetFloat(AudioManager.SFX_KEY, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SetMusicVolume(float value)
    {
        AudioMixer.SetFloat(MIXER_MUSIC, Mathf.Log10(value) * 20);
    }


    public void SetSFXVolume(float value)
    {
        AudioMixer.SetFloat(MIXER_SFX, Mathf.Log10(value) * 20);
    }

    public void OnDisable()
    {
        PlayerPrefs.SetFloat(AudioManager.MUSIC_KEY, MusicSlider.value);
        PlayerPrefs.SetFloat(AudioManager.SFX_KEY, SFXSlider.value);
    }
}
