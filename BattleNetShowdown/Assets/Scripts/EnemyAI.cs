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
        //isDead = gameObject.GetComponent<EnemyHP>().GetEnemyStatus();
        //Debug.Log(isDead);
        //Debug.Log(gameObject.GetComponent<EnemyHP>().GetEnemyStatus());
        if(transform.position != targetLocation && isMoving == false && isDead == false)
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
