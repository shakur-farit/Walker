namespace Infrastructure.States.Factory
{
	public interface IStatesFactory
	{
		TState CreateGameStates<TState>() where TState : IGameState;
	}
}