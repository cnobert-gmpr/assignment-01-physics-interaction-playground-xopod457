using UnityEngine;

public class PortalScript : MonoBehaviour
{
    [SerializeField] private Transform destination; 
    [SerializeField] private float cooldown = 0.5f; 
    
    private float timer = 0f;

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object is the Ball and if the cooldown is over
        if (collision.CompareTag("Ball") && timer <= 0)
        {
            if (destination != null)
            {
                // Teleport the ball to the destination's position
                collision.transform.position = destination.position;

                // Tell the destination portal to start its cooldown
                destination.GetComponent<PortalScript>().StartCooldown();
            }
        }
    }

    public void StartCooldown()
    {
        timer = cooldown;
    }
}