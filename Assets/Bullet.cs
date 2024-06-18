using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	[SerializeField]
	private Rigidbody2D rb;

	public float moveSpeed = 1.0f;

	private void FixedUpdate()
	{
		rb.MovePosition(rb.position + (Vector2)transform.up * moveSpeed);
	}
}
