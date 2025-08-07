﻿using Code.Infrastructure.View.Registrars;
using UnityEngine;

namespace Code.Gameplay.Common.Registrars
{
	public class SpriteRendererRegistrar : EntityComponentRegistrar
	{
		[SerializeField] private SpriteRenderer _spriteRenderer;

		public override void RegisterComponents() => 
			Entity.AddSpriteRenderer(_spriteRenderer);

		public override void UnregisterComponents()
		{
			if (Entity.hasSpriteRenderer)
				Entity.RemoveSpriteRenderer();
		}
	}
}