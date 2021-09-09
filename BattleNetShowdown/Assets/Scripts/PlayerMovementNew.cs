using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementNew : MonoBehaviour
{
    public static double top = -0.5, bottom = -2.5, left = -2.5, right = -0.5;

    public AudioSource stepSound;

    public GridManager battleGrid;

    void movePlayer(Vector2 direction)
    {
        //New Tile Check method
        Vector2 proposedNewPosition = (Vector2)transform.position + direction;
        //if(proposedNewPosition)
        Debug.DrawRay(proposedNewPosition, transform.TransformDirection(Vector2.right) * 0.25f, Color.red, 1f);


        //This block of code should be obsolete soon. Not that it really did anything useful but
        //I'm working on a better implementation.
        //Debug.Log(GetTile(proposedNewPosition));
        //Debug.DrawRay(transform.position + new Vector3(1, -0.5f, 0), transform.TransformDirection(Vector2.right) * shotDistance, Color.red, .5f);
        // RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(1, -0.5f, 0), transform.TransformDirection(Vector2.right), shotDistance);
        //Check the tag on the next square by using a raycast(?) to target the square. Then check the tag associtated
        //with that square. If it's red, allow the movement.
        // if (other.tag == "Red")


        Debug.Log("X: " + (proposedNewPosition.x + 3.5) + " Y: " + (proposedNewPosition.y + 3.5));

        //TODO: Do more testing on this.
        //GetComponent<GridManager>().GetTag(0,0);

        /*
        The idea is to check the tag at the proposed new position. If the tag is red,
        then it should allow the player to step there. Otherwise, no movement will occur.
        Currently I cannot get the tag of the sprite, or really get this function call
        to work :[
        */


        //Free movement
        // transform.position += direction;
        // stepSound.Play();


        //Old Box method
        if(proposedNewPosition.y <= top && proposedNewPosition.y >= bottom && proposedNewPosition.x >= left && proposedNewPosition.x <= right)
        {
        transform.position = (Vector2)transform.position + direction;
        stepSound.Play();
        }
    }

    void Update() //TODO: Implement the new Input Manager in Unity
    {
         if(Input.GetKeyDown(KeyCode.W))
            movePlayer(Vector2.up);
        if(Input.GetKeyDown(KeyCode.A))
            movePlayer(Vector2.left);
        if(Input.GetKeyDown(KeyCode.S))
            movePlayer(Vector2.down);
        if(Input.GetKeyDown(KeyCode.D))
              movePlayer(Vector2.right);
    }
}