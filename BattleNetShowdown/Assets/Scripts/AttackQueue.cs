using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class AttackQueue : MonoBehaviour
{
    public Sprite lobAttackSprite, punchAttackSprite, slashAttackSprite;

    private PlayerAnimations playerAnimations;

    void Slash()
    {
        Debug.Log("Slashing");
        playerAnimations.Slash();
    }
    void Lob()
    {
        Debug.Log("Lobbing");
        playerAnimations.Lob();
    }
    void Punch()
    {
        Debug.Log("Punching");
        playerAnimations.Punch();
    }

    List<Action> lst = new List<Action>();
    List<Action> attackQueue = new List<Action>();
    int i = 0, attackQueueMax = 6;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimations = FindObjectOfType<PlayerAnimations>();

        lst.AddRange(new Action[] { Slash, Lob, Punch });

        ShuffleAttacks();

        //FindObjectOfType<AttackScript>(Update().attackArrayOfSpritesay[0]);
        this.gameObject.GetComponent<SpriteRenderer>().sprite = lobAttackSprite;
        // Set the Attack Queue slot (orange square) to be the first item in the queue (attackArrayOfSpritesay[0])
        // Once the forwards button is pressed, set the next attack sprite (attackArrayOfSpritesay[1])
    }

    void ShuffleAttacks()
    {
        int randomNumberOfAttacks = UnityEngine.Random.Range(0, attackQueueMax);
        attackQueue.Clear();
        for(int j = 0; j < randomNumberOfAttacks; j++)
        {
            int randomNumber = UnityEngine.Random.Range(0, lst.Count);
            attackQueue.Add(lst[randomNumber]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightAlt))
        {
            //this.gameObject.GetComponent<SpriteRenderer>().sprite = punchAttackSprite;
            if(i < attackQueue.Count)
            {
                Debug.Log("Attack " + (i + 1) + " of " + (attackQueue.Count));
                attackQueue[i]();
                i++;
                return; //Exits the function instead instantly resetting the queue. TODO: make this better
            }
            if(i >= attackQueue.Count)
            {
                Debug.Log("You're empty. Reseteting to zero");
                ShuffleAttacks();
                i = 0;
            }
        }
    }
}
