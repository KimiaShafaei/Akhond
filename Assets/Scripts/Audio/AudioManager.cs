using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Sources")]
    [SerializeField]
    private AudioSource MusicSource;
    [SerializeField]
    private AudioSource SFXSource;

    [Header("Audio Clips")]
    public AudioClip BackgroundMusic;
    public AudioClip Jump;
    public AudioClip Death;
    public AudioClip ItemPickup;
    public AudioClip ShrineActivate;
    public AudioClip FinalDoor;
    public AudioClip ButtonActivatePower;
    public AudioClip ButtonUI;

private void Awake()
{
    DontDestroyOnLoad(gameObject);
    SceneManager.sceneLoaded += OnSceneLoaded;
}
    private void Start()
    {
        MusicSource.clip = BackgroundMusic;
        MusicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void StopBackgroundMusic()
    {
        MusicSource.Stop();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "StartMenu")
        {
            StopBackgroundMusic();
        }
        
    }
}
