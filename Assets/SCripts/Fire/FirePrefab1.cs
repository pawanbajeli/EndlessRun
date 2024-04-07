using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePrefab1 : MonoBehaviour
{
    public GameObject fire;
    
    public float initialSpawnInterval ;
    public float minSpawnInterval ;
    public float intervalDecreaseRate;

    private float currentSpawnInterval;
    Vector3 playerpos;
    Vector3 prevLoaction;

    private void Start()
    {
        currentSpawnInterval = initialSpawnInterval;
        StartCoroutine(SpawnElements());
    }
    private void Update()
    {
        playerpos = GameObject.FindGameObjectWithTag("Player").transform.position;
    }
    IEnumerator SpawnElements()
    {
        while (true)
        {
            yield return new WaitForSeconds(currentSpawnInterval);
            string tag_name = "";

            if (TRackRoad.knowthetrack == 1)
                tag_name = "trig01";
            else tag_name = "trig02";

            float zvalue = Random.Range(playerpos.z+5.0f, GameObject.FindGameObjectWithTag(tag_name).transform.position.z + 28.0f);
            float xvalue = Random.Range(-4.20f, 3.5f);
            Vector3 location=new Vector3(xvalue, 0.00644f, zvalue);
            if(location==playerpos )
            {
                location = location + new Vector3(0.5f, 0.00644f, 0.5f);
            }
            else if(prevLoaction == location)
            {
                location=location+new Vector3(1.0f, 0.00644f, 1.0f); ;
            }
            

            
           GameObject newfire= Instantiate(fire,location, Quaternion.identity);
            prevLoaction = location;
            Destroy(newfire, 5.0f);
            
            currentSpawnInterval -= intervalDecreaseRate;
            currentSpawnInterval = Mathf.Max(currentSpawnInterval, minSpawnInterval);
        }
    }

}
