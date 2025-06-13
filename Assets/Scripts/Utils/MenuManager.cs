using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void NewGame(){
        SceneManager.LoadScene("Game");
    }
    
    public void Tutorial(){
        SceneManager.LoadScene("Duplicado");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
