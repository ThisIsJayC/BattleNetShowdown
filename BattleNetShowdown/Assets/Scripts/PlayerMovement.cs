using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class PlayerMovement : MonoBehaviour
{
    private bool isMoving;
    private Vector3 origPos, targetPos;

    [SerializeField]
    private float timeToMove, shotDistance;

    public AudioSource stepSound, shootSFX, slashSFX, hitSound;

    public Sprite idleSprite, shootingSprite, attackSprite;

    void Slash()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = attackSprite;
        slashSFX.Play();

/*

*/
        Debug.DrawRay(transform.position + new Vector3Int(1, 0, 0), transform.TransformDirection(Vector2.right) * .45f, Color.red, .5f);
        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3Int(1, 0, 0), transform.TransformDirection(Vector2.right), .45f);

        if(hit)
        {
            Debug.Log("Hit Something : " + hit.collider.name);
            hit.transform.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            hitSound.Play();
        }


    }

  void Shoot()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = shootingSprite;
        Debug.DrawRay(transform.position + new Vector3Int(1, 0, 0), transform.TransformDirection(Vector2.right) * shotDistance, Color.red, .5f);
        shootSFX.Play();
        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3Int(1, 0, 0), transform.TransformDirection(Vector2.right), shotDistance);

        if(hit)
        {
            Debug.Log("Hit Something : " + hit.collider.name);
            hit.transform.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            hitSound.Play();
        }
    }

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

        //Buster Attack
        if(Input.GetKeyDown(KeyCode.Space))
            Shoot();
        if(Input.GetKeyUp(KeyCode.Space))
            this.gameObject.GetComponent<SpriteRenderer>().sprite = idleSprite;

        //Chip Attack
        if(Input.GetKeyDown(KeyCode.RightAlt))
            Slash();
        if(Input.GetKeyUp(KeyCode.RightAlt))
            this.gameObject.GetComponent<SpriteRenderer>().sprite = idleSprite;    
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