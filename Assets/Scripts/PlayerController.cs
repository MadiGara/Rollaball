using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
//already assigned to playerController bc we did it through add component
{
    public float speed = 0; //can see and change in inspector bc public!

    private Rigidbody rb; //private = not accessible from inspector or other scripts
    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        //set value of rb by getting reference to rigidbody component attached to the Player
        rb = GetComponent<Rigidbody>();
    }

    void OnMove(InputValue movementValue) 
    //InputValue is the variable type - captures movement of ball in x and y directions
    {
        //gets data along 2 vectors (x and y) from movementValue and stores it movementVector
        Vector2 movementVector = movementValue.Get<Vector2>(); //local var

        movementX = movementVector.x; //V2 types come with .x and .y members
        movementY = movementVector.y;
    }

    //add force to the Player's rigidbody
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        //force needs a V3 variable (x y and z)
        rb.AddForce(movement * speed);
    }
}
