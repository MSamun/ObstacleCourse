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

/* ----------------------------------------------------------------------------
 * This script is credited to the following person(s) stated below:
 *
 * Video Title: Unite 2017 - Game Architecture with Scriptable Objects
 * Author: Ryan Hipple
 * Date of Video: 10/04/17
 * Link: https://www.youtube.com/watch?v=raQ3iHhE_Kk
 * ----------------------------------------------------------------------------
 */

using ObstacleCourse.Utils;
using UnityEngine;

namespace ObstacleCourse.ScriptableObjects.Utils
{
	[CreateAssetMenu(fileName = "New Float Value", menuName = "Variables/Float")]
	public class FloatValueSo : ScriptableObjectReference
	{
		/// <summary>
		///     The current value stored in the Scriptable Object. A read-only value. Any modifications to this value should be done through the provided functions.
		/// </summary>
		[field: SerializeField]
		public float Value { get; private set; }

		/// <summary>
		///     Adds the specified <b>positive</b> floating-point value to the current value. If the resulting value is less than zero, it resets to zero.
		///		<example>
		///			<code>
		///				FloatValueSO myFloatValue = ...; //Initialize how you need to.
		///				myFloatValue.Add(3.0f);
		///			</code>
		///		</example>
		/// </summary>
		/// <param name="value">The float value to add. It must be greater than zero.</param>
		public void Add(float value)
		{
			if (value > 0)
			{
				this.ModifyValue(value);
			}
		}

		/// <summary>
		///     Subtracts the specified <b>positive</b> floating-point value from the current value. If the resulting value is less than zero, it resets to zero.
		///		<example>
		///			<code>
		///				FloatValueSO myFloatValue = ...; //Initialize how you need to.
		///				myFloatValue.Subtract(7.3f);
		///			</code>
		///		</example>
		/// </summary>
		/// <param name="value">The float value to subtract. It must be greater than zero.</param>
		public void Subtract(float value)
		{
			if (value > 0)
			{
				this.ModifyValue(-value);
			}
		}

		/// <summary>
		///     Sets the current value to the specified <b>positive</b> floating-point value. If the new value is less than zero, it resets to zero.
		///		<example>
		///			<code>
		///				FloatValueSO myFloatValue = ...; //Initialize how you need to.
		///				myFloatValue.SetValueTo(15.1f);
		///			</code>
		///		</example>
		/// </summary>
		/// <param name="value">The new float value to set. It must be greater than zero.</param>
		public void SetValueTo(float value)
		{
			if (value >= 0)
			{
				this.Value = value;
			}

			if (this.Value < 0)
			{
				this.Value = 0;
			}
		}

		/// <summary>
		///     Modifies the current value by adding the specified delta. If the resulting value is less than zero, it resets to zero.
		/// </summary>
		/// <param name="delta">The float value to modify the current value by. It can be positive or negative.</param>
		private void ModifyValue(float delta = 0f)
		{
			this.Value += delta;
			if (this.Value < 0)
			{
				this.Value = 0;
			}
		}
	}
}