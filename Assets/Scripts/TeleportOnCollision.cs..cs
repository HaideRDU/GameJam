using UnityEngine;
using UnityEngine.Audio;

public class TeleportOnCollision : MonoBehaviour
{
    [SerializeField] private Vector3 teleportLocation;
    public AudioSource audioPlayer;
    public AudioSource audioPlayer2;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = teleportLocation;
            audioPlayer.Play();
            audioPlayer2.Stop();
        }
    }
}