using UnityEngine;

public class portal1_a_poratl2 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private bool IsTp;
    public GameObject TP;

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
            player.transform.position = TP.transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerDentro = true;
            player = collision.gameObject;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerDentro = false;
            player = null;
        }
    }
}
