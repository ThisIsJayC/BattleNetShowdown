using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimations : MonoBehaviour
{
    [SerializeField]
    private float shotDistance;

    //public AudioSource blastSFX, chargeSFX, hitSFX, missedThrow, punchSFX, shootSFX, slashSFX, throwSFX;

    //public Sprite idleSprite, shootingSprite, slashSprite, punchSprite, throwSprite;
    //TODO: Load these from the Resources folder
    //Maybe don't do this. It invloves making everything into a prefab.

    //public Sprite punchAttackSprite;

    [SerializeField]
    private EnemyHP enemyHP; //TODO: Update to Player HP
    public ObjectHP objectHP;

    //TODO: Refactor damage system so so the HP script is character / object agnostic


    void Start()
    {
        //objectHP = FindObjectOfType<ObjectHP>();
        objectHP = FindObjectOfType<ObjectHP>();
        //enemyHP = FindObjectOfType<EnemyHP>(); //TODO: Update to Player HP
    }

    void Hit(RaycastHit2D hit, int damage)
    {
        //Debug.Log("Hit Something : " + hit.collider.name);
        hit.transform.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        //hitSFX.Play();
        objectHP.TakeDamage(hit, damage);
    }

    public void Blast()
    {
        // this.gameObject.GetComponent<SpriteRenderer>().sprite = shootingSprite;
        StartCoroutine(BlastWait(0.5f));

        IEnumerator BlastWait(float s)
        {
            //this.gameObject.GetComponent<SpriteRenderer>().sprite = shootingSprite;
            yield return new WaitForSeconds(s);

            Debug.DrawRay(transform.position + new Vector3(-1, -0.5f, 0), transform.TransformDirection(Vector2.left) * shotDistance, Color.red, .5f);
            //blastSFX.Play();
            RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(-1, -0.5f, 0), transform.TransformDirection(Vector2.left), shotDistance);

            if (hit)
            {
                Hit(hit, 50);
                // enemyHP.TakeDamage(50);
                //objectHP.TakeDamage(hit, 50);
            }
            //this.gameObject.GetComponent<SpriteRenderer>().sprite = idleSprite;
        }
    }
    public void Charge()
    {
        //chargeSFX.Play();
    }

    public void Idle()
    {
        // this.gameObject.GetComponent<SpriteRenderer>().sprite = idleSprite;
    }
    public void Lob()
    {
        //TODO: Add throw animation

        //New method. Requires a prefab
        //this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<SpriteRenderer>("Lob").sprite;


        // this.gameObject.GetComponent<SpriteRenderer>().sprite = throwSprite;


        // throwSFX.Play();

        //Destination, 3 squares ahead
        Vector3 targetLocation = transform.position + new Vector3(2.75f, -0.5f, 0);

        //Hits an enemy 3 squares away, after a 1 second delay
        StartCoroutine(LobWait(1.0f, targetLocation));

        IEnumerator LobWait(float s, Vector3 targetLocation)
        {
            yield return new WaitForSeconds(s);
            //Purely for debugging purposes. Can see the target location 3 squares ahead
            Debug.DrawRay(targetLocation, transform.TransformDirection(Vector2.left) * .5f, Color.red, .5f);

            RaycastHit2D hit = Physics2D.Raycast(targetLocation, transform.TransformDirection(Vector2.left), .5f);
            if (hit)
            {
                Hit(hit, 70);
                // enemyHP.TakeDamage(50); //TODO: Update to Player HP
            }
            else
            {
                //missedThrow.Play();
            }
        }
    }

    public void Punch()
    {
        // this.gameObject.GetComponent<SpriteRenderer>().sprite = punchSprite;
        //punchSFX.Play();

        //TODO: Add punch animation
        //TODO: call the punchAttackSprite 1 square ahead of the enemy, then destoy it after .5 seconds
        Debug.DrawRay(transform.position + new Vector3(0.75f, -0.5f, 0), transform.TransformDirection(Vector2.left) * .5f, Color.red, .5f);
        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(-1, -0.5f, 0), transform.TransformDirection(Vector2.left), .45f);

        if(hit)
        {
            Hit(hit, 80);
            // enemyHP.TakeDamage(20); //TODO: Update to Player HP
            //Knocks enemy back 1 square
            if(hit.transform.position.x != 2.5) //If enemy is at the end of the square, it will not push them back off of the battle grid.
            {
                hit.transform.position = hit.transform.position + new Vector3(-1, 0, 0);
            }
        }
    }

    public void Shoot()
    {
        // this.gameObject.GetComponent<SpriteRenderer>().sprite = shootingSprite;
        Debug.DrawRay(transform.position + new Vector3(-1, -0.5f, 0), transform.TransformDirection(Vector2.left) * shotDistance, Color.red, .5f);
        //shootSFX.Play();
        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(-1, -0.5f, 0), transform.TransformDirection(Vector2.left), shotDistance);

        //TODO: Add small hit particle animation
        if(hit)
        {
            Hit(hit, 10);
            // enemyHP.TakeDamage(10); //TODO: Update to Player HP
        }
    }

    public void Slash()
    {
        // this.gameObject.GetComponent<SpriteRenderer>().sprite = slashSprite;
        //slashSFX.Play();

        //TODO: Add slash animation
        Debug.DrawRay(transform.position + new Vector3(-1, -1.5f, 0), transform.TransformDirection(Vector2.up) * 2, Color.red, .5f);
        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(-1, -1.5f, 0), transform.TransformDirection(Vector2.up), 1.95f);

        if(hit)
        {
            Hit(hit, 100);
            // enemyHP.TakeDamage(100); //TODO: Update to Player HP
        }
    }
}