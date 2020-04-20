using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    


    public void LoadJvac()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadStayinAlive()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }



    // END OF FILE
}
