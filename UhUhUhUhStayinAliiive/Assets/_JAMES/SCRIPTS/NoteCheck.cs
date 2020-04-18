using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteCheck : MonoBehaviour
{
    public bool canBePressed;

    public KeyCode keyToPress;

    public GameObject hitEffect, goodEffect, perfectEffect, missEffect;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            if (canBePressed)
            {
                gameObject.SetActive(false);

                // GameManager.instance.NoteHit();

                
                // IF WE ARE WITHIN CERTAIN THRESHOLDS WE WILL GET BONUS POINTS
                if (Mathf.Abs(transform.position.y) > .25)
                {
                    Debug.Log("hit");
                    GameManager.instance.NormalHit(); //ADD CORRSPONGDING SCORE VALUE

                    // INSTANTIATE OUR SPECIAL FX
                    Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);

                }
                else if (Mathf.Abs(transform.position.y) > .05)
                {
                    Debug.Log("good hit");
                    GameManager.instance.GoodHit(); //ADD CORRSPONGDING SCORE VALUE

                    // INSTANTIATE OUR SPECIAL FX
                    Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);

                }
                else
                {
                    Debug.Log("perfect hit");
                    GameManager.instance.PerfectHit(); //ADD CORRSPONGDING SCORE VALUE

                    // INSTANTIATE OUR SPECIAL FX
                    Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);

                }
                
            }

        }



    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (gameObject.activeInHierarchy)
        {
            if (other.tag == "Activator")
            {
                canBePressed = false;

                GameManager.instance.NoteMiss();

                // INSTANTIATE OUR SPECIAL FX
                Instantiate(missEffect, transform.position, missEffect.transform.rotation);

            }
            gameObject.SetActive(false);

        }


    }



    // END OF FILE
}
