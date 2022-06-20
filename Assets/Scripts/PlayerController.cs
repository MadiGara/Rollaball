using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
//already assigned to playerController bc we did it through add component
{
    public float speed = 0; //can see and change in inspector bc public!
    public TextMeshProUGUI countText; //holds reference to text UI of count - can change in inspector
    public GameObject winTextObject;

    private Rigidbody rb; //private = not accessible from inspector or other scripts
    private int count;
    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        //set value of rb by getting reference to rigidbody component attached to the Player
        rb = GetComponent<Rigidbody>();
        count = 0;

        SetCountText(); //calls the count display function we have below
        winTextObject.SetActive(false);
    }

    void OnMove(InputValue movementValue) 
    //InputValue is the variable type - captures movement of ball in x and y directions
    {
        //gets data along 2 vectors (x and y) from movementValue and stores it movementVector
        Vector2 movementVector = movementValue.Get<Vector2>(); //local var

        movementX = movementVector.x; //V2 types come with .x and .y members
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count >= 12)
        {
            //display win text if all objects collected
            winTextObject.SetActive(true);
        }
    }

    //add force to the Player's rigidbody
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        //force needs a V3 variable (x y and z)
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    //called when player game object first touches a trigger collider and refer to it as other
    {
        //checks tag - if collectable object, will deactivate game object
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count += 1;

            SetCountText();
        }
    }
}
