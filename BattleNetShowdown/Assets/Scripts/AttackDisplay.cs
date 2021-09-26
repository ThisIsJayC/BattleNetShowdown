using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackDisplay : MonoBehaviour
{
    public Attack attack;

    public Text attackName;

    public Image attackIcon;

    public Text attackDamage;


    // Start is called before the first frame update
    void Start()
    {
        attackName.text = attack.name;

        attackIcon.sprite = attack.attackIcon;

        attackDamage.text = attack.damage.ToString();
    }
}
