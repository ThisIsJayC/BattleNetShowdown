using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackQueue : MonoBehaviour
{
    public Sprite currentAttack;

    public Sprite lobAttackSprite, punchAttackSprite, slashAttackSprite;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<SpriteRenderer>("L").sprite;
        //FindObjectOfType<AttackScript>(Update().attackArray[0]);

        // Set the Attack Queue slot (orange square) to be the first item in the queue (attackArray[0])
        // Once the forwards button is pressed, set the next attack sprite (attackArray[1])



    }

    // Update is called once per frame
    void Update()
    {

    }
}
