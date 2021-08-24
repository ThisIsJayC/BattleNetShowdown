using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    void Lob()
    {
        gameObject.GetComponent<PlayerAnimations>().Lob();
        Debug.Log("Lob attack used");
    }

    void Punch()
    {
        gameObject.GetComponent<PlayerAnimations>().Punch();
        Debug.Log("Punch attack used");
    }

    void Shoot()
    {
        gameObject.GetComponent<PlayerAnimations>().Shoot();
        Debug.Log("Shoot attack used");
    }

    void Slash()
    {
        gameObject.GetComponent<PlayerAnimations>().Slash();
        Debug.Log("Slash attack used");
    }

    public int[] attackArray = new int[] {1, 2, 3, 4, 5, 6};
    int i = 0;

    private DecryptBar decryptBar;

    void Start()
    {
        decryptBar = FindObjectOfType<DecryptBar>();
        // Set Lob as the first card indicator
        //gameObject.GetComponent<PlayerAnimations>().Idle();
    }
    // Update is called once per frame
    void Update()
    {
        //TODO: Update the attack usage so that it's using a queue (FIFO)
        if(Input.GetKeyDown(KeyCode.Slash))
            {
                if(i == attackArray.Length - 1)
                    i = 0;
                else
                {
                    i++; //Cycles through stack
                }

            switch(attackArray[i])
            {
                case 1:
                    Lob();
                    break;

                case 2:
                    Punch();
                    break;

                case 3:
                    Debug.Log("Nothing happened");
                    break;

                case 4:
                    Slash();
                    break;

                case 5:
                    Debug.ClearDeveloperConsole();
                    Debug.Log("You are out of attacks");
                    break;

                case 6: //Resets the DECRYPT bar
                    Debug.Log("Resetting the DECRYPT bar");
                    decryptBar.decryptSlider.value = 0;
                    decryptBar.fullbar = false;
                    break;

                default:
                    Debug.Log("shit didn't work. You should not see this. How did you fuck up this bad Jay?");
                    break;
            }
        }

        if(Input.GetKeyUp(KeyCode.Slash))
        {
            gameObject.GetComponent<PlayerAnimations>().Idle();
        }
    }
}
