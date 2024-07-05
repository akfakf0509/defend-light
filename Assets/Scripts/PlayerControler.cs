using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControler : MonoBehaviour
{
	[SerializeField] private Collider2D collder;
	[SerializeField] private GameObject bullet;
	[SerializeField] private Rigidbody2D rb;

	[SerializeField] private int shootPerSeconds = 1;

	public float moveSpeed = 1.0f;

	Vector2 moveDirection;

	float lastShootedTime = -1;
	private void Update()
	{
		moveDirection.x = Input.GetAxisRaw("Horizontal");
		moveDirection.y = Input.GetAxisRaw("Vertical");

		if (Input.GetKey(KeyCode.Mouse0) && Time.time - lastShootedTime >= 1 / shootPerSeconds)
		{
			Vector3 mouseWordPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector3 mouseDirection = mouseWordPos - transform.position;
			GameObject newGameObject = Instantiate(bullet);
			Bullet newBullet = newGameObject.GetComponent<Bullet>();
			newGameObject.transform.position = transform.position;
			newGameObject.transform.Rotate(new Vector3(0, 0, MathUtils.DirectionToDegree(mouseDirection)));
			newBullet.owner = gameObject;
			newBullet.ownerCollider = collder;
			lastShootedTime = Time.time;
		}
	}
	private void FixedUpdate()
	{
		rb.MovePosition(rb.position + moveDirection.normalized * moveSpeed);
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		SceneManager.LoadScene(0);
	}
}
