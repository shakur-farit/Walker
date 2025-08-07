using Code.Gameplay.Features;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.Systems;

namespace Code.Infrastructure.States.GameStates
{
	public class BattleLoopState : EndOfFrameExitState
	{
		private BattleFeature _battleFeature;

		private readonly ISystemsFactory _systemsFactory;
		private readonly GameContext _gameContext;
		private readonly InputContext _inputContext;

		public BattleLoopState(ISystemsFactory systemsFactory, GameContext gameContext, InputContext inputContext)
		{
			_systemsFactory = systemsFactory;
			_gameContext = gameContext;
			_inputContext = inputContext;
		}

		public override void Enter()
		{
			_battleFeature = _systemsFactory.Create<BattleFeature>();
			_battleFeature.Initialize();
		}

		protected override void OnUpdate()
		{
			_battleFeature.Execute();
			_battleFeature.Cleanup();
		}

		protected override void ExitOnEndOfFrame()
		{
			_battleFeature.DeactivateReactiveSystems();
			_battleFeature.ClearReactiveSystems();

			DestructEntities();

			_battleFeature.Cleanup();
			_battleFeature.TearDown();
			_battleFeature = null;
		}

		private void DestructEntities()
		{
			foreach (GameEntity entity in _gameContext.GetEntities())
				entity.isDestructed = true;

			foreach (InputEntity entity in _inputContext.GetEntities())
				entity.isDestructed = true;
		}
	}
}