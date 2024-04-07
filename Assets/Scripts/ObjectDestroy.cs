using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroy : MonoBehaviour
{
    public float dtime;

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Game_over)
            Destroy(this);
        Destroy(gameObject, dtime);
    }
}
