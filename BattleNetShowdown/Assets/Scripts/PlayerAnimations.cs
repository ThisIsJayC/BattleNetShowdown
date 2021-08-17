using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField]
    private float shotDistance;

    //TODO: reorganize these to be in alphabetical order
    public AudioSource shootSFX, slashSFX, hitSFX, punchSFX, throwSFX;
    
    public Sprite idleSprite, shootingSprite, slashSprite, punchSprite, throwSprite;

    void Hit(RaycastHit2D hit)
    {
        Debug.Log("Hit Something : " + hit.collider.name);
        hit.transform.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        hitSFX.Play();
    }   

    void Lob()
    {
        //TODO: Add throw animation
        this.gameObject.GetComponent<SpriteRenderer>().sprite = throwSprite;
        throwSFX.Play();

        //Destination, 3 squares ahead
        Vector3 targetLocation = transform.position + new Vector3(2.75f, -0.5f, 0);

        //Hits an enemy 3 squares away, after a 2 second delay
        StartCoroutine(LobWait(1.0f, targetLocation));

        IEnumerator LobWait(float s, Vector3 targetLocation)
        {   
            yield return new WaitForSeconds(s);
            //Purely for debugging purposes. Can see the target location 3 squares ahead
            Debug.DrawRay(targetLocation, transform.TransformDirection(Vector2.right) * .5f, Color.red, .5f);
            
            RaycastHit2D hit = Physics2D.Raycast(targetLocation, transform.TransformDirection(Vector2.right), .5f);
            if (hit)
            {
                Hit(hit);
            }
        }
    }

    void Punch()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = punchSprite;
        punchSFX.Play();

        //TODO: Add punch animation
        Debug.DrawRay(transform.position + new Vector3(0.75f, -0.5f, 0), transform.TransformDirection(Vector2.right) * .5f, Color.red, .5f);
        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(1, -0.5f, 0), transform.TransformDirection(Vector2.right), .45f);

        if(hit)
        {
            Hit(hit);
            //Knocks enemy back 1 square
            if(hit.transform.position.x != 2.5) //If enemy is at the end of the square, it will not push them back off of the battle grid.
            {
                hit.transform.position = hit.transform.position + new Vector3 (1, 0, 0);
            }
        }   
    }
    
    void Shoot()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = shootingSprite;
        Debug.DrawRay(transform.position + new Vector3(1, -0.5f, 0), transform.TransformDirection(Vector2.right) * shotDistance, Color.red, .5f);
        shootSFX.Play();
        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(1, -0.5f, 0), transform.TransformDirection(Vector2.right), shotDistance);

        //TODO: Add small hit particle animation
        if(hit)
        {
            Hit(hit);
        }  
    }

    void Slash()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = slashSprite;
        slashSFX.Play();

        //TODO: Add slash animation
        Debug.DrawRay(transform.position + new Vector3(1, -1.5f, 0), transform.TransformDirection(Vector2.up) * 2, Color.red, .5f);
        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(1, -1.5f, 0), transform.TransformDirection(Vector2.up), 1.95f);

        if(hit)
        {
            Hit(hit);
        }  
    }

    //Player controls
    void Update()
    {        
        //Lob Attack
        if(Input.GetKeyDown(KeyCode.V))
            Lob();
        if(Input.GetKeyUp(KeyCode.V))
            this.gameObject.GetComponent<SpriteRenderer>().sprite = idleSprite;  

        //Punch Attack
        if(Input.GetKeyDown(KeyCode.M))
            Punch();
        if(Input.GetKeyUp(KeyCode.M))
            this.gameObject.GetComponent<SpriteRenderer>().sprite = idleSprite;  

        //Shoot Attack
        if(Input.GetKeyDown(KeyCode.N))
            Shoot();
        if(Input.GetKeyUp(KeyCode.N))
            this.gameObject.GetComponent<SpriteRenderer>().sprite = idleSprite;

        //Slash Attack
        if(Input.GetKeyDown(KeyCode.B))
            Slash();
        if(Input.GetKeyUp(KeyCode.B))
            this.gameObject.GetComponent<SpriteRenderer>().sprite = idleSprite;  
    }
}