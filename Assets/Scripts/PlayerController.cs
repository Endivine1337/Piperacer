using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float movementSpeed = 2.0f;
    public float horizonzal, direction;
    public Transform Pivot;
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        float moveHorizontal = horizonzal = Input.GetAxis("Horizontal");

        //if (Mathf.Abs(moveHorizontal) < 0.001f) moveHorizontal = 0;
        direction = moveHorizontal < 0 ? -1 : moveHorizontal > 0 ? 1 : 0;
        Vector3 movement = new Vector3(0.0f, 0.0f, moveHorizontal);

        //transform.Rotate(movement * movementSpeed * Time.deltaTime);
        Pivot.Rotate(movement * movementSpeed * Time.deltaTime);
        //transform.position = new Vector3(direction * -0.1f, transform.position.y, transform.position.z);
        transform.rotation = Quaternion.Euler(90, direction * -15, 0);
    }
}
