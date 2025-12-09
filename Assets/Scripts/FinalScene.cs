using UnityEngine;

public class FinalScene : MonoBehaviour
{
    public Animator animator;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("CompleteAnimation", animator.GetCurrentAnimatorStateInfo(0).length);
        
    }

    void CompleteAnimation()
    {
        Application.Quit();
    }
}
