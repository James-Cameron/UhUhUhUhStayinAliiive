using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleController : MonoBehaviour
{
    private float lifeTimer = 0f;
    public float lifeSpan = 10f;




    // Start is called before the first frame update
    void Start()
    {
        lifeTimer = Time.time; // START THE LIFE TIMER WHEN THE GAMEOBJECT IS INSTANTIATED
    }

    // Update is called once per frame
    void Update()
    {
        LifeTimeCheck();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Ground"))
        {
            // take a player life.  This might have to go into the player script
            // destroy this gameobject. spawn effect
        }

    }

    void LifeTimeCheck()
    {
        if (Time.time >= (lifeTimer + lifeSpan))
        {
            Destroy(this.gameObject);

        }

    }





    // END OF FILE
}
