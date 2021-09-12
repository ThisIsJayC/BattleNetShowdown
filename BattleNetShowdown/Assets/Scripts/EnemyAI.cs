using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    //float leftMost = 0.5f, rightMost = 2.5f, topMost = -0.5f, bottomMost = -2.5f;
    private EnemyHP enemyHP;
    private Vector3 targetLocation = new Vector3(0.5f, -1.5f, 0);
    public bool isDead = true, isMoving = false;

    // Update is called once per frame
    void Start()
    {
        enemyHP = FindObjectOfType<EnemyHP>();
    }

    public void Update()
    {
        isDead = enemyHP.GetEnemyStatus();
        if(isDead == true)
        {
            StopAllCoroutines(); // This stops the enemy AI from making a move after it's dead
        }

        // if(transform.position != targetLocation && isMoving == false && isDead == false)
        if(isMoving == false && isDead == false)
        {

            //Wait 2 seconds and then move to the correct location
            StartCoroutine(MoveWait(1.75f, targetLocation));

            IEnumerator MoveWait(float s, Vector3 targetLocation)
            {
                isMoving = true;
                yield return new WaitForSeconds(s);
                transform.position = targetLocation;
                isMoving = false;

                StartCoroutine(RandomAttack(0.5f));

                IEnumerator RandomAttack(float s)
                {
                    yield return new WaitForSeconds(s);
                    GameObject.Find("AlwinsBoxerGatorSprite").GetComponent<EnemyAnimations>().Blast(); //TODO: randomly choose an attack.
                    Debug.Log("The enemy attacked after " + s + " seconds."); //TODO: Actually call attack functions.
                }
            }

            targetLocation = new Vector3(Random.Range(0, 3) + 0.5f, Random.Range(-2, 1) - 0.5f, 0);
        }
    }
}
