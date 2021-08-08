using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementNew : MonoBehaviour
{
    private bool isMoving; //
    private Vector3 origPos, targetPos; //

    [SerializeField]
    private float timeToMove;

    public AudioSource stepSound;

/*
    So far so good btw
*/

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W) && !isMoving)
            StartCoroutine(MovePlayer(Vector3.up));
        if(Input.GetKeyDown(KeyCode.A) && !isMoving)
            StartCoroutine(MovePlayer(Vector3.left));
        if(Input.GetKeyDown(KeyCode.S) && !isMoving)
            StartCoroutine(MovePlayer(Vector3.down));
        if(Input.GetKeyDown(KeyCode.D) && !isMoving)
            StartCoroutine(MovePlayer(Vector3.right));
  
    }


    private IEnumerator MovePlayer(Vector3 direction)
    {
        isMoving = true;  
        float elapsedTime = 0;
        origPos= transform.position;
        targetPos = origPos + direction;

        while (elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(origPos, targetPos, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPos;
        stepSound.Play();
        isMoving = false;
        Debug.Log("Player moved : " + transform.position);
    }
}