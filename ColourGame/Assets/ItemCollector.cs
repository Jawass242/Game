using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemCollector : MonoBehaviour
{
    private int Bananas = 0;

    [SerializeField] private Text BananasText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Banana"))
        {
            Destroy(collision.gameObject);
            Bananas++;
            BananasText.text = "Bananas: " + Bananas;
        }
    }
}