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
 * Video Title: Unite 2017 – Game Architecture with Scriptable Objects
 * Author: Ryan Hipple
 * Date of Video: 10/04/17
 * Link: https://www.youtube.com/watch?v=raQ3iHhE_Kk
 * ----------------------------------------------------------------------------
 */

using ObstacleCourse.ScriptableObjects.Utils;
using UnityEngine;
using UnityEngine.Events;
// using Sirenix.OdinInspector;

namespace ObstacleCourse.Utils
{
    public sealed class GameEventListener : MonoBehaviourReference
    {
        // [Title("Game Events To Look Out For")]
        [Header("Game Events To Look Out For")]
        [SerializeField]
        // [LabelWidth(145)]
        // [LabelText("Game Events SO")]
        private GameEventSo[] Events;

        // [Title("What Happens When Event Is Invoked")]
        [Header("What Happens When Event Is Invoked")]
        [SerializeField]
        // [LabelText("Game Events")]
        private UnityEvent Response;

        private void OnEnable()
        {
            for (int i = Events.Length - 1; i >= 0; i--)
            {
                Events[i].RegisterListener(this.OnEventRaised);
            }
        }

        private void OnDisable()
        {
            for (int i = Events.Length - 1; i >= 0; i--)
            {
                Events[i].UnRegisterListener(this.OnEventRaised);
            }
        }

        private void OnEventRaised() { Response.Invoke(); }
    }
}