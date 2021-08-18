using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecryptBar : MonoBehaviour
{
    [SerializeField]
    public Slider decryptSlider;

    // Start is called before the first frame update
    void Start()
    {
        decryptSlider.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(decryptSlider.value < 100)
        {
            Debug.Log(decryptSlider.value);
            decryptSlider.value += .05f;
        }
    }
}
