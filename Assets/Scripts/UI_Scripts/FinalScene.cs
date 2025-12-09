using UnityEngine;

public class FinalScene : MonoBehaviour
{
    public Animator animator;
    private AudioSource audioSource;
    public AudioClip audioClip;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.Play();
        animator.Play("FinalAnimation");
        Invoke("AnimationEnd", animator.GetCurrentAnimatorStateInfo(0).length + 0.01f);
    }

    void AnimationEnd()
    {
        audioSource.Stop();
        Application.Quit();
    }
}
