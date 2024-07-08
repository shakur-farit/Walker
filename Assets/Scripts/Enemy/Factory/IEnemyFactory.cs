using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Enemy.Factory
{
	public interface IEnemyFactory
	{
		UniTask<GameObject> Create(Vector2 position);
		void Destroy(GameObject gameObject);
	}
}