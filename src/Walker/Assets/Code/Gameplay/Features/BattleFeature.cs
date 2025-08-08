using Code.Common;
using Code.Gameplay.Features.CharacterStats;
using Code.Gameplay.Features.Cooldowns;
using Code.Gameplay.Features.EffectApplication;
using Code.Gameplay.Features.Effects;
using Code.Gameplay.Features.Enemy;
using Code.Gameplay.Features.Hero;
using Code.Gameplay.Features.Level;
using Code.Gameplay.Features.Lifetime;
using Code.Gameplay.Features.Movement;
using Code.Gameplay.Features.TargetCollection;
using Code.Gameplay.Input;
using Code.Infrastructure.Systems;
using Code.Infrastructure.View;

namespace Code.Gameplay.Features
{
	public sealed class BattleFeature : Feature
	{
		public BattleFeature(ISystemsFactory systems)
		{
			Add(systems.Create<InputFeature>());
			Add(systems.Create<BindViewFeature>());

			Add(systems.Create<LevelFeature>());

			Add(systems.Create<CollectTargetsFeature>());

			Add(systems.Create<HeroFeature>());
			Add(systems.Create<EnemyFeature>());
			Add(systems.Create<AmmoFeature>());
			Add(systems.Create<DeathFeature>());

			Add(systems.Create<MovementFeature>());

			Add(systems.Create<EffectApplicationFeature>());

			Add(systems.Create<EffectsFeature>());
			Add(systems.Create<StatsFeature>());

			Add(systems.Create<CooldownFeature>());

			Add(systems.Create<ProcessGameDestructedFeature>());
			Add(systems.Create<ProcessInputDestructedFeature>());
		}
	}
}