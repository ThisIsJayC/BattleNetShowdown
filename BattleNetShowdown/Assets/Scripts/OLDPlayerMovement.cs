using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class OLDPlayerMovement : MonoBehaviour
{
    private bool isMoving;
    private Vector3 origPos, targetPos;

    [SerializeField]
    private float timeToMove, shotDistance;

    public AudioSource stepSound, shootSFX, slashSFX, hitSound;

    public Sprite idleSprite, shootingSprite, attackSprite;


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