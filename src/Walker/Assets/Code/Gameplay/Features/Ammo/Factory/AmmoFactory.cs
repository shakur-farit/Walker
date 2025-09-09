using System;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.StaticData;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Enemy
{
	public class AmmoFactory : IAmmoFactory
	{
		private readonly IIdentifierService _identifier;
		private readonly IStaticDataService _staticDataService;

		public AmmoFactory(IIdentifierService identifier, IStaticDataService staticDataService)
		{
			_identifier = identifier;
			_staticDataService = staticDataService;
		}

		public GameEntity CreateAmmo(AmmoTypeId typeId, Vector3 at)
		{
			switch (typeId)
			{
				case AmmoTypeId.HeroAmmo:
					return CreateHeroAmmo(typeId, at);
				case AmmoTypeId.EnemyAmmo:
					return CreateEnemyAmmo(typeId, at);
			}

			throw new Exception($"Ammo with type id {typeId} does not exist");
		}

		private GameEntity CreateHeroAmmo(AmmoTypeId typeId, Vector3 at) => 
			CreateAmmoEntity(typeId, at)
				.AddTargetLayerMask(CollisionLayer.Enemy.AsMask())
				.With(x => x.isHeroAmmo = true);

		private GameEntity CreateEnemyAmmo(AmmoTypeId typeId, Vector3 at) => 
			CreateAmmoEntity(typeId, at)
				.AddTargetLayerMask(CollisionLayer.Hero.AsMask())
				.With(x => x.isEnemyAmmo = true);

		private GameEntity CreateAmmoEntity(AmmoTypeId typeId, Vector3 at)
		{
			AmmoConfig config = _staticDataService.GetAmmoConfig(typeId);

			return CreateEntity.Empty()
					.AddId(_identifier.Next())
					.AddAmmoTypeId(typeId)
					.AddViewPrefab(config.ViewPrefab)
					.AddWorldPosition(at)
					.AddSpeed(config.MovementSpeed)
					.AddTargetsBuffer(new())
					.AddProcessedTargets(new())
					.AddTargetLimit(config.Pierce)
					.AddRadius(config.Range)
					.With(x => x.isAmmo = true)
					.With(x => x.isMovementAvailable = true)
					.With(x => x.isReadyToCollectTargets = true)
					.With(x => x.isCollectTargetsContinuously = true)
				;
		}
	}
}