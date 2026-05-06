using System.Collections;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    public GameObject vinegarPrefab;
    public float respawnTime = 20f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(spawnTime());  //Starts the Coroutine
    }

    public void spawnVinegar()
    {
        if (GameObject.FindWithTag("Vinegar") == null)   //Looks for any object with the tag and if not
        {
            GameObject a = Instantiate(vinegarPrefab) as GameObject;         // Gets the desired prefab
            a.transform.position = new Vector3(107, 64.402f, -110.55f);      // Spawns it onto the spawner
        }
    }

    IEnumerator spawnTime()  
    {
        while (true)                       
        {
            yield return new WaitForSeconds(respawnTime);  //waits for 5 seconds
            spawnVinegar();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
