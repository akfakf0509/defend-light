using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyManager : MonoBehaviour
{
	[SerializeField] private GameObject enemy;
	[SerializeField] private int spawnDelay = 3;
	[SerializeField] private int maxEnemyCount = 5;

	private IObjectPool<GameObject> enemyPool;

	private void Awake()
	{
		enemyPool = new ObjectPool<GameObject>(() => Instantiate(enemy));
	}

	private float lastSpawnedTime = 0;
	private void FixedUpdate()
	{
		if (Time.time - lastSpawnedTime >= spawnDelay && enemyPool.CountInactive < maxEnemyCount)
		{
			enemyPool.Get();
			lastSpawnedTime = Time.time;
		}
	}
}
