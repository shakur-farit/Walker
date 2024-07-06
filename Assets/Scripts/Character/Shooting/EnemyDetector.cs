using System.Collections.Generic;
using Enemy;
using UnityEngine;

namespace Character.Shooting
{
	public class EnemyDetector : MonoBehaviour
	{
		[SerializeField] private CharacterAimer _aimer;

		private Queue<EnemyHealth> _enemiesQueue;

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.TryGetComponent(out EnemyHealth enemy)) 
				AddToEnemiesInQueue(enemy);
		}

		private void OnTriggerExit2D(Collider2D other)
		{
			if (other.TryGetComponent(out EnemyHealth enemy))
				RemoveFromEnemiesInRangeList();
		}

		private void AddToEnemiesInQueue(EnemyHealth enemy) => 
			_enemiesQueue.Enqueue(enemy);

		private void RemoveFromEnemiesInRangeList()
		{
			
		}
	}
}