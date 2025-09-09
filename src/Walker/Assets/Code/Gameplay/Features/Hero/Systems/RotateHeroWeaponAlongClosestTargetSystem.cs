using Code.Gameplay.Features.Enemy;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Hero.Systems
{
	public class RotateHeroWeaponAlongClosestTargetSystem : IExecuteSystem
	{
		private readonly IGroup<GameEntity> _hero;

		public RotateHeroWeaponAlongClosestTargetSystem(GameContext game)
		{
			_hero = game.GetGroup(GameMatcher
				.AllOf(
					GameMatcher.Hero,
					GameMatcher.WorldPosition,
					GameMatcher.WeaponRotationPoint,
					GameMatcher.ClosestEnemyPosition));
		}

		public void Execute()
		{
			foreach (GameEntity hero in _hero)
			{
				Vector3 closestTargetPosition = hero.ClosestEnemyPosition;

				RotateWeapon(closestTargetPosition, hero);
			}
		}

		private void RotateWeapon(Vector3 closestTargetPosition, GameEntity hero)
		{
			Vector3 direction = (closestTargetPosition - hero.WorldPosition)
				.normalized;
			float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
			hero.WeaponRotationPoint.rotation = Quaternion.Euler(0, 0, angle);
		}
	}
}