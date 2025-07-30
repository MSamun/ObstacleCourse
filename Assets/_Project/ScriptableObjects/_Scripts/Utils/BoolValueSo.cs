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
	[CreateAssetMenu(fileName = "New Boolean Value", menuName = "Variables/Boolean")]
	public class BoolValueSo : ScriptableObjectReference
	{
		/// <summary>
		///     The current value stored in the Scriptable Object. A read-only value. Any modifications to this value should be done through the provided function.
		/// </summary>
		[field: SerializeField]
		public bool Value { get; private set; }

		/// <summary>
		///     Sets the current value to the specified boolean value.
		///		<example>
		///			<code>
		///				BoolValueSO myBoolValue = ...; //Initialize how you need to.
		///				myBoolValue.SetTo(true);
		///			</code>
		///		</example>
		/// </summary>
		/// <param name="value">The new boolean value to set.</param>
		public void SetTo(bool value)
		{
			this.Value = value;
		}
	}
}