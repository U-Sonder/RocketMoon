using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private float speed;

    private void Awake()
    {
        speed = Resources.Load<GameSettings>("GameSettings").Speed;
    }

    private void Update()
    {
        if (GameInfo.IsStarted || GameInfo.IsAsteroidStarted)
        {
            var prev = transform.position;
            transform.position -= transform.up * speed * Time.deltaTime;
            if (GameInfo.IsAsteroidStarted)
            {
                transform.position = new Vector3(transform.position.x, prev.y, transform.position.z);
            }
            GameInfo.Distance.Value += Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GlobalEvents.Other.RocketCollapsed.Invoke();
        }
        else if (collision.gameObject.CompareTag("RocketStopLine"))
        {
            if (GameInfo.IsStarted)
            {
                GlobalEvents.Other.AsteroidsStarted.Invoke();
            }
        }
    }

}
