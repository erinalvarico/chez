using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Customer_Actions : MonoBehaviour
{
    public Sprite workingSprite;
    public Sprite foodOrderSprite;
    public GameObject orderCanvas;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Station_Seat")
        {
            orderCanvas.SetActive(false);
            Debug.Log("ENTERED SEAT NODE");
            StartCoroutine(Wait(foodOrderSprite));
        }
    }

    void ChangeSprite(Sprite sprite)
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
    }

    IEnumerator Wait(Sprite updateSprite)
    {
        yield return new WaitForSeconds(5);
        this.gameObject.GetComponent<SpriteRenderer>().sprite = updateSprite;
        orderCanvas.SetActive(true);
    }
}
