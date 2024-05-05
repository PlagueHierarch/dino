using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GroundLoop : MonoBehaviour
{
   
    private float width;
    public BoxCollider2D bc;

    private void Awake()
    {
        width = bc.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(transform.position.x<= -width)
        {
            Vector2 offset = new Vector2(width * 2f, 0);
            transform.position = (Vector2)transform.position + offset; 
        }

        
    }
}
