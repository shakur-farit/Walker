using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Code.Meta.Features.Hud.HeroHeartHolder.Factory
{
	public interface IHeartUIFactory
	{
		UniTask<GameObject> CreateHeartUI(Transform parent);
	}
}