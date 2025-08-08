using Code.Meta.Features.Hud.CoinsHolder.Behaviours;
using Code.Meta.Features.Hud.HeroHeartHolder.Behaviours;
using Entitas;

namespace Code.Meta.Features.Hud
{
	[Game] public class CoinsHolderComponent : IComponent { public CoinsHolderBehaviour Value; }
	[Game] public class HeartHolderComponent : IComponent { public HeartHolder Value; }
}