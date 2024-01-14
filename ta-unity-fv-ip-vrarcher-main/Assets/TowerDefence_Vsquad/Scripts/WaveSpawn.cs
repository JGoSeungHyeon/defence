using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class WaveSpawn : MonoBehaviour {

	public int Wave = 1;
	public int WaveSize;
	public float EnemyInterval;
	public Transform[] spawnPoint;
	public float startTime;
	public GameObject[] MonsterPrefab;
	public Transform[] WayPoints;
	public List<GameObject> MonsterPool = new List<GameObject>();
	private bool WaveStart = false;
	int enemyCount=0;

	public void StartSpawn()
    {
		
		EnemyInthePool();
		InvokeRepeating("SpawnEnemy", startTime, EnemyInterval);
	}

	void Update()
	{
		if(WaveStart && enemyCount == MonsterPool.Count-1)
		{
			CancelInvoke("SpawnEnemy");
			Wave++;
			WaveStart = false;
		}
	}

	void SpawnEnemy()
	{
		int rand = Random.Range(0, 4);
		enemyCount++;
		GameObject enemy = GameObject.Instantiate(MonsterPool[enemyCount-1], spawnPoint[rand].position,Quaternion.identity) as GameObject;
		enemy.GetComponent<Enemy>().waypoints = WayPoints;
    }
	void EnemyInthePool()
    {
		
		if (Wave <= 2)
		{
			for (int i = 0; i < 4; i++)
			{
				GameObject clonedPrefab = Instantiate(MonsterPrefab[0]);
				Debug.Log("재생");
				MonsterPool.Add(clonedPrefab);
			}
		}
		else if(Wave <= 4)
        {
			for (int i = 0; i < 2; i++)
			{
				GameObject clonedPrefab = Instantiate(MonsterPrefab[1]);
				MonsterPool.Add(clonedPrefab);
			}
		}
    }
}
