using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleController : MonoBehaviour
{
    private float lifeTimer = 0f;
    public float lifeSpan = 10f;

    BoxCollider2D myBoxCollider;


    // Start is called before the first frame update
    void Start()
    {
        myBoxCollider = GetComponent<BoxCollider2D>();

        lifeTimer = Time.time; // START THE LIFE TIMER WHEN THE GAMEOBJECT IS INSTANTIATED
    }

    // Update is called once per frame
    void Update()
    {
        LifeTimeCheck();

        HitPlayer();

        HitGround();

    }

    void LifeTimeCheck()
    {
        if (Time.time >= (lifeTimer + lifeSpan))
        {
            Destroy(this.gameObject);

        }

    }

    void HitPlayer()
    {
        if (myBoxCollider.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            Destroy(this.gameObject);

            FindObjectOfType<GameManager>().ProcessPlayerDeath();

        }

    }

    void HitGround()
    {
        if (myBoxCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            Destroy(this.gameObject);
        }

    }







    // END OF FILE
}
