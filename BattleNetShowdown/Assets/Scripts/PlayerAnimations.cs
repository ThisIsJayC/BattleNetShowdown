using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField]
    private float shotDistance;

    public AudioSource blastSFX, chargeSFX, hitSFX, missedThrow, punchSFX, shootSFX, slashSFX, throwSFX;

    public Sprite idleSprite, shootingSprite, slashSprite, punchSprite, throwSprite;
    //TODO: Load these from the Resources folder
    //Maybe don't do this. It invloves making everything into a prefab.

    public Sprite punchAttackSprite;

    public Animator animator;


    private EnemyHP enemyHP;
    public ObjectHP objectHP;


    void Start()
    {
        enemyHP = FindObjectOfType<EnemyHP>();
        objectHP = FindObjectOfType<ObjectHP>(); //because of this
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
        animator.SetTrigger("Shooting");
        animator.SetBool("canAttack", false); //TODO: fix this so you can't trigger another attack until the animation is done

        StartCoroutine(BlastWait(0.5f));
        IEnumerator BlastWait(float s)
        {
            yield return new WaitForSeconds(s);

            Debug.DrawRay(transform.position + new Vector3(1, -0.5f, 0), transform.TransformDirection(Vector2.right) * shotDistance, Color.red, .5f);
            blastSFX.Play();
            RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(1, -0.5f, 0), transform.TransformDirection(Vector2.right), shotDistance);

            if (hit)
            {
                Hit(hit, 50);
                //enemyHP.TakeDamage(50);
            }
        }

        animator.SetTrigger("Idle");
    }
    public void Charge()
    {
        chargeSFX.Play();

    }

    public void Idle()
    {
        animator.SetBool("canAttack", true);
        //this.gameObject.GetComponent<SpriteRenderer>().sprite = idleSprite;
    }
    public void Lob()
    {
        animator.SetTrigger("Lobbing");
        animator.SetBool("canAttack", false); //TODO: fix this so you can't trigger another attack until the animation is done
        //TODO: Add throw animation

        throwSFX.Play();

        //Destination, 3 squares ahead
        Vector3 targetLocation = transform.position + new Vector3(2.75f, -0.5f, 0);

        //Hits an enemy 3 squares away, after a 1 second delay
        StartCoroutine(LobWait(1.0f, targetLocation));
        IEnumerator LobWait(float s, Vector3 targetLocation)
        {
            yield return new WaitForSeconds(s);
            //Purely for debugging purposes. Can see the target location 3 squares ahead
            Debug.DrawRay(targetLocation, transform.TransformDirection(Vector2.right) * .5f, Color.red, .5f);

            RaycastHit2D hit = Physics2D.Raycast(targetLocation, transform.TransformDirection(Vector2.right), .5f);
            if (hit)
            {
                Hit(hit, 50);
                //enemyHP.TakeDamage(50);
            }
            else
            {
                missedThrow.Play();
            }
        }

        animator.SetTrigger("Idle");
    }

    public void Punch()
    {
        animator.SetTrigger("Punching");
        animator.SetBool("canAttack", false); //TODO: fix this so you can't trigger another attack until the animation is done

        punchSFX.Play();

        //TODO: Add punch animation
        //TODO: call the punchAttackSprite 1 square ahead of the player, then destoy it after .5 seconds
        Debug.DrawRay(transform.position + new Vector3(0.75f, -0.5f, 0), transform.TransformDirection(Vector2.right) * .5f, Color.red, .5f);
        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(1, -0.5f, 0), transform.TransformDirection(Vector2.right), .45f);

        if(hit)
        {
            Hit(hit, 20);

            //Knocks enemy back 1 square
            //TODO: Update to have the enemy / object hit check if there is a valid tile behind it
            if(hit.transform.position.x != 2.5) //If enemy is at the end of the square, it will not push them back off of the battle grid.
            {
                hit.transform.position = hit.transform.position + new Vector3 (1, 0, 0);
            }
        }

        animator.SetTrigger("Idle");
    }

    public void Shoot()
    {
        animator.SetTrigger("Shooting");
        animator.SetBool("canAttack", false); //TODO: fix this so you can't trigger another attack until the animation is done

        shootSFX.Play();

        Debug.DrawRay(transform.position + new Vector3(1, -0.5f, 0), transform.TransformDirection(Vector2.right) * shotDistance, Color.red, .5f);
        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(1, -0.5f, 0), transform.TransformDirection(Vector2.right), shotDistance);

        //TODO: Add small hit particle animation
        if(hit)
        {
            Hit(hit, 10);
        }

        animator.SetTrigger("Idle");
    }

    public void Slash()
    {
        animator.SetTrigger("Slashing");
        animator.SetBool("canAttack", false); //TODO: fix this so you can't trigger another attack until the animation is done

        //slashSFX.Play();

        //TODO: Add slash animation
        Debug.DrawRay(transform.position + new Vector3(1, -1.5f, 0), transform.TransformDirection(Vector2.up) * 2, Color.red, .5f);
        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(1, -1.5f, 0), transform.TransformDirection(Vector2.up), 1.95f);

        if(hit)
        {
            Hit(hit, 100);
            //enemyHP.TakeDamage(100);
        }

        animator.SetTrigger("Idle");
    }

    //Player controls
    void Update() //TODO: Implement the new Input Manager
    {
        //Lob Attack
        if(Input.GetButtonDown("Fire1"))
            Lob();
        if(Input.GetKeyDown(KeyCode.V) || Input.GetButtonDown("Fire1"))
            Lob();
        if(Input.GetKeyUp(KeyCode.V) || Input.GetButtonUp("Fire1"))
            Idle();

        //Punch Attack
        if(Input.GetKeyDown(KeyCode.M) || Input.GetButtonDown("Fire2"))
            Punch();
        if(Input.GetKeyUp(KeyCode.M) || Input.GetButtonUp("Fire2"))
            Idle();

        //Shoot Attack
        if(Input.GetKeyDown(KeyCode.N) || Input.GetButtonDown("Fire3"))
            Shoot();
        if(Input.GetKeyUp(KeyCode.N) || Input.GetButtonUp("Fire3"))
            Idle();

        //Slash Attack
        if(Input.GetKeyDown(KeyCode.B) || Input.GetButtonDown("Fire4"))
            Slash();
        if(Input.GetKeyUp(KeyCode.B) || Input.GetButtonUp("Fire4"))
            Idle();
    }
}