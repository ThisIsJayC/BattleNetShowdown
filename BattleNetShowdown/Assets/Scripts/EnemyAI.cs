using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Vector3 targetLocation = new Vector3(0.5f, -1.5f, 0);
    static bool isMoving = false;

    // Update is called once per frame
    void Update()
    {
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
