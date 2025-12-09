using UnityEngine;

public class Star : MonoBehaviour
{
    private bool collected = false;
    private Vector3 original_position;

    void Start()
    {
        original_position = transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collected)
        {
            collected = true;
            StarManager.instance.AddStar();
            gameObject.SetActive(false);
        }
    }

    public void ResetStar()
    {
        collected = false;
        transform.position = original_position;
        gameObject.SetActive(true);
    }
}
