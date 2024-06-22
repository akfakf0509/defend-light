using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField] GameObject target;
	[SerializeField] Rigidbody2D rb;

	public float speed = 1.0f;

	private void FixedUpdate()
	{
		Vector3 direction = (target.transform.position - transform.position).normalized;
		rb.MovePosition(rb.position + (Vector2)direction * speed);
	}
}
