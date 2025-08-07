﻿using System.Collections.Generic;
using Entitas;

namespace Code.Common.Systems
{
	public class CleanupGameDestructedSystem : ICleanupSystem
	{
		private readonly IGroup<GameEntity> _entities;
		private readonly List<GameEntity> _buffer = new(128);

		public CleanupGameDestructedSystem(GameContext game)
		{
			_entities = game.GetGroup(GameMatcher
				.AllOf(
					GameMatcher.Destructed));
		}

		public void Cleanup()
		{
			foreach (GameEntity entity in _entities.GetEntities(_buffer)) 
				entity.Destroy();
		}
	}
}