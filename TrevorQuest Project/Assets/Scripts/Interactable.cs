using UnityEngine;

public class Interactable : MonoBehaviour {
    
    public float radius = 3f;
    public Transform interactionTransform;

    bool isTarget = false;
    bool hasInteracted = false;

    Transform player;

    public virtual void Interact()
    {
        // This can be overwritten
        Debug.Log("Interacting with " + transform.name);
    }

    private void Update()
    {
        if (isTarget && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, transform.position);
            if (distance <= radius)
            {
                Interact();
                Debug.Log("INTERACT");
                hasInteracted = true;

            }
        }
    }

    public void OnTarget (Transform playerTransform)
    {
        isTarget = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void OnDeTarget()
    {
        isTarget = false;
        player = null;
        hasInteracted = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}

