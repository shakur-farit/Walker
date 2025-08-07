using Zenject;

namespace Code.Meta.UI.Windows.Behaviours
{
	public class Hud : BaseWindow
	{
		[Inject]
		public void Constructor() => 
			Id = WindowId.Hud;

		protected override void Initialize()
		{
		}
	}
}