using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform posA;
    public Transform posB;
    public float speed = 2f;
    private Vector3 target_position;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target_position = posB.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, posA.position) < 0.05f)
        {
            target_position = posB.position;
        }
        if (Vector2.Distance(transform.position, posB.position) < 0.05f)
        {
            target_position = posA.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, target_position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.collider.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.collider.transform.SetParent(null);
        }
    }
}
