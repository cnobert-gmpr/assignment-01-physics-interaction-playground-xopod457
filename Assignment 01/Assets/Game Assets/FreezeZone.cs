using UnityEngine;
using System.Collections;

public class FreezeZone : MonoBehaviour
{
    [Header("Freeze Zone Settings")]
    [SerializeField] private float freezeDuration = 3f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the colliding object is the Ball
        if (collision.CompareTag("Ball")) 
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                StartCoroutine(FreezeObject(rb));
            }
        }
    }

    private IEnumerator FreezeObject(Rigidbody2D rb)
    {

        Vector2 originalVelocity = rb.linearVelocity;
        float originalGravity = rb.gravityScale;
        RigidbodyType2D originalType = rb.bodyType;


        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;
        rb.bodyType = RigidbodyType2D.Kinematic;


        yield return new WaitForSeconds(freezeDuration);


        if (rb != null) 
        {
            rb.bodyType = originalType;
            rb.linearVelocity = originalVelocity;
        }
    }
}