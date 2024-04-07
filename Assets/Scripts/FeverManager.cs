using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeverManager : MonoBehaviour
{
    public static int feverGauge;
    public static bool fever_On;
    public static bool fever_eat;

    private int curGauge;
    public int minAdd;
    public int maxAdd;

    public Slider feverSlider;
    public AudioSource audioS;

    // Start is called before the first frame update
    void Start()
    {
        feverGauge = 0;
        fever_On = false;
        fever_eat = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(fever_eat == true)
        {
            feverGauge += Random.Range(minAdd, maxAdd);
            StartCoroutine(feverTime());

            fever_eat = false;
            
        }
    }

    private IEnumerator slide()
    {
        while(curGauge != feverGauge)
        {
            curGauge++;
            feverSlider.value = curGauge;
            yield return new WaitForSeconds(0.01f);
        }
       
    }

    private IEnumerator feverdown()
    {   
        while(curGauge > 0)
        {
            curGauge--;
            feverGauge = curGauge;
            feverSlider.value = curGauge;
            //Debug.Log(curGauge);
            yield return new WaitForSeconds(0.1f);
        }
        StartCoroutine(pitchDown());
        fever_On = false;
    }

    private IEnumerator pitchUp()
    {
        while (audioS.pitch < 2)
        {
            audioS.pitch += 0.1f;
            yield return new WaitForSeconds(0.1f);
        }

    }

    private IEnumerator pitchDown()
    {
        while (audioS.pitch > 1)
        {
            audioS.pitch -= 0.1f;
            yield return new WaitForSeconds(0.1f);
        }

    }

    private IEnumerator feverTime()
    {
        yield return StartCoroutine(slide());

        if (feverGauge >= 100)
        {
            StartCoroutine(pitchUp());
            curGauge = 100;
            fever_On = true;
            //Debug.Log("feverTime");
            yield return StartCoroutine(feverdown());

        }
        
    }
}
