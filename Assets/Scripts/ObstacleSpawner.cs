using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Spawns obstacles every 4 units and destorys the oldest obstacle
*/
public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] presets;
    [SerializeField] GameObject coin;
    [SerializeField] List<GameObject> oldPresets = new List<GameObject>();

    float oldSpawnHeight;
    float destroyHeight;
    bool coinSpawned;

    void Start()
    {
        oldSpawnHeight = transform.position.y;
        destroyHeight = transform.position.y;
    }

    void Update()
    {
        //Spawns the next obstacle every 4 units
        if (oldSpawnHeight - transform.position.y <= -6)
        {
            coinSpawned = false;
            oldSpawnHeight = transform.position.y;
            var newPreset = Instantiate(presets[Random.Range(0, presets.Length)],
                transform.position, Quaternion.identity);
            oldPresets.Add(newPreset);
        }//Spawns a coin or random power up between the obstacles.
        else if (oldSpawnHeight - transform.position.y <= -3.5f && !coinSpawned)
        {
            coinSpawned = true;
            Instantiate(coin, transform.position, Quaternion.identity);
        }

        //Destroys the oldest obstacle every 4 units
        if (destroyHeight - transform.position.y <= -18)
        {
            destroyHeight = oldPresets[0].transform.position.y + 4;
            GameObject.Destroy(oldPresets[0]);
            oldPresets.RemoveAt(0);
        }
    }
}