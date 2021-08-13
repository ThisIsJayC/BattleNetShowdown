using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField]
    private float shotDistance;

    public AudioSource shootSFX, slashSFX, hitSFX, punchSFX;
    
    public Sprite idleSprite, shootingSprite, slashSprite, punchSprite;

  void Shoot()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = shootingSprite;
        Debug.DrawRay(transform.position + new Vector3(1, -0.5f, 0), transform.TransformDirection(Vector2.right) * shotDistance, Color.red, .5f);
        shootSFX.Play();
        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(1, -0.5f, 0), transform.TransformDirection(Vector2.right), shotDistance);

        //TODO: Add small hit particle animation
        if(hit)
        {
            Debug.Log("Hit Something : " + hit.collider.name);
            hit.transform.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            hitSFX.Play();
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
            Debug.Log("Hit Something : " + hit.collider.name);
            hit.transform.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            //TODO: Check if enemy is at back edge of their set of squares
            //Knocks enemy back 1 square
            hit.transform.position = hit.transform.position + new Vector3 (1, 0, 0);
            hitSFX.Play();
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
            Debug.Log("Hit Something : " + hit.collider.name);
            hit.transform.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            hitSFX.Play();
        }
    }

    //Player controls
    void Update()
    {        
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
