using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AMute()
    {
        AudioManager.instance.Mute();
    }

    public void AUnmute()
    {
        AudioManager.instance.Unmute();
    }

    public void SPlaySound()
    {
        SFXManager.instance.PlaySound();
    }
}
