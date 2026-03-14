using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _music;

    [SerializeField] private AudioSource _SoundEffect;

    public AudioClip Level1;

    public AudioClip Level2;
    
    public AudioClip Level3;

    public AudioClip Level4;

    public AudioClip PlatineScratch;

    public AudioClip Waves;

    public AudioClip Jump;

    public AudioClip Succes;

    public AudioClip Failure;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayLevelMusic(SceneManager.GetActiveScene().name);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(AudioClip clip)
    {
        _SoundEffect.PlayOneShot(clip);
    }
    
    private void PlayLevelMusic(string sceneName)
    {
        AudioClip clipToPlay = null;

        switch (sceneName)
        {
            case "Level1":
                clipToPlay = Level1;
                break;
            case "Level2":
                clipToPlay = Level2;
                break;
            case "Level3":
                clipToPlay = Level3;
                break;
            case "Level4":
                clipToPlay = Level4;
                break;
        }

        if (clipToPlay != null)
        {
            _music.clip = clipToPlay;
            _music.Play();
        }
    }
    
}
