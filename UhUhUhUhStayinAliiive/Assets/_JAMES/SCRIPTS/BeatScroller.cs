using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{

    [Tooltip("Tempo in beats per minute")]
    public float beatTempo; // IMPORTANT TO MATCH THE BEAT TEMPO WITH THE TEMPO OF THE MUSIC WE ARE USING

    public bool hasStarted;


    // Start is called before the first frame update
    void Start()
    {
        beatTempo = beatTempo / 60; // HOW MANY BEATS PER SECOND
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            if (Input.anyKeyDown)
            {
                hasStarted = true;
            }

        }
        else
        {
            transform.position += new Vector3(0f, beatTempo * Time.deltaTime, 0);

        }




        
    }







    // END OF FILE
}
