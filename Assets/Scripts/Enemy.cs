using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField] GameObject target;
	[SerializeField] GameObject body;
	[SerializeField] GameObject destoryEffect;
	[SerializeField] Rigidbody2D rb;

	public float speed = 1.0f;

	private void Start()
	{
		target = GameObject.FindGameObjectWithTag("Player");
	}
	private void FixedUpdate()
	{
		Vector3 direction = (target.transform.position - transform.position).normalized;
		rb.MovePosition(rb.position + (Vector2)direction * speed);
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		Destroy(gameObject);
		GameObject newDestoryEffect = Instantiate(destoryEffect);
		newDestoryEffect.transform.position = collision.GetContact(0).point;
		newDestoryEffect.transform.eulerAngles = collision.gameObject.transform.eulerAngles;
	}
}
