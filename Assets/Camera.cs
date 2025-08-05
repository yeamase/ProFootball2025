using UnityEngine;
public class FollowPlayer : MonoBehaviour
{
    public Vector3 offset;
    public GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}