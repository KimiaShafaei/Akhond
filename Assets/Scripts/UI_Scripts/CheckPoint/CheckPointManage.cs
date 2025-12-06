using UnityEngine;

public class CheckPointManage : MonoBehaviour
{
    public static CheckPointManage instance;

    [SerializeField]
    private Vector2 start_point_position;

    private Vector2 current_check_point_position;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        current_check_point_position = start_point_position;
    }

    public void SetCheckPointPosition(Transform new_check_point_position)
    {
        current_check_point_position = new_check_point_position.position;
    }

    public void ReturnPlayer(GameObject player)
    {
        player.transform.position = current_check_point_position;
    }
}
