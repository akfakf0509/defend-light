using UnityEngine;

public class PlayerControler : MonoBehaviour
{
	[SerializeField] private GameObject bullet;
	[SerializeField] private Rigidbody2D rb;

	public float moveSpeed = 1.0f;

	Vector2 moveDirection;

	private void Update()
	{
		moveDirection.x = Input.GetAxisRaw("Horizontal");
		moveDirection.y = Input.GetAxisRaw("Vertical");

		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			Vector3 mouseWordPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector3 mouseDirection = mouseWordPos - transform.position;
			float angle = Vector2.Angle(transform.up, mouseDirection);
			angle *= Vector2.Dot(-transform.right, mouseDirection) > .0f ? 1 : -1;
			GameObject newBullet = Instantiate(bullet);
			newBullet.transform.position = transform.position;
			newBullet.transform.Rotate(new Vector3(0, 0, angle));
		}
	}
	private void FixedUpdate()
	{
		rb.MovePosition(rb.position + moveDirection.normalized * moveSpeed);
	}
}
