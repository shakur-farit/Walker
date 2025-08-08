using UnityEngine;

namespace Code.Gameplay.Features.Enemy
{
	public interface IAmmoFactory
	{
		GameEntity CreateAmmo(AmmoTypeId typeId, Vector3 at);
	}
}