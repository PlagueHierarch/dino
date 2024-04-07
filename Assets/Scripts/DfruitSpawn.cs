using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DfruitSpawn : MonoBehaviour
{

    public GameObject Dfruit;
    public BoxCollider2D area;

    public float minGenTime;
    public float maxGenTime;

    void Start()
    {
        StartCoroutine(SpawnDfruit());
    }

    private IEnumerator SpawnDfruit()
    {
        while (!GameManager.Game_over)
        {
            Vector2 spawnPos = GetRandPos();
            var obj = Instantiate(Dfruit, spawnPos, Quaternion.identity);
            obj.transform.SetParent(gameObject.transform, true);

            yield return new WaitForSeconds(Random.Range(minGenTime, maxGenTime));
        }
    }
    private Vector2 GetRandPos()
    {
        Vector2 bPos = transform.position;
        Vector2 size = area.size;

        float posX = bPos.x + Random.Range(-size.x / 2f, size.x / 2f);
        float posY = bPos.y + Random.Range(-size.y / 2f, size.y / 2f);

        return new Vector2 (posX, posY); 
    }
}
