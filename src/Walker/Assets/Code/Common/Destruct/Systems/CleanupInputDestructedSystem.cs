using System.Collections.Generic;
using Entitas;

namespace Code.Common.Systems
{
	public class CleanupInputDestructedSystem : ICleanupSystem
	{
		private readonly IGroup<InputEntity> _entities;
		private readonly List<InputEntity> _buffer = new(128);

		public CleanupInputDestructedSystem(InputContext meta)
		{
			_entities = meta.GetGroup(InputMatcher
				.AllOf(
					InputMatcher.Destructed));
		}

		public void Cleanup()
		{
			foreach (InputEntity entity in _entities.GetEntities(_buffer))
				entity.Destroy();
		}
	}
}