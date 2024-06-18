using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    public float moveSpeed = 1.0f;

	Vector2 moveDirection;

	private void Update()
	{
		moveDirection.x = Input.GetAxisRaw("Horizontal");
		moveDirection.y = Input.GetAxisRaw("Vertical");
	}
	private void FixedUpdate()
	{
		rb.MovePosition(rb.position + moveDirection.normalized * moveSpeed);
	}
}
