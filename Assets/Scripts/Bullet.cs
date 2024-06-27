using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	[SerializeField] private Rigidbody2D rb;

	public GameObject owner;
	public float moveSpeed = 1.0f;

	private void Start()
	{
		StartCoroutine(SetLifetime());
	}
	private void FixedUpdate()
	{
		rb.MovePosition(rb.position + (Vector2)transform.up * moveSpeed);
	}
	private void OnTriggerEnter2D(Collider2D collder)
	{
		if (collder.gameObject == owner) return;
		Destroy(gameObject);
	}

	IEnumerator SetLifetime(int seconds = 10)
	{
		yield return new WaitForSeconds(seconds);
		Destroy(gameObject);
	}
}
