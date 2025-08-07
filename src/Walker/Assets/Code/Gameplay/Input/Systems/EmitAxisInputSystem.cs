using Code.Gameplay.Input.Service;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Input.Systems
{
	public class EmitAxisInputSystem : IExecuteSystem
	{
		private readonly IInputService _inputService;
		private readonly IGroup<InputEntity> _inputs;

		public EmitAxisInputSystem(InputContext input, IInputService inputService)
		{
			_inputService = inputService;
			_inputs = input.GetGroup(InputMatcher
				.AllOf(
					InputMatcher.Input));
		}

		public void Execute()
		{
			foreach (InputEntity input in _inputs)
			{
				if (_inputService.HasAxisInput())
					input.ReplaceAxisInput(new Vector2(_inputService.GetHorizontalAxis(), _inputService.GetVerticalAxis()));
				else if(input.hasAxisInput)
					input.RemoveAxisInput();
			}
		}
	}
}