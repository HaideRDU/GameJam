using UnityEngine;

public class Creditos : MonoBehaviour
{

    public GameObject creditos;

    public void Abrir()
    {
        creditos.SetActive(true);
    }

    public void Cerrar()
    {
        creditos.SetActive(false);
    }
}
