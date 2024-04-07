using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public bool is_fly = false;

    public float minForce;
    public float maxForce;

    public float minTumble;
    public float maxTumble;

    private Rigidbody2D rb;
    private CapsuleCollider2D cc;

    private void Start()
    {

        
    }
    // Update is called once per frame
    void Update()
    {
        if (is_fly)
        {
            rb = GetComponent<Rigidbody2D>();
            cc = GetComponent<CapsuleCollider2D>();
           // Debug.Log("Fly");
            cc.enabled = false;
            RandomForce();
        }  
    }

    private void RandomForce()
    {
        Vector2 randomDir = Random.insideUnitCircle.normalized;
        float randomTumble = Random.Range(minTumble, maxTumble);
        float randomForce = Random.Range(minForce, maxForce);
        rb.isKinematic = false;
        rb.AddForce(randomDir * randomForce, ForceMode2D.Impulse);
        transform.Rotate(randomDir, randomTumble * Time.deltaTime);
    }
}
