using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementNew : MonoBehaviour
{
    public static double top = -0.5, bottom = -2.5, left = -2.5, right = -0.5;

    public AudioSource stepSound;

    void movePlayer(Vector3 direction)
    {
        Vector3 proposedNewPosition = transform.position + direction;
        //if(proposedNewPosition)
        Debug.DrawRay(proposedNewPosition, transform.TransformDirection(Vector2.right) * 0.25f, Color.red, 1f);
        //Debug.Log(GetTile(proposedNewPosition));
        //Debug.DrawRay(transform.position + new Vector3(1, -0.5f, 0), transform.TransformDirection(Vector2.right) * shotDistance, Color.red, .5f);
        // RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(1, -0.5f, 0), transform.TransformDirection(Vector2.right), shotDistance);
        //Check the tag on the next square by using a raycast(?) to target the square. Then check the tag associtated
        //with that square. If it's red, allow the movement.
        // if (other.tag == "Red")

        if(proposedNewPosition.y <= top && proposedNewPosition.y >= bottom && proposedNewPosition.x >= left && proposedNewPosition.x <= right)
        {
        transform.position += direction;
        stepSound.Play();
        }
    }

    void Update()
    {
        // For Joystick movement
        //transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal")/10, Input.GetAxisRaw("Vertical")/10,0f)) ;

        if(Input.GetKeyDown(KeyCode.W))
            movePlayer(Vector3.up);
        if(Input.GetKeyDown(KeyCode.A))
            movePlayer(Vector3.left);
        if(Input.GetKeyDown(KeyCode.S))
            movePlayer(Vector3.down);
        if(Input.GetKeyDown(KeyCode.D))
              movePlayer(Vector3.right);
    }
}