using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private float speed;

    private void Awake()
    {
        speed = Resources.Load<GameSettings>("GameSettings").Speed;
    }

    private void Update()
    {
        if (GameInfo.IsAsteroidStarted)
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EndLine"))
        {
            gameObject.SetActive(false);
        }
    }
}
