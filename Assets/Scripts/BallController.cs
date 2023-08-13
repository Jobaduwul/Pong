using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float initialSpeed;
    Vector2 direction;
    Rigidbody rb;
    public float startDelay;
    public AgainstComputerManager againstCompManager;
    public LocalMultiManager localMultiManager;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Invoke("StartBallMovement", startDelay);
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the ball is moving in a nearly straight horizontal direction
        if (Mathf.Abs(rb.velocity.normalized.y) < 0.1f)
        {
            // Apply a small vertical force to prevent getting stuck in a horizontal loop
            rb.AddForce(Vector2.up * Random.Range(-0.5f, 0.5f), ForceMode.Impulse);
        }

        if(transform.position.x < -15 || transform.position.x > 15)
        {
            Destroy(gameObject);
        }
    }

    void StartBallMovement()
    {
        direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        rb.velocity = direction * initialSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Bounce off surfaces
        Vector2 normal = collision.contacts[0].normal;
        direction = Vector2.Reflect(direction, normal).normalized;
        rb.velocity = direction * initialSpeed;
        againstCompManager.PlayBounceSound();
        localMultiManager.PlayBounceSound();
    }
}
