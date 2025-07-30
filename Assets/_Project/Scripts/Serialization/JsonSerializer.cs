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
 * Video Title: Better Save/Load using Data Binding in Unity
 * Author: git-amend
 * Date of Video: 02/25/24
 * Link: https://www.youtube.com/watch?v=z1sMhGIgfoo
 * ----------------------------------------------------------------------------
 */

using System;
using Newtonsoft.Json;
using UnityEngine;

namespace ObstacleCourse.Serialization
{
	public sealed class JsonSerializer : ISerializer
	{
		// private static readonly KnownMinigameSettingsTypesBinder _knownMinigameSettingsTypesBinder = new()
		// {
		// 	KnownTypes = new List<Type> { typeof(FinalCountdownSettings), typeof(RogueRouletteSettings) }
		// };
		//
		// private readonly JsonSerializerSettings _newtonJsonSerializerSettings = new()
		// {
		// 	TypeNameHandling    = TypeNameHandling.Auto,
		// 	SerializationBinder = _knownMinigameSettingsTypesBinder
		// };
		//
		// // This is custom Newtonsoft JSON Serialization Binder to help deserialize the contents of abstract classes.
		// private class KnownMinigameSettingsTypesBinder : ISerializationBinder
		// {
		// 	public IList<Type> KnownTypes { get; set; }
		//
		// 	public Type BindToType(string assemblyName, string typeName)
		// 	{
		// 		return this.KnownTypes.SingleOrDefault(t => t.Name == typeName) ?? throw new InvalidOperationException();
		// 	}
		//
		// 	public void BindToName(Type serializedType, out string assemblyName, out string typeName)
		// 	{
		// 		assemblyName = null;
		// 		typeName     = serializedType.Name;
		// 	}
		// }

		public string Serialize<T>(T obj)
		{
			try
			{
				// return JsonConvert.SerializeObject(obj, Formatting.Indented, _newtonJsonSerializerSettings);
				return JsonConvert.SerializeObject(obj, Formatting.Indented);
				// return JsonUtility.ToJson(obj, true);
			}
			catch (Exception ex)
			{
				Debug.LogError($"Unable to serialize to JSON: {ex.Message}");
				return null;
			}
		}

		public T Deserialize<T>(string json)
		{
			try
			{
				// return JsonConvert.DeserializeObject<T>(json, _newtonJsonSerializerSettings);
				return JsonConvert.DeserializeObject<T>(json);
				// return JsonUtility.FromJson<T>(json);
			}
			catch (Exception ex)
			{
				Debug.LogError($"ERROR: {ex.Message}");
				return default;
			}
		}
	}
}