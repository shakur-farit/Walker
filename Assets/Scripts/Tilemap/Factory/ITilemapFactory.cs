using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Enemy.Factory
{
	public interface ITilemapFactory
	{
		UniTask Create();
		void Destroy();
	}
}