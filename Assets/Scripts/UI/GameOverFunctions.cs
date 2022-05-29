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
        SceneManager.LoadScene("Game");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
