using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
	[SerializeField] GameObject target;
	[SerializeField] Rigidbody2D rb;

	public float speed = 1.0f;

	private void Awake()
	{
		target = GameObject.FindGameObjectWithTag("Player");
	}
	private void FixedUpdate()
	{
		Vector3 direction = (target.transform.position - transform.position).normalized;
		rb.MovePosition(rb.position + (Vector2)direction * speed);
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		Destroy(gameObject);
	}
}
