using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDB : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //From: JohnnyGo
        var attacks = new List<Attack>();
        attacks.Add(new Slash());
        attacks.Add(new Lob());
        attacks.Add(new Punch());

        foreach(var attack in attacks)
        {
            attack.Execute();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    */
    //From Alwin: Basically, enums are like basic classes, you can save variables there and functions that change the value of stored variables. It is like a mini class specifically made to store variables you use often, so later on you can call the enum and write enum.Slash and it throws the value of Slash stored in the enum

    //Will need to make an array / structure that holds this information
    /*
    ATTACK DB PROTOTYPE

    Unique ID number    Name of attack      Sprite Name     Damage  Function
    1                   Blast               BlastSprite     30      Blast()
    2                   Guard               GuardSprite     0       Guard()
    3                   Lob                 LobSprite       50      Lob()
    4                   Punch               PunchSprite     80      Punch()
    5                   Slash               SlashSprite     100     Slash()

    */
    /*
    //From JohnnyGo. This does nothing yet.
    public abstract class Attack
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public Sprite AttackSprite { get; set; }

        public virtual void Execute()
        {
            //default implementation of Execute
            Debug.Log("Base");
        }
    }

    public class Slash : Attack
    {
        public override void Execute()
        {
            //do something unique to Slash
            Debug.Log("Slash");
            base.Execute(); //call this if you want the default implementation to run
        }
    }

    public class Lob : Attack
    {
        public override void Execute()
        {
            //do something unique to Lob
            Debug.Log("Lob");
            //don't call base.Execute if you don't want to run the code in the default implementation
        }
    }

    public class Punch : Attack
    {
        //if you want punch to use the default implementation only there's no need to override Exectute here
    }
    */
}
