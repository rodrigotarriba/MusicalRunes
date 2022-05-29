using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotion : MonoBehaviour
{
    public float speed = 0.1f;
    Vector3 position;

	private void Update()
	{
		if (Input.GetKey(KeyCode.RightArrow))
		{
			position = transform.position;
			position.x += speed;
			transform.position = position;
		}
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			position = transform.position;
			position.x -= speed;
			transform.position = position;
		}
		if (Input.GetKey(KeyCode.UpArrow))
		{
			position = transform.position;
			position.y += speed;
			transform.position = position;
		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			position = transform.position;
			position.y -= speed;
			transform.position = position;
		}
	}
}
