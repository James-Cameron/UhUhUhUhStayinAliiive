using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCTRL : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D myBoxCollider;

    public float runSpeed = 5f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myBoxCollider = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        float controlThrow = Input.GetAxis("Horizontal");
        Vector2 runVelocity = new Vector2(controlThrow * runSpeed, rb.velocity.y);
        rb.velocity = runVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;

    }








    // END OF FILE
}
