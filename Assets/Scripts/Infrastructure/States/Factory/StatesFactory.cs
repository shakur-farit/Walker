using Zenject;

namespace Infrastructure.States.Factory
{
	public class StatesFactory : IStatesFactory
	{
		private IInstantiator _instantiator;

		public StatesFactory(IInstantiator instantiator) =>
			_instantiator = instantiator;

		public TState CreateGameStates<TState>() where TState : IGameState =>
			_instantiator.Instantiate<TState>();
	}
}