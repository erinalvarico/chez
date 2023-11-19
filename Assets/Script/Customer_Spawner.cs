using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class Customer_Spawner : MonoBehaviour
{

    public Transform[] spawnPoints;
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
        int customerCount = GameObject.FindGameObjectsWithTag("Customer").Length;
        if (customerCount < maxCustomers)
        {
            Debug.Log("SPAWNING CUSTOMER - " + customerCount);
            var spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length - 1)].position;
            Debug.Log("SPAWN POINT " + spawnPoint);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < spawnPoints.Length; i++)
            {
                sb.Append(spawnPoints[i].position);
                sb.Append(" ");
            }
            Debug.Log(sb.ToString());
            Instantiate(customerPrefabs[Random.Range(0, customerPrefabs.Length-1)], new Vector3(250, 165, -3), transform.rotation);
        }
    }
}
