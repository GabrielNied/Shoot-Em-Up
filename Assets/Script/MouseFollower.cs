using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollower : MonoBehaviour {

    public float Distance = 10;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 pos = r.GetPoint(Distance);
        transform.position = pos;
	}
}
