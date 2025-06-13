using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public float gameTime;
    public bool gameActive;

    void Awake(){
        if (Instance != null && Instance != this){
            Destroy(this);
        } else {
            Instance = this;
        }
    }

    void Start(){
        gameActive = true;
    }

    void Update(){
        if (gameActive){
            gameTime += Time.deltaTime;
            

            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)){
                Pause();
            }
        }
    }

    public void GameOver()
    {
        gameActive = false;

        StartCoroutine(ShowGameOverScreen());
        Time.timeScale = 0f;
        
    }

    IEnumerator ShowGameOverScreen()
    {
        yield return new WaitForSeconds(0f);
        UIController.Instance.gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
        AudioController.Instance.PlaySound(AudioController.Instance.gameOver);
        
    }

    public void Restart(){
        SceneManager.LoadScene("Game");
    }

    public void Pause(){
        {
            if (
                UIController.Instance.pausePanel.activeSelf == false && 
                UIController.Instance.gameOverPanel.activeSelf == false
                ){
                UIController.Instance.pausePanel.SetActive(true);
                Time.timeScale = 0f;
                AudioController.Instance.PlaySound(AudioController.Instance.pause);
            } else {
                UIController.Instance.pausePanel.SetActive(false);
                Time.timeScale = 1f;
                AudioController.Instance.PlaySound(AudioController.Instance.unpause);
            }
        }
    }

    public void WinGame()
    {
        gameActive = false;

        StartCoroutine(ShowWinScreen());
        Time.timeScale = 0f;
    }

    IEnumerator ShowWinScreen()
    {
        yield return new WaitForSeconds(0f);
        UIController.Instance.winGamePanel.SetActive(true);
        Time.timeScale = 0f;
        AudioController.Instance.PlaySound(AudioController.Instance.gameOver);
        
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void GoToMainMenu(){
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1f;
    }
}
