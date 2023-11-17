using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject extraPlatformPrefab;
    public GameObject powerupPrefab;
    float startDelay = 1.5f;
    float repeatDelay = 3;
    float pRepeatDelay = 6;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("PlatformSpawn", startDelay, repeatDelay);
        InvokeRepeating("PowerupSpawn", startDelay, pRepeatDelay);
        InvokeRepeating("ExtraPlatformSpawn", 3, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlatformSpawn()
    {
        Instantiate(platformPrefab, new Vector3(Random.Range(-8, 8), 10, -1), transform.rotation);
    }

    private void PowerupSpawn()
    {
        Instantiate(powerupPrefab, new Vector3(Random.Range(-8, 8), 11, -0.5f), transform.rotation);
    }

    private void ExtraPlatformSpawn()
    {
        Instantiate(extraPlatformPrefab, new Vector3(Random.Range(-8, 8), 10, -1), transform.rotation);
    }
}
