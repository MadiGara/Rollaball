using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    //make pickup GO spin while game is active
    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
        //difference in seconds since last frame occurred ^. Helps make things smooth
    }
}
