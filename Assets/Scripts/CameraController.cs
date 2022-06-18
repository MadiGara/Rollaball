using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        //find difference between distance of player and camera
        offset = transform.position - player.transform.position;
    }

    // Camera won't change until player has moved for that frame
    void LateUpdate()
    {
        //only matches position and not rotation of the sphere
        transform.position = player.transform.position + offset;
    }
}
