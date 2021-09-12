using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyHP : MonoBehaviour
{
    public TextMesh enemyHPTextbox;
    public PlayerAnimations playerAnimations;

    public int enemyHP, maxHP, damage;

    public AudioSource enemyExplosionSFX;

    public bool enemyIsDead =false;
    public void TakeDamage(int damageTaken)
    {
        //Calculate damage
        enemyHP = enemyHP - damageTaken;

        //Debug.Log(transform.parent.name + " took " + damageTaken + " damage");

        //Deletes the parent object when the HP reaches 0
        if (enemyHP <= 0)
        {
            transform.parent.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine(killEnemy());
            IEnumerator killEnemy ()
            {
                Debug.Log("Enemy was destroyed");
                SetEnemyStatus(true);

                //These next three lines are a hacky way to disable the players movements, attacks, and hitbox TODO: Do this better?
                GameObject.Find("Player Sprite").GetComponent<PlayerAnimations>().enabled = false;
                GameObject.Find("Player").GetComponent<PlayerMovementNew>().enabled = false;
                GameObject.Find("Attack Queue").SetActive(false);
                GameObject.Find("Player Hitbox").SetActive(false);

                enemyExplosionSFX = GetComponent<AudioSource>();
                enemyExplosionSFX.Play();

                yield return new WaitForSeconds(enemyExplosionSFX.clip.length);
                transform.parent.gameObject.SetActive(false);
                //Destroy(transform.parent.gameObject); //or just delete it if you really are feeling spicy
            }
            enemyHP = 0;
        }
    }

    public void SetEnemyStatus(bool trueorfalse)
    {
        enemyIsDead = trueorfalse;
    }
    public bool GetEnemyStatus()
    {
        return enemyIsDead;
    }

    void Start()
    {
        //This is an extremely dirty way to typecast enemyHP as a string
        //enemyHPTextbox.text = "HP: " + enemyHP;
        enemyHPTextbox.text = enemyHP.ToString();
    }

    void Update()
    {
        enemyHPTextbox.text = enemyHP.ToString();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            enemyHP += 500;
        }
    }
}
