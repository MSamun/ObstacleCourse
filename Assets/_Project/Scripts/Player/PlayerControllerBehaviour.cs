/*
 This file is part of the Obstacle Course distribution (https://github.com/MSamun/ObstacleCourse)
 Copyright (C) 2025 Matthew Samun.

 This program is free software: you can redistribute it and/or modify it
 under the terms of the GNU General Public License as published by the Free
 Software Foundation, version 3.

 This program is distributed in the hope that it will be useful, but WITHOUT
 ANY WARRANTY; without even the implied warranty of  MERCHANTABILITY or
 FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for
 more details.

 You should have received a copy of the GNU General Public License along with
 this program. If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using ObstacleCourse.ScriptableObjects.Utils;
using ObstacleCourse.Utils;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ObstacleCourse.Player
{
	[RequireComponent(typeof(CharacterController))]
	public sealed class PlayerControllerBehaviour : MonoBehaviourReference
	{
		[SerializeField]
		private FloatValueSo MovementSpeedSo;

		private CharacterController _characterController;
		private Vector2 _moveInput;
		private Vector3 _velocity;

		private const float _DEFAULT_MOVEMENT_SPEED = 4f;

		private void Start()
		{
			_characterController = this.GetComponent<CharacterController>();
		}

		private void FixedUpdate()
		{
			this.ApplyMovement();
		}

		private void ApplyMovement()
		{
			// Convert 2D input into 3D world direction relative to player orientation
			Vector3 movementDirection = new(_moveInput.x, 0, _moveInput.y);
			movementDirection = this.transform.TransformDirection(movementDirection) * (MovementSpeedSo?.Value ?? _DEFAULT_MOVEMENT_SPEED);

			_characterController.Move(movementDirection * Time.fixedDeltaTime);
		}

		// Referenced externally by the new Input System.
		public void OnMove(InputAction.CallbackContext context)
		{
			_moveInput = context.ReadValue<Vector2>();
			Debug.Log($"Move Input: {_moveInput}");
		}
	}
}