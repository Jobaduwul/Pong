using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player1Controller : MonoBehaviour
{
    float verticalInput;
    public float speed;
    public float yRange;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -yRange)
        {
            transform.position = new Vector2(transform.position.x, -yRange);
        }
        if (transform.position.y > yRange)
        {
            transform.position = new Vector2(transform.position.x, yRange);
        }

        verticalInput = Input.GetAxis("Vertical1");
        transform.Translate(Vector2.up * speed * Time.deltaTime * verticalInput);
    }
}
