using Drop.Factory;
using UnityEngine;

namespace Drop
{
	public class DropDeath : IDropDeath
	{
		private readonly IDropFactory _dropFactory;

		public DropDeath(IDropFactory dropFactory) =>
			_dropFactory = dropFactory;

		public void Die(GameObject gameObject) =>
			_dropFactory.Destroy(gameObject);
	}
}