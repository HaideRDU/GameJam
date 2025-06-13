using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMenu : MonoBehaviour
{
    private bool IsTp;
 

    private GameObject player;

    private bool playerDentro;
    void Start()
    {

    }
 
    // Update is called once per frame
    void Update()
    {
        if (playerDentro && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("Main Menu");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerDentro = true;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerDentro = false;
        }
    }
}
