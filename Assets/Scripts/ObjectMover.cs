using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    public static float speed;

    private void Start()
    {
        speed = 10;
    }
    void Update()
    {
        if (!GameManager.Game_over)
        {
            //speed += 0.001f;
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

    }
}
