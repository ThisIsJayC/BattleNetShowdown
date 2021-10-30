using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class AttackDisplay : MonoBehaviour
{
    public Attack attack;

    public Text attackName;

    public Image attackIcon;

    public Text attackDamage;

    void UpdateAttack()
    {
        attackName.text = attack.nameOfAttack;
        attackIcon.sprite = attack.attackIcon;
        attackDamage.text = attack.damage.ToString();
    }

    void Update()
    {
        //TODO: Remove. Used for debugging
        if(Input.GetKeyDown(KeyCode.Space) && attack.name != "Shoot")
        {
            attack = (Attack)AssetDatabase.LoadAssetAtPath("Assets/Attacks/Shoot.asset", typeof(Attack));
            attack.Print();
            UpdateAttack();
            return;
        }

        if(Input.GetKeyDown(KeyCode.Space) && attack.name != "Lob")
        {
            attack = (Attack)AssetDatabase.LoadAssetAtPath("Assets/Attacks/Lob.asset", typeof(Attack));
            attack.Print();
            UpdateAttack();
            return;
        }
    }
}
