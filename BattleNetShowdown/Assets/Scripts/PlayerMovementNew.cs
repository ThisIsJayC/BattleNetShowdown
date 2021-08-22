using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementNew : MonoBehaviour
{
    private bool isMoving; //
    private Vector3 origPos, targetPos; //

    public static double top = -0.5, bottom = -2.5, left = -2.5, right = -0.5;

    // [SerializeField]
    // private float timeToMove;

    public AudioSource stepSound;


    void movePlayer(Vector3 direction)
    {
        Vector3 proposedNewPosition = transform.position + direction;
        //Vector3 currentPosition = transform.position;
          //                      top                            bottom                          left                           right
         if(proposedNewPosition.y <= top && proposedNewPosition.y >= bottom && proposedNewPosition.x >= left && proposedNewPosition.x <= right)
            {
            transform.position += direction;
            stepSound.Play();
            }
    }

//Y < 1 && Y > -1 && X > -1 && X < 1

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
            movePlayer(Vector3.up);
            // transform.position += Vector3.up;
        if(Input.GetKeyDown(KeyCode.A))
            movePlayer(Vector3.left);
        if(Input.GetKeyDown(KeyCode.S))
            movePlayer(Vector3.down);
        if(Input.GetKeyDown(KeyCode.D))
              movePlayer(Vector3.right);
    }
}