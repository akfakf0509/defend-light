using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	[SerializeField] private Collider2D collder;
	[SerializeField] private Rigidbody2D rb;

	public Collider2D ownerCollider;
	public GameObject owner;
	public float moveSpeed = 1.0f;

	private void Start()
	{
		StartCoroutine(SetLifetime());
		Physics2D.IgnoreCollision(collder, ownerCollider);
	}
	private void FixedUpdate()
	{
		rb.MovePosition(rb.position + (Vector2)transform.up * moveSpeed);
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		Destroy(gameObject);
	}

	IEnumerator SetLifetime(int seconds = 10)
	{
		yield return new WaitForSeconds(seconds);
		Destroy(gameObject);
	}
}
