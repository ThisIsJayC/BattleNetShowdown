using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHP : MonoBehaviour
{

    public TextMesh HPTextbox; //my bad unity LUL

    public int HP;

    public AudioSource defeatExplosionSFX, hitSFX;

    public bool objectIsDead = false;

    public int GetHP()
    {
        return HP;
    } //these are not implemented

    public void SetHP(int x)
    {
        HP = x;
    }

    public void TakeDamage(RaycastHit2D foo, int damage)  //Unity said yes, sort of
    {
        //Debug.Log(GameObject.Find(string.Concat(foo.collider.name + " HP Text")).GetComponent<ObjectHP>().HP);
        // HP = GameObject.Find(string.Concat(foo.collider.name + " HP Text")).GetComponent<ObjectHP>().HP;
        //Calculate damage
        GameObject.Find(string.Concat(foo.collider.name + " HP Text")).GetComponent<ObjectHP>().HP -= damage;
        //objectHPThatWasHit -= damage;
        int objectHPThatWasHit = GameObject.Find(string.Concat(foo.collider.name + " HP Text")).GetComponent<ObjectHP>().HP;

        // object.setHP = object.getHP -= damageNumber  //tried doing this but was too sleepy. The above works


        //Debug.Log(foo.collider.name + " took " + damage + " damage");

        //Deletes the parent object when the HP reaches 0
        if (objectHPThatWasHit <= 0)
        {
            GameObject.Find(string.Concat(foo.collider.name + " HP Text")).GetComponent<ObjectHP>().HP = 0;

            transform.parent.gameObject.GetComponent<BoxCollider2D>().enabled = false;

            StartCoroutine(destroyPlayer());
            IEnumerator destroyPlayer()
            {
                Debug.Log(foo.collider.name + " was destroyed");
                SetEnemyStatus(true);

                //TODO: make the routine for the object being destroyed name agnostic
                //These next three lines are a hacky way to disable the players movements, attacks, and hitbox TODO: Do this better?
                GameObject.Find(string.Concat("Player Sprite")).GetComponent<PlayerAnimations>().enabled = false;
                GameObject.Find("Player").GetComponent<PlayerMovementNew>().enabled = false;
                GameObject.Find("Attack Queue").SetActive(false);

                // GameObject.Find(string.Concat(foo.collider.name + " Sprite")).GetComponent<PlayerAnimations>().enabled = false;
                // GameObject.Find(foo.collider.name).GetComponent<PlayerMovementNew>().enabled = false;
                // GameObject.Find("Attack Queue").SetActive(false);

                defeatExplosionSFX.Play();

                yield return new WaitForSeconds(defeatExplosionSFX.clip.length);

                GameObject.Find(foo.collider.name).SetActive(false);
                //transform.parent.gameObject.SetActive(false);
                //Destroy(transform.parent.gameObject); //or just delete it if you really are feeling spicy
            }
        }
        hitSFX.Play();

        //Debug.Log("Take Damage test");
        // Debug.Log("Object " + foo.collider.name + " took " + damage + " damage!");
    }

    public void SetEnemyStatus(bool trueorfalse)
    {
        objectIsDead = trueorfalse;
    }

    public bool GetEnemyStatus()
    {
        return objectIsDead;
    }

    public void Start()
    {
        HPTextbox.text = HP.ToString();
    }

    void Update()
    {
        HPTextbox.text = HP.ToString();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("healing 500 HP");
            Debug.Log(GameObject.Find("Player HP Text").GetComponent<ObjectHP>().HP);
            GameObject.Find("Player HP Text").GetComponent<ObjectHP>().HP +=500;
//            GameObject.Find("Player").GetComponent<ObjectHP>().HP += 500;
            Debug.Log("Player healed 500 HP");
        }
    }



    /*
    void PseudoAttack
    {
        ////Do the attack
        //Draw the line / find out where the attack affects
        if it hits something
            grab the name / tag / find out what the object is
            apply effects (knock back, stun, etc) and apply damage

    }

    void objectReceivesDamage(Object object, int damageNumber)
    {
        object.setHP = object.getHP -= damageNumber
    }
*/
}
