using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flicker : MonoBehaviour
{
    public float waitTime;
    public float waitTime2;
    void Start()
    {
        StartCoroutine(Flicker());
    }

    private IEnumerator Flicker()
    {
        while (true)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            yield return new WaitForSeconds(waitTime);
            transform.GetChild(0).gameObject.SetActive(false);
            yield return new WaitForSeconds(waitTime2);
            Debug.Log("flick");
        }
    }
}
