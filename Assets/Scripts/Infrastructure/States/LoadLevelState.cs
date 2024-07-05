using Character.Factory;
using Hud.Factory;
using UnityEngine;

namespace Infrastructure.States
{
	public class LoadLevelState : IGameState
	{
		private readonly ICharacterFactory _characterFactory;
		private readonly IHudFactory _hudFactory;

		public LoadLevelState(ICharacterFactory characterFactory, IHudFactory hudFactory)
		{
			_characterFactory = characterFactory;
			_hudFactory = hudFactory;
		}

		public void Enter()
		{
			_characterFactory.Create();
			_hudFactory.Create();
		}

		public void Exit()
		{
			
		}
	}
}