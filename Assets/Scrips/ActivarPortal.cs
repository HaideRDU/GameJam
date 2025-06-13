using UnityEngine;

public class ActivarPortal : MonoBehaviour
{
    public GameObject portales;
    public GameObject ActivarPortalportales;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Caja"))
        {
            portales.SetActive(true);
            
            Destroy(ActivarPortalportales);
        }
    } 
}
