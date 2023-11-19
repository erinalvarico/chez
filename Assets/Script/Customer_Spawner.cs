using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class Customer_Spawner : MonoBehaviour
{

    public Transform[] spawnPoints;
    public Transform[] leftPath;
    public Transform[] rightPath;
    public Transform[] centerPath;
    public GameObject[] customerPrefabs;
    private float startDelay;
    public int delayLowerLimit;
    public int delayUpperLimit;

    public int maxCustomers;

    void Start()
    {
        InvokeRepeating("SpawnCustomer", startDelay, Random.Range(delayLowerLimit, delayUpperLimit));
    }

    void SpawnCustomer()
    {
        int customerCount = GameObject.FindGameObjectsWithTag("Right_Spawn_Player").Length + GameObject.FindGameObjectsWithTag("Left_Spawn_Player").Length;
        if (customerCount < maxCustomers)
        {
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnPointIndex];

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < spawnPoints.Length; i++)
            {
                sb.Append(spawnPoints[i].position);
                sb.Append(" ");
            }
            Debug.Log(sb.ToString());
            Instantiate(customerPrefabs[Random.Range(0, customerPrefabs.Length-1)], new Vector3(spawnPoint.position.x, spawnPoint.position.y, spawnPoint.position.z), transform.rotation);
            Debug.Log("SPAWN POINT INDEX " + spawnPointIndex);
            if (spawnPointIndex == 0)
            {
                Debug.Log("IN LEFT");
                gameObject.tag = "Left_Spawn_Player";
            }
            else if (spawnPointIndex == 1)
            {
                Debug.Log("IN RIGHT");
                gameObject.tag = "Right_Spawn_Player";
            }
        }
    }
}
