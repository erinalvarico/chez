using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chef_Patrol : MonoBehaviour
{

    public Transform[] patrolPoints;
    public int targetPoint;
    public float speed;
    private bool hasArrived;
    public float delay;
    public Sprite workingSprite;
    public Sprite idleSprite;
    private bool isWaiting = false;

    void Start()
    {
        targetPoint = 1;
    }

    void Update()
    {
       if(!isWaiting)
       {
            if (transform.position != patrolPoints[targetPoint].position)
            {
                transform.position = Vector3.MoveTowards(transform.position, patrolPoints[targetPoint].position, speed * Time.deltaTime);
            }
            else
            {
                StartCoroutine(Wait(idleSprite));
            }
        }
    }

    void SetTarget(int targetPatrolPoint)
    {
        if (targetPatrolPoint == 0)
        {
            targetPoint = 1;
        }
        else
        {
            targetPoint = 0;
        }
    }

    void ChangeSprite(Sprite sprite)
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
    }

    void DoNothing()
    {
        Debug.Log("DO NOTHING");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Station_Stove")
        {
            Debug.Log("IN STATION STOVE");
            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[targetPoint].position, 0f);
            StartCoroutine(Wait(workingSprite));
            targetPoint = 0;
        }
    }

    IEnumerator Wait(Sprite sprite)
    {
        isWaiting = true;
        ChangeSprite(sprite);
        yield return new WaitForSeconds(delay);
        ChangeSprite(idleSprite);
        isWaiting = false; 
    }

}
