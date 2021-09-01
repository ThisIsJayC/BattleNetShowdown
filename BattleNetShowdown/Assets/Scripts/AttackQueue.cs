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

    int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimations = FindObjectOfType<PlayerAnimations>();

        lst.AddRange(new Action[] { Slash, Lob, Punch });
        // for (int i = 0; i < lst.Count; i++)
        // {
        //     lst[i]();
        // }

        //FindObjectOfType<AttackScript>(Update().attackArrayOfSpritesay[0]);
        this.gameObject.GetComponent<SpriteRenderer>().sprite = lobAttackSprite;
        // Set the Attack Queue slot (orange square) to be the first item in the queue (attackArrayOfSpritesay[0])
        // Once the forwards button is pressed, set the next attack sprite (attackArrayOfSpritesay[1])
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightAlt))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = punchAttackSprite;
            if(i < lst.Capacity - 1)
            {
                lst[i]();
                i++;
            }
        }
    }
}
