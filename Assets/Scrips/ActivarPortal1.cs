using UnityEngine;

public class ActivarPortal1 : MonoBehaviour
{
    public GameObject portales;
    public GameObject texto;
    public GameObject ActivarPortalportales;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Caja"))
        {
            portales.SetActive(true);
            texto.SetActive(true);
            Destroy(ActivarPortalportales);
        }
    } 
}
