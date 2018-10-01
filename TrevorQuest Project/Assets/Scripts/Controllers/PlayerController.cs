using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerEngine))]
public class PlayerController : MonoBehaviour {

    public Interactable target;

    Camera cam;
    PlayerEngine engine;

	// Use this for initialization
	void Start () {
        cam = Camera.main;
        engine = GetComponent<PlayerEngine>();
    }
	
	// Update is called once per frame
	void Update () {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

		if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // move player to mouse click
                engine.MoveToPoint(hit.point);
                Debug.Log("We hit " + hit.collider.name + " " + hit.point);
                // stop focusing objects
                ClearTarget();

            }
        }
        if (Input.GetMouseButton(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Interactable intertacble = hit.collider.GetComponent<Interactable>();
                if (intertacble != null)
                {
                    SetTarget(intertacble);
                } 
            }
        }
	}

    void SetTarget(Interactable newTarget)
    {
        if (newTarget != target)
        {
           if (target != null) 
                target.OnDeTarget();

            target = newTarget;
            engine.FollowTarget(newTarget);
        }
        newTarget.OnTarget(transform);
    }

    void ClearTarget()
    {
        if (target != null)
            target.OnDeTarget();
        target = null;
        engine.StopFollowingTarget();
    }
}
