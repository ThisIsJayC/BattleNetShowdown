using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public float seconds;
    public float timer;
    public Vector3 Point, Difference, start;
    //public Text textBox;
    public float percent;

    public AudioSource BNTitleMusic, logoEntrance, mainMenuChime, menuMovement, menuSelection;
    private bool isDoneMoving = false;
    void Start()
    {
        BNTitleMusic.Play();
        StartCoroutine(WaitForSound());
        start = transform.position;
        Point = new Vector3 (0, 1, 0);
        Difference = Point-start;
        logoEntrance.Play();
    }

    IEnumerator WaitForSound()
    {
        yield return new WaitForSeconds(24f);
        print("FinishAudio");
        //onFinishSound.Invoke();
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
            // gameObject.GetComponent<Canvas>().SetActive
            GameObject.Find("BeginText").transform.localScale = new Vector3(1, 1, 1); //This is doing its own thing
            //textBox.color = Color.black;
            //textBox.color = Color.black;

            //GameObject.Find("BeginTextBox").SetActive(false);
            //GameObject.Find("BeginTextBox").GetComponent<TextBox>().color = Color.black;

            //GetComponent<Image>().color = Random.ColorHSV(glow, glow, 1f, 1f, 1f, 1f);
            //flash the text
        }
        if(Input.GetKeyDown(KeyCode.Space) && isDoneMoving == true)
            SceneManager.LoadScene("3x3 Grid");
    }
}
