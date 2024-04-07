using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ObjectSpawn : MonoBehaviour
{
    public Transform[] objPrefabs;
    int num = 0;

    public float minGenTime;
    public float maxGenTime;
    void Start()
    {
        StartCoroutine(ObjSpawn());
    }

    IEnumerator ObjSpawn()
    {
        while(!GameManager.Game_over)
        {
           // Debug.Log("pre");
            num = Random.Range(0, 4);
            //var obj = PrefabUtility.InstantiatePrefab(objPrefabs[num]) as GameObject;
            //obj.transform.position = transform.position;
            //obj.transform.rotation = Quaternion.identity;
            var obj = Instantiate(objPrefabs[num], transform.position, Quaternion.identity);
            obj.transform.SetParent(gameObject.transform, true);

            yield return new WaitForSeconds(Random.Range(minGenTime, maxGenTime));
        }
    }
}
