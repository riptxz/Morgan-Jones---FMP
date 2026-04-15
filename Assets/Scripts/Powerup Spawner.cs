using System.Collections;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    public GameObject vinegarPrefab;
    public float respawnTime = 5f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(spawnTime());
    }

    public void spawnVinegar()
    {
        if (GameObject.FindWithTag("Vinegar") == null)
        {
            GameObject a = Instantiate(vinegarPrefab) as GameObject;
            a.transform.position = new Vector3(107, 64.402f, -110.55f);
        }
    }

    IEnumerator spawnTime()  
    {
        while (true)                       
        {
            yield return new WaitForSeconds(respawnTime);  //calls every second 
            spawnVinegar();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
