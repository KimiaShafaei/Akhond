using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private float follow_speed = 2.0f;

    [SerializeField]
    private float y_offset = 1.0f;
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        Vector3 new_position = new Vector3(target.position.x, target.position.y + y_offset, -10f);
        transform.position = Vector3.Slerp(transform.position, new_position, follow_speed * Time.deltaTime);  
    }
}
