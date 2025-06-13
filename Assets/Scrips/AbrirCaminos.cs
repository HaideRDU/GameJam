using UnityEngine;

public class AbrirCaminos : MonoBehaviour
{
    [Header("Puerta")]
    public GameObject puerta;
    [Header("Audio")]

    public AudioSource audioSource;

    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {  
            audioSource.Play();
            Destroy(puerta);
            spriteRenderer.enabled = false;
            Destroy(gameObject, audioSource.clip.length);
        }
    }
}
