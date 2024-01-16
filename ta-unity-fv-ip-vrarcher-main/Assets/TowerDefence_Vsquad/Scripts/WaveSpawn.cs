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
	public int enemyCount=0;

	public void StartSpawn()
    {

		EnemyInthePool();
		InvokeRepeating("SpawnEnemy", startTime, EnemyInterval);
	}

	void Update()
	{
		updateUI();
		if (WaveStart && enemyCount == MonsterPool.Count)
		{
			CancelInvoke("SpawnEnemy");
			Wave++;
			WaveStart = false;
			GameManager.instance.playerStatus = PlayerStatus.Idle;
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
		enemyCount = 0;
		GameManager.instance.playerStatus = PlayerStatus.Battle;
		WaveStart = true;
		if (Wave <= 2)
		{
			for (int i = 0; i < 4; i++)
			{
				GameObject clonedPrefab = Instantiate(MonsterPrefab[0]);
				Debug.Log("재생");
				MonsterPool.Add(clonedPrefab);
			}
		}
		else if (Wave <= 4)
		{
			EnemyInterval = 3;
			for (int i = 0; i < 2; i++)
			{
				GameObject clonedPrefab = Instantiate(MonsterPrefab[0]);
				MonsterPool.Add(clonedPrefab);
			}
		}
		else if (Wave <= 6)
		{
			for (int i = 0; i < 2; i++)
			{
				GameObject clonedPrefab = Instantiate(MonsterPrefab[0]);
				MonsterPool.Add(clonedPrefab);
			}
			EnemyInterval = 1;
		}
    }
    void updateUI()
    {
		UIManager.instance.WaveText.text =  $"Wave : {Wave}";
		UIManager.instance.KillMonsterText.text =  $"잡은 몬스터 수 : {GameManager.instance.MonsterCount}";
		UIManager.instance.GoldText.text = $"{GameManager.instance.MyMoney}";
    }
}
