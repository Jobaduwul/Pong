using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerController : MonoBehaviour
{
    public float speed;
    public float yRange;
    public Rigidbody computerPlayerRb;
    public GameObject ball;
    public float yDiff;

    // Start is called before the first frame update
    void Start()
    {
        computerPlayerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        yDiff = ball.transform.position.y - computerPlayerRb.transform.position.y;
        if (yDiff > 0)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime * 1);
        }
        else if(yDiff < 0)
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime * 1);
        }


        if (transform.position.y < -yRange)
        {
            transform.position = new Vector2(transform.position.x, -yRange);
        }
        if (transform.position.y > yRange)
        {
            transform.position = new Vector2(transform.position.x, yRange);
        }
    }
}
