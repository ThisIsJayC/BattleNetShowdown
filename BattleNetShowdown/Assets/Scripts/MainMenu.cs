using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public float seconds;
    public float timer;
    public Vector3 Point, Difference, start;
    // public Vector3 Difference;
    // public Vector3 start;
    public float percent;

    public AudioSource logoEntrance, mainMenuChime, menuMovement, menuSelection;
    private bool isDoneMoving = false;
    void Start()
    {
        start = transform.position;
        Point = new Vector3 (0, 1, 0);
        Difference = Point-start;
        logoEntrance.Play();
    }

    void Update()
    {
        if (timer <= seconds)
        {
                // basic timer
                timer += Time.deltaTime;
                // percent is a 0-1 float showing the percentage of time that has passed on our timer!
                percent = timer / seconds;
                // multiply the percentage to the difference of our two positions
                // and add to the start
                transform.position = start + Difference * percent;
                //Debug.Log(percent);
        }

        if(percent >= 1 && isDoneMoving == false)
        {
            isDoneMoving = true;
            Debug.Log("Finished moving!"); // TODO: Remove debug message
            mainMenuChime.Play();
            //show some text
            var textBox = GameObject.Find("Text");
            // gameObject.GetComponent<Canvas>().SetActive
            textBox.transform.localScale = new Vector3(1, 1, 1);
            //textBox.color = Color.black;
            //decryptSlider.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = Random.ColorHSV(glow, glow, 1f, 1f, 1f, 1f);
            //flash the text
        }
        if(Input.GetKeyDown(KeyCode.Space) && isDoneMoving == true)
            SceneManager.LoadScene("3x3 Grid");
    }
}
