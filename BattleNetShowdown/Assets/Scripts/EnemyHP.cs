using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyHP : MonoBehaviour
{
    public TextMesh enemyHPTextbox;

    public int enemyHP, maxHP;
    
    public AudioSource enemyHitSFX;

    public int damage;
    public void TakeDamage(int damage)
    {
        //Calculate damage
        enemyHP = enemyHP - damage;

        Debug.Log(transform.parent.name + " took " + damage + " damage");

        //Deletes the parent object when the HP reaches 0
        if (enemyHP <= 0)
        {
            Debug.Log("Enemy was destroyed");
            enemyHitSFX = GetComponent<AudioSource>();
            enemyHitSFX.Play();
            //Deletes the game object too fast. Doesn't even play the sound :[
            //transform.parent.gameObject.SetActive(false);    
            //Destroy(transform.parent.gameObject);
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
        if(Input.GetKeyDown(KeyCode.Space))
        {
        TakeDamage(damage);
        enemyHPTextbox.text = enemyHP.ToString();
        }
    }
}
