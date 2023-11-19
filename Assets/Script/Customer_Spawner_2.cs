using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class Customer_Spawner_2 : MonoBehaviour
{

    public Transform[] seats;
    public GameObject[] customerPrefabs;


    public int maxCustomers;

    void Start()
    {
        InvokeRepeating("SpawnSeatedCustomer", 1, 10);
    }

    void SpawnSeatedCustomer()
    {
        int customerCount = GameObject.FindGameObjectsWithTag("Customer").Length;
        if (customerCount < maxCustomers)
        {
            int seatIndex = Random.Range(0, seats.Length);
            Transform seat = seats[seatIndex];
            Instantiate(customerPrefabs[Random.Range(0, customerPrefabs.Length-1)], new Vector3(seat.position.x, seat.position.y, seat.position.z), transform.rotation);
            gameObject.tag = "Customer";
        }
    }
}
