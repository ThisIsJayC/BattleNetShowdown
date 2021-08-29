using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Vector3 targetLocation = new Vector3(0.5f, -1.5f, 0);
    public bool isDead = true, isMoving = false;
    // Update is called once per frame
    void Update()
    {
        if(isDead == true)
        {
            StopAllCoroutines(); //hopefully this stops the enemy AI from making a move
        }



        // TODO: Jay have you tried calling any variable from the class? If it throws the same error, it could be because of the class in the script being not compatible for some reason


        //isDead = gameObject.GetComponent<EnemyHP>().GetEnemyStatus();
        //Debug.Log(isDead);
        //Debug.Log(gameObject.GetComponent<EnemyHP>().GetEnemyStatus());
        if(transform.position != targetLocation && isMoving == false)
        {

        //Wait 2 seconds and then move to the correct location
        StartCoroutine(MoveWait(2.0f, targetLocation));

        IEnumerator MoveWait(float s, Vector3 targetLocation)
            {
                isMoving = true;
                yield return new WaitForSeconds(s);
                transform.position = targetLocation;
                isMoving = false;
            }
        }
    }
}
