using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerCTRL : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D myBoxCollider;

    public float jumpSpeed = 5f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myBoxCollider = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }

    void Jump()
    {
        if (!myBoxCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
            return;

        if (Input.GetButton("Jump"))
        {
            Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
            rb.velocity += jumpVelocityToAdd;
        }

    }







    // END OF FILE
}
