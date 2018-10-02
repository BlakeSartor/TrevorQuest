using UnityEngine;

public class Interactable : MonoBehaviour {
    
    public float radius = 3f;
    public float offset = 1f;
    public Transform interactionTransform;

    bool isTarget = false;
    bool hasInteracted = false;

    Transform player;

    public virtual void Interact()
    {
        // This can be overwritten
        //Debug.Log("Interacting with " + transform.name);
    }

    private void Update()
    {
        if (isTarget && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, transform.position);
            if (distance <= radius)
            {
                Interact();
                //Debug.Log("INTERACT");
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

        if (interactionTransform == null)
            interactionTransform = transform;
        Gizmos.color = Color.yellow;
        Vector3 offsetPos = new Vector3(transform.position.x, transform.position.y + offset, transform.position.z);
        Gizmos.DrawWireSphere(offsetPos, radius);
    }

}

