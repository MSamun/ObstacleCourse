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

// Note that the Newtonsoft JSON Unity Package is required for the serialization to work.
// Current Version: v13.0.2 (or showing in Unity Package Manager: version 3.2.1).

// To install Newtonsoft JSON: Package Manager -> Install package by name -> com.unity.nuget.newtonsoft-json

using Newtonsoft.Json;

namespace ObstacleCourse.Serialization
{
	[System.Serializable]
	public abstract class BaseJsonSaveData
	{
		[JsonIgnore] public string NameOfFile { get; protected set; }
	}

	// NOTE: JSON won't write private variables or properties to file. Keep all the variables public.
	public sealed class SettingsJsonData : BaseJsonSaveData
	{
		public float BackgroundVolumeGame = 0.15f;
		public float BackgroundVolumeGlobal;
		public float SFXVolumeGlobal;

		public SettingsJsonData(float backgroundVolumeGlobal = 1.0f, float sfxVolumeGlobal = 1.0f)
		{
			this.NameOfFile        = DataFileName.SettingsDataFileName;
			BackgroundVolumeGlobal = backgroundVolumeGlobal;
			SFXVolumeGlobal        = sfxVolumeGlobal;
		}
	}

	public static class DataFileName
	{
		public const string SettingsDataFileName = "RREMIDA-SettingsData";
	}
}