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

using ObstacleCourse.Utils;
using UnityEngine;

// using Sirenix.OdinInspector;

namespace ObstacleCourse.ScriptableObjects.Utils
{
	[CreateAssetMenu(fileName = "New Audio Clip", menuName = "Game/Audio/Audio Clip")]
	public class AudioClipSo : ScriptableObjectReference
	{
		[SerializeField] 
		// [LabelWidth(145)]
		private AudioClip _audioClip;
		public AudioClip AudioClip => _audioClip;

		[SerializeField] 
		// [LabelWidth(145)] 
		private float _volume = 1f;
		public float Volume => _volume;
	}
}