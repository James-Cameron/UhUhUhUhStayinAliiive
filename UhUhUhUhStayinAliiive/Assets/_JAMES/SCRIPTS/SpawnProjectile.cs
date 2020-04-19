using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProjectile : MonoBehaviour
{
    public int maxRange = 1000;
    public int spawnThreshold = 990;

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
            Rigidbody2D clone;


            // how to make this 2d??
            clone = Instantiate(projectile, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);

        }

    }





     // END OF FILE 
}
