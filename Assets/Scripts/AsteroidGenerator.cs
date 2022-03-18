using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidGenerator : MonoBehaviour
{
    public Vector3 spawnRange;
    public float amountToSpawn;
    public GameObject asteroid;
    public float startSafeRange;
    private List<GameObject> objectsToPlace = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < amountToSpawn; i++)
        {
            Vector3 newPos = PickSpawnPoint();

            objectsToPlace.Add(Instantiate(asteroid, newPos, Quaternion.Euler(Random.Range(0f,360f), Random.Range(0f, 360f), Random.Range(0f, 360f))));
            objectsToPlace[i].transform.parent = this.transform;
            objectsToPlace[i].transform.localScale *= Random.Range(1f,2f);
        }

        asteroid.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 PickSpawnPoint()
    {
        Vector3 spawnPoint = Random.insideUnitSphere;

        spawnPoint = new Vector3(spawnPoint.x * spawnRange.x, spawnPoint.y * spawnRange.y, spawnPoint.z * spawnRange.z);

        return spawnPoint;
    }
}

