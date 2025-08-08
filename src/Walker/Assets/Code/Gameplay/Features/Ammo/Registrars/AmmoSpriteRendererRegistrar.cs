using Code.Gameplay.StaticData;
using Code.Infrastructure.View.Registrars;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Features.Enemy
{
	public class AmmoSpriteRendererRegistrar : EntityComponentRegistrar
	{
		[SerializeField] private SpriteRenderer _spriteRenderer;

		private IStaticDataService _staticDataService;

		[Inject]
		public void Constructor(IStaticDataService staticDataService) =>
			_staticDataService = staticDataService;

		public override void RegisterComponents()
		{
			_spriteRenderer.sprite =
				_staticDataService
					.GetAmmoConfig(Entity.AmmoTypeId).Sprite;

			Entity
				.AddSpriteRenderer(_spriteRenderer);
		}

		public override void UnregisterComponents()
		{
			if (Entity.hasSpriteRenderer)
				Entity.RemoveSpriteRenderer();
		}
	}
}