using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPoints : MonoBehaviour
{
    public int score;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("collectable"))
        {
            Destroy(collision.gameObject);
            score++;
        }
    }
}