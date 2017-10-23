using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetConroller : MonoBehaviour {

    private float speed = 0.05f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Vector3 position = this.transform.position;
            position.x -= speed;
            this.transform.position = position;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Vector3 position = this.transform.position;
            position.x += speed;
            this.transform.position = position;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Vector3 position = this.transform.position;
            position.z += speed;
            this.transform.position = position;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Vector3 position = this.transform.position;
            position.z -= speed;
            this.transform.position = position;
        }
        
    }
}
