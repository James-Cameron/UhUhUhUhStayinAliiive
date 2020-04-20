using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crowdmove : MonoBehaviour
{
    // Start is called before the first frame update
     public float accelerationTime = 2f;
    public float maxSpeed = .05f;
    private Vector2 movement;
    private float timeLeft;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if(timeLeft <= 0)
        {
            movement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            timeLeft += accelerationTime;
        }     
    }

    void FixedUpdate()
    {
        transform.position += new Vector3(movement.x * maxSpeed, movement.y * maxSpeed, 0);
    }
}
