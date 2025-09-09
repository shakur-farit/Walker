namespace Code.Gameplay.Features.Level.Factory
{
	public interface ILevelFactory
	{
		GameEntity CreateLevel(int level);
	}
}