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
        /*
        The idea is to check the tag at the proposed new position. If the tag is red,
        then it should allow the player to step there. Otherwise, no movement will occur.
        */

        //New Tile Check method
        Vector2 proposedNewPosition = (Vector2)transform.position + direction;
        // Debug.Log("X: " + (proposedNewPosition.x + 3.5) + " Y: " + (proposedNewPosition.y + 3.5));

        int x = (int)(proposedNewPosition.x + 3.5);
        int y = (int)(proposedNewPosition.y + 3.5);

        if(x > 0 && y > 0 && y < GameObject.Find("Grid").GetComponent<GridManager>().vertical + 1) //TODO: don't hardcode these boundaries.
        {
            if(GameObject.Find("Grid").GetComponent<GridManager>().GetTag(x, y) == "Red")
            {
                transform.position = (Vector2)transform.position + direction;
                stepSound.Play();
            }

            if(GameObject.Find("Grid").GetComponent<GridManager>().GetTag(x, y) == "Blue")
                Debug.Log("You can't move here idiot.");
        }

        //Free movement
        // transform.position += direction;
        // stepSound.Play();


        //Old Box method
        // if(proposedNewPosition.y <= top && proposedNewPosition.y >= bottom && proposedNewPosition.x >= left && proposedNewPosition.x <= right)
        // {
        // transform.position = (Vector2)transform.position + direction;
        // stepSound.Play();
        // }
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