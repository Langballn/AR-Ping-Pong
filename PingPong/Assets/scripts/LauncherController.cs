using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherController : MonoBehaviour {

    private float speed = 0.05f;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Vector3 position = this.transform.position;
            position.x -= speed;
            this.transform.position = position;
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            Vector3 position = this.transform.position;
            position.x += speed;
            this.transform.position = position;
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            Vector3 position = this.transform.position;
            position.z += speed;
            this.transform.position = position;
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            Vector3 position = this.transform.position;
            position.z -= speed;
            this.transform.position = position;
        }

    }
}