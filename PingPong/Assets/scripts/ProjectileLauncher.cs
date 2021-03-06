using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using HoloToolkit.Unity.InputModule;

public class ProjectileLauncher : MonoBehaviour, IInputClickHandler
{

    public GameObject launcher;
    public GameObject prefab;
    public GameObject target;

    public float magnitude = 5.0f;
    public float vertical_angle = 15.0f;

    void Update()
    {
        //Set up speed and magnitude of ball
        if (Input.GetKey("up") && vertical_angle <= 85)
        {
            vertical_angle = vertical_angle + 5;
        }

        if (Input.GetKey("down") && vertical_angle >= 5)
        {
            vertical_angle = vertical_angle - 5;
        }

        if (Input.GetKey("left") && magnitude >= 1)
        {
            magnitude = magnitude - 1.0f;
        }

        if (Input.GetKey("right"))
        {
            magnitude = magnitude + 1.0f;
        }
    }

    // Use this for initialization
    void Start () 
	{

    //default is that input events are sent to game object since no game object exists (instantiated by input) use modal event handler to trigger event
    InputManager.Instance.PushModalInputHandler(this.gameObject);
	}
	
	// Update is called once per frame
	public void OnInputClicked(InputClickedEventData eventData) 
	{
        //get target position on the table

        Vector3 initial_ball_position_y_shift = new Vector3(0.0f, 0.1f, 0.0f);
        Vector3 initial_ball_position = launcher.transform.position + initial_ball_position_y_shift;
        Debug.Log(initial_ball_position.x);
        Debug.Log(initial_ball_position.y);
        Debug.Log(initial_ball_position.z);
        //Ping pong ball instantiation happens here
        GameObject projectile = Instantiate(prefab, initial_ball_position, launcher.transform.rotation) as GameObject;
        Rigidbody rb = projectile.GetComponent<Rigidbody>();

        //get position of player
        Vector3 table_targetposition = target.transform.position;
        Debug.Log(table_targetposition.x);
        Debug.Log(table_targetposition.y);
        Debug.Log(table_targetposition.z);

        Vector3 launcher_position = launcher.transform.position;
        Debug.Log(launcher_position.x);
        Debug.Log(launcher_position.y);
        Debug.Log(launcher_position.z);

        //Set the direction towards the player
        Vector3 movement = table_targetposition - launcher_position;
        Debug.Log(movement.x);
        Debug.Log(movement.y);
        Debug.Log(movement.z);
        //normalize the vector movement
        movement = Vector3.Normalize(movement);
        Vector3 vertical_component = new Vector3(0.0f, (float)Math.Tan(vertical_angle * (Math.PI / 180)), 0.0f);
        movement = movement + vertical_component;

        //renormalize
        movement = Vector3.Normalize(movement);
        movement = movement * magnitude;

        Debug.Log(movement.x);
        Debug.Log(movement.y);
        Debug.Log(movement.z);

        rb.velocity = movement;

	}
}
