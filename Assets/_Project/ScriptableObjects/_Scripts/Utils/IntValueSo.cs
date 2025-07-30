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
	[CreateAssetMenu(fileName = "New Integer Value", menuName = "Variables/Integer")]
	public class IntValueSo : ScriptableObjectReference
	{
		/// <summary>
		///     The current value stored in the Scriptable Object. A read-only value. Any modifications to this value should be done through the provided functions.
		/// </summary>
		[field: SerializeField]
		public int Value { get; private set; }

		/// <summary>
		///		Adds the specified <b>positive</b> integer to the current value. If the resulting value is less than zero, it resets to zero.
		///		<example>
		///			<code>
		///				IntValueSO myIntValue = ...; //Initialize how you need to.
		///				myIntValue.Add(3);
		///			</code>
		///		</example>
		/// </summary>
		/// <param name="value">The integer value to add. It must be greater than zero.</param>
		public void Add(int value)
		{
			if (value > 0)
			{
				this.ModifyValue(value);
			}
		}

		/// <summary>
		///     Subtracts the specified <b>positive</b> integer from the current value. If the resulting value is less than zero, it resets to zero.
		///		<example>
		///			<code>
		///				IntValueSO myIntValue = ...; //Initialize how you need to.
		///				myIntValue.Subtract(7);
		///			</code>
		///		</example>
		/// </summary>
		/// <param name="value">The integer value to subtract. It must be greater than zero.</param>
		public void Subtract(int value)
		{
			if (value > 0)
			{
				this.ModifyValue(-value);
			}
		}

		/// <summary>
		///     Sets the current value to the specified <b>positive</b> integer. If the new value is less than zero, it resets to zero.
		///		<example>
		///			<code>
		///				IntValueSO myIntValue = ...; //Initialize how you need to.
		///				myIntValue.SetValueTo(15);
		///			</code>
		///		</example>
		/// </summary>
		/// <param name="value">The new integer value to set. It must be greater than zero.</param>
		public void SetValueTo(int value)
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
		/// <param name="delta">The integer value to modify the current value by. It can be positive or negative.</param>
		private void ModifyValue(int delta)
		{
			this.Value += delta;
			if (this.Value < 0)
			{
				this.Value = 0;
			}
		}
	}
}