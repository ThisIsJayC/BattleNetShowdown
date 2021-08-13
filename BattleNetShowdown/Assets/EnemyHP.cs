using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



//TODO: learn why this just throws a billion errors


public class EnemyHP : MonoBehaviour
{
    public Text enemyHPTextbox;

    public int enemyHP;
    // Start is called before the first frame update
    void Start()
    {
        enemyHPTextbox = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyHPTextbox.text = "HP: " + enemyHP;

        if (enemyHP <= 0)
        Destroy(gameObject);
    }
}
