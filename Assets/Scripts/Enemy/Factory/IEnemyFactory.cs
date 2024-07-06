using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Enemy.Factory
{
	public interface IEnemyFactory
	{
		UniTask Create(Vector2 position);
		void Destroy(GameObject gameObject);
	}
}