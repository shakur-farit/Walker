using Cysharp.Threading.Tasks;
using Inventory;
using UnityEngine;

namespace UI.Factory
{
	public interface IItemCellFactory
	{
		UniTask<ItemCell> Create(Transform parent, Vector2 position);
	}
}