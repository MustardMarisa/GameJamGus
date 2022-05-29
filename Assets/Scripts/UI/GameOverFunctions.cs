using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverFunctions : MonoBehaviour
{
    [SerializeField] private GameObject gameOverText;
    [SerializeField] private GameObject buttonContainer;

    private void Start()
    {
        //Game Over Text
        LeanTween.scale(gameOverText, new Vector3(1, 1, 1), 3f).setEase(LeanTweenType.easeInOutExpo);

        //Buttons
        LeanTween.scale(buttonContainer, new Vector3(1, 1, 1), 1f).setEaseLinear().setDelay(3f);
    }

    public void StartGame()
    {
        //SceneManager.LoadScene("MainGame");
        Debug.Log("Llamada a la pantalla del juego principal");
    }

    public void Quit()
    {
        Debug.Log("Cerrar el juego");
        Application.Quit();
    }
}
