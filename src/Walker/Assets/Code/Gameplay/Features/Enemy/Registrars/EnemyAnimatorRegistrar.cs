using Code.Gameplay.StaticData;
using Code.Infrastructure.View.Registrars;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Features.Enemy
{
	public class EnemyAnimatorRegistrar : EntityComponentRegistrar
	{
		[SerializeField] private EnemyAnimator _enemyAnimator;

		private IStaticDataService _staticDataService;

		[Inject]
		public void Constructor(IStaticDataService staticDataService) =>
			_staticDataService = staticDataService;

		public override void RegisterComponents()
		{
			Entity
				.AddEnemyAnimator(_enemyAnimator)
				.AddDamageTakenAnimator(_enemyAnimator);

			EnemyTypeId typeId = Entity.EnemyTypeId;
			EnemyConfig config = _staticDataService.GetEnemyConfig(typeId);

			_enemyAnimator.SetRuntimeAnimatorController(config.AnimatorController);
		}

		public override void UnregisterComponents()
		{
			if (Entity.hasEnemyAnimator)
				Entity.RemoveEnemyAnimator();

			if (Entity.hasDamageTakenAnimator)
				Entity.RemoveDamageTakenAnimator();
		}
	}
}