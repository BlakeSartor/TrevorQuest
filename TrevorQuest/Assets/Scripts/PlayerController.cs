using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerEngine))]
public class PlayerController : MonoBehaviour {
    Camera cam;
    PlayerEngine engine;

	// Use this for initialization
	void Start () {
        cam = Camera.main;
        engine = GetComponent<PlayerEngine>();
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // move player to mouse click
                engine.MoveToPoint(hit.point);
                Debug.Log("We hit" + hit.collider.name + " " + hit.point);
                // stop focusing objects
            }
        }
	}
}
