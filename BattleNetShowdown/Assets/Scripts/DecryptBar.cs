using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecryptBar : MonoBehaviour
{
    [SerializeField]
    public Slider decryptSlider;

    [SerializeField]
    public AudioSource fullDecryptBarChime;

    public bool fullbar = false;
    private float glow = 0f;
    private int glowDirection;

    //TODO: Fix this calculation
    //Set the length of each DECRYP round in seconds below:
    public static float roundLength = 0.30f;
    private float decryptBarIncrement = roundLength / 60f;

    // Start is called before the first frame update
    void Start()
    {
        decryptSlider.value = 0; //TODO: set the back to 0
    }

    // Update is called once per frame
    void Update()
    {
        if(decryptSlider.value < 100)
        {
            //Debug.Log(decryptSlider.value);
            decryptSlider.value += decryptBarIncrement;
        }

        if(decryptSlider.value == 100 && fullbar == false)
        {
            fullDecryptBarChime.Play();
            fullbar = true;
        }

        //Option A: Color cycle
        // if (decryptSlider.value == 100)
        // {
        //     if (glow >= 1f)
        //     {
        //         //Debug.Log("glow value is " + glow); //TODO: remove
        //         glow = 0f;
        //     }
        //     //Change the color of the Decrypt bar
        //     decryptSlider.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = Random.ColorHSV(glow, glow, 1f, 1f, 1f, 1f);
        //     glow +=.003f;
        // }


        //Option B: Single color pulse
        if (decryptSlider.value == 100)
        {
            if (glow >= 1f)
            {
                //Debug.Log("glow value is " + glow); //TODO: remove
                glowDirection = -1;
            }
            if (glow <= 0f)
            {
                glowDirection = 1;
            }
            //Change the color of the Decrypt bar
            decryptSlider.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = Random.ColorHSV(0.7f, 0.7f, glow, glow, 1f, 1f);
            glow += (.003f * glowDirection);
        }

    }
}
