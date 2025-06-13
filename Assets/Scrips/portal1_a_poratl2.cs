using UnityEngine;

public class portal1_a_poratl2 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private bool IsTp;
    private 
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && IsTp)
        {
            
        }
    }
}
