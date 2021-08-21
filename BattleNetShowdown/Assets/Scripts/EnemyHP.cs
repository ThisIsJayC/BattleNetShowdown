using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyHP : MonoBehaviour
{
    public TextMesh enemyHPTextbox;

    public int enemyHP, maxHP;

    public AudioSource enemyHitSFX;

    public int damage;
    public void TakeDamage(int damageTaken)
    {
        //Calculate damage
        enemyHP = enemyHP - damageTaken;


        Debug.Log(transform.parent.name + " took " + damageTaken + " damage");



        //Deletes the parent object when the HP reaches 0
        if (enemyHP <= 0)
        {
            Debug.Log("Enemy was destroyed");
            enemyHitSFX = GetComponent<AudioSource>();
            enemyHitSFX.Play();
            //Deletes the game object too fast. Doesn't even play the sound :[
            //transform.parent.gameObject.SetActive(false);
            //Destroy(transform.parent.gameObject);
            enemyHP = 0;
        }
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
            //enemyHPTextbox.text = enemyHP.ToString();
        }
    }
}
