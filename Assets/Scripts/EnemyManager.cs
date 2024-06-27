using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyManager : MonoBehaviour
{
	[SerializeField] private GameObject player;
	[SerializeField] private GameObject enemy;
	[SerializeField] private int spawnDelay = 3;
	[SerializeField] private int spawnDistance = 10;

	private float lastSpawnedTime = 0;
	private void FixedUpdate()
	{
		if (Time.time - lastSpawnedTime >= spawnDelay)
		{
			GameObject createdEnemy = Instantiate(enemy);
			createdEnemy.transform.position = GetRandomPosiitionFromPlayer();
			lastSpawnedTime = Time.time;
		}
	}
	private Vector3 GetRandomPosiitionFromPlayer()
	{
		return (Vector3)MathUtils.DegreeToVector2(Random.Range(0, 360)) * spawnDistance + player.transform.position;
	}
}
