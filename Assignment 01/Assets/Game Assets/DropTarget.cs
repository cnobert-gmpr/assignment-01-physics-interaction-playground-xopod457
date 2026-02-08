using UnityEngine;
using System.Collections;

public class DropTarget : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float resetDelay = 2f;
    
    private SpriteRenderer spriteRenderer;
    private Collider2D targetCollider;
    private bool isActive = true;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        targetCollider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Only react if hit by the ball and not already cooling down
        if (isActive && collision.CompareTag("Ball"))
        {
            HitTarget();
        }
    }

    private void HitTarget()
    {
        isActive = false;
        

        spriteRenderer.enabled = false; 
        
        Debug.Log(gameObject.name + " was hit!");

        StartCoroutine(ResetTarget());
    }

    private IEnumerator ResetTarget()
    {

        yield return new WaitForSeconds(resetDelay);

        spriteRenderer.enabled = true;
        targetCollider.enabled = true;
        isActive = true;
    }
}