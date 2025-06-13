using UnityEngine;

public class Ganar : MonoBehaviour
{

    private GameManager gamemanager;

    void Start()
    {
        gamemanager = FindFirstObjectByType<GameManager>();     
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gamemanager.WinGame();
        }
    }
}
