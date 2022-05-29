using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void startgame()
    {
        SceneManager.LoadScene("Game");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void credits()
    {
        SceneManager.LoadScene("Creditos");
    }

    public void cerrar()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
