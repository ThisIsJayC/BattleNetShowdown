using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{


    [SerializeField]
    private float shotDistance;

    public AudioSource shootSFX, slashSFX, hitSound;
    
    public Sprite idleSprite, shootingSprite, attackSprite;

    void Slash()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = attackSprite;
        slashSFX.Play();

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
        //shootSFX.Play();
        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3Int(1, 0, 0), transform.TransformDirection(Vector2.right), shotDistance);

        if(hit)
        {
            Debug.Log("Hit Something : " + hit.collider.name);
            hit.transform.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
           // hitSound.Play();
        }
    }



    // Update is called once per frame
    void Update()
    {
        
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
}
