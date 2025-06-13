using UnityEngine;

public class GrabOnject : MonoBehaviour
{
    [SerializeField]
    private bool activarMover;
    private bool isBeingCarried;
    public GameObject player;
    public Collider2D colider;

    private PlayerController playerController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (activarMover)
        {
            if (Input.GetKey(KeyCode.E)) 
            {
                if (!isBeingCarried)
                {
                    playerController.dragActive = true;
                    transform.SetParent(player.transform);
                    isBeingCarried = true; 
                    colider.enabled = false;
                }
            }
            if (Input.GetKeyUp(KeyCode.E)&& isBeingCarried)
            {
                playerController.dragActive = true;
                transform.SetParent(null);
                isBeingCarried = false;
                colider.enabled = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            activarMover = true;
            Debug.Log(activarMover);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))

        {
            activarMover = false;
            Debug.Log(activarMover);
        }
    }
}
