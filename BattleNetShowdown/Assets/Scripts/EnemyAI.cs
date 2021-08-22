using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }


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
                //TODO: Figure out why this doesn't end after 2 seconds.
                Debug.Log("Waited 2 seconds");
                transform.position = targetLocation;

                //Does not kick out of the Coroutine
                StopCoroutine(MoveWait(2.0f, targetLocation));
                isMoving = false;
            }
        }



    }
}
