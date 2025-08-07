using Code.Gameplay.Input.Service;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Input.Systems
{
	public class EmitLeftMouseButtonInputSystem : IExecuteSystem
	{
		private readonly IInputService _inputService;
		private readonly IGroup<InputEntity> _inputs;

		public EmitLeftMouseButtonInputSystem(InputContext input, IInputService inputService)
		{
			_inputService = inputService;
			_inputs = input.GetGroup(InputMatcher
				.AllOf(
					InputMatcher.Input));
		}

		public void Execute()
		{
			foreach (InputEntity input in _inputs) 
				input.isMouseLeftButtonDown = _inputService.GetLeftMouseButton();
		}
	}
}