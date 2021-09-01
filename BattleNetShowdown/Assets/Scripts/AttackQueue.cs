using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackQueue : MonoBehaviour
{
    //public Sprite currayOfSpritesentAttack;

    public Sprite lobAttackSprite, punchAttackSprite, slashAttackSprite;
            int i = 0;

    // Start is called before the first frame update
    void Start()
    {

        Sprite[] arrayOfSprites = {lobAttackSprite, punchAttackSprite, slashAttackSprite};


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
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = pun;
                    //Debug.Log(arrayOfSprites[i]);
                    i++;
                }
    }
}
