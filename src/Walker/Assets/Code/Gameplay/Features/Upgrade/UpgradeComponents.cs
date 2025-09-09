using Entitas;

namespace Code.Gameplay.Features.Hero
{
	[Game] public class UpgradeValue : IComponent { public float Value; }
	[Game] public class UpgradePrice : IComponent { public int Value; }
	[Game] public class UpgradeRequested : IComponent { }

	[Game] public class DamageUpgrade : IComponent { }
	[Game] public class HpUpgrade : IComponent { }
	[Game] public class CooldownUpgrade : IComponent { }
}