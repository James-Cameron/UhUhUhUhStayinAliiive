using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProjectile : MonoBehaviour
{
    public int maxRange = 10;
    public int spawnThreshold = 8;

    public Rigidbody2D projectile;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnBottle();


    }

    void SpawnBottle()
    {
        int rewardChance = Random.Range(0, maxRange + 1);

        if (rewardChance > spawnThreshold)
        {
            // SPAWN AN INSTANCE OF THE PROJECTILE
            Rigidbody clone;


            // how to make this 2d??
            // clone = Instantiate(projectile, transform.position, transform.rotation);
            // clone.velocity = transform.TransformDirection(Vector3.forward); // NEED TO ADJUST THIS FOR A 2D GAME
        }

    }





     // END OF FILE 
}
