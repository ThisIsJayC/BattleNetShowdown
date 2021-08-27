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

    //Set the length of each DECRYPT round in seconds below:
    public const float originalRoundLength = 15.0f;
    public static float roundLength = originalRoundLength;

    private float decryptBarIncrement = 1 / (roundLength / 100f * 60f);

    public float timer = 0.0f; //TODO: Remove debugging code

    // Start is called before the first frame update
    void Start()
    {
        decryptSlider.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        decryptBarIncrement = 1 / (roundLength / 100f * 60f);

        if(decryptSlider.value < 100)
        {
            timer += Time.deltaTime; //TODO: Remove debugging code
            //Debug.Log(decryptSlider.value); //TODO: Remove debugging code
            decryptSlider.value += decryptBarIncrement;
        }

        if(decryptSlider.value == 100 && fullbar == false)
        {
            Debug.Log("Time elapsed: " + timer); //TODO: Remove debugging code
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

        // 2X Faster
        void DecyptBar2XSpeed()
        {
            {
                if(roundLength != 2 * originalRoundLength)
                    roundLength = roundLength * 2;
            }
        }

        // 1/2 Slower
        void DecryptBarHalfSpeed()
        {
            {
                if(roundLength != originalRoundLength / 2)
                    roundLength = roundLength / 2;
            }
        }

        //Full bar
        void DecryptBarFill()
        {
            {
                decryptSlider.value = 100;
            }
        }
}
