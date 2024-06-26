using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	[SerializeField] private Rigidbody2D rb;

	public float moveSpeed = 1.0f;

	private void Start()
	{
		StartCoroutine(SetLifetime());
	}
	private void FixedUpdate()
	{
		rb.MovePosition(rb.position + (Vector2)transform.up * moveSpeed);
	}

	IEnumerator SetLifetime(int seconds = 10)
	{
		yield return new WaitForSeconds(seconds);
		Destroy(gameObject);
	}
}
