using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Customer_Patrol : MonoBehaviour
{

    public Transform[] seatPoints;

    public int targetPoint;
    public float speed;
    private bool hasArrived;
    public float delay;
    public Sprite workingSprite;
    public Sprite seatedSprite;
    private bool isWaiting = false;

    void Start()
    {
        targetPoint = 1;
    }

    void Update()
    {
        if (!isWaiting)
        {
            if (transform.position != seatPoints[targetPoint].position)
            {
                transform.position = Vector3.MoveTowards(transform.position, seatPoints[targetPoint].position, speed * Time.deltaTime);
            }
            else
            {
                StartCoroutine(Wait(seatedSprite));
            }
        }
    }

    void SetTarget(int targetPatrolPoint)
    {
        if (targetPatrolPoint == 0)
        {
            targetPoint = 1;
        }
    }

    void ChangeSprite(Sprite sprite)
    {
        Debug.Log("Changing Sprites");
        this.gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
        Debug.Log("Sprite Changed");
    }

    void DoNothing()
    {
        Debug.Log("DO NOTHING");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Station_Seat")
        {
            Debug.Log("ENTERED SEAT NODE");
            transform.position = Vector3.MoveTowards(transform.position, seatPoints[targetPoint].position, 0f);
            StartCoroutine(Wait(workingSprite));
            targetPoint = 0;
        }
    }

    IEnumerator Wait(Sprite sprite)
    {
        isWaiting = true;
        Debug.Log("Start to Wait");
        ChangeSprite(sprite);
        yield return new WaitForSeconds(delay);
        ChangeSprite(seatedSprite);
        Debug.Log("Wait Complete");
        isWaiting = false;
    }

}
