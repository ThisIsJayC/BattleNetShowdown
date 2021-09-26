using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Attack", menuName = "New Attack")]
public class Attack : ScriptableObject
{
    //Unique ID number    Name of attack      Sprite Name     Damage  Function
    public string uniqueIDNumber;
    public string nameOfAttack;

    public Sprite attackIcon;

    public int damage;

    public string attackCall;

    public void Print()
    {
        Debug.Log("The attack is: " + nameOfAttack);
    }
}
