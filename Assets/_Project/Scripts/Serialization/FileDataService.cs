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
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace ObstacleCourse.Serialization
{
	public sealed class FileDataService : IDataService
	{
		private readonly string _dataPath;
		private readonly string _fileExtension;
		private readonly ISerializer _serializer;

		public FileDataService(ISerializer serializer)
		{
			_dataPath      = Application.persistentDataPath;
			_fileExtension = "json";
			_serializer    = serializer ?? throw new ArgumentNullException(nameof(serializer));
		}


		public void Save(BaseJsonSaveData data, bool overwrite = true)
		{
			try
			{
				string fileLocation = this.GetPathToFile(data.NameOfFile);
				if (!overwrite && File.Exists(fileLocation))
				{
					throw new IOException($"The file '{data.NameOfFile}.{_fileExtension}' already exists and cannot be overwritten.");
				}

				string serializedData = _serializer.Serialize(data);
				if (!string.IsNullOrEmpty(serializedData))
				{
					File.WriteAllText(fileLocation, serializedData);
				}
			}
			catch (Exception ex)
			{
				Debug.LogError($"The file '{data.NameOfFile}.{_fileExtension}' already exists and cannot be overwritten: {ex.Message}");
				throw;
			}
		}

		public T Load<T>(string fileName)
		{
			try
			{
				string fileLocation = this.GetPathToFile(fileName);
				if (!File.Exists(fileLocation))
				{
					throw new ArgumentException($"No save data file with name '{fileName}' was found.'");
				}

				string serializedData = File.ReadAllText(fileLocation);
				return _serializer.Deserialize<T>(serializedData);
			}
			catch (Exception ex)
			{
				Debug.LogError($"No save data file with name '{fileName}' was found: {ex.Message}");
				throw;
			}
		}

		public void Delete(string name)
		{
			string fileLocation = this.GetPathToFile(name);

			if (File.Exists(fileLocation))
			{
				File.Delete(fileLocation);
			}
		}

		/// <summary>
		///     <b>NOTE:</b> Be careful with using this method. Double-check and make sure to see what else is being stored in the specified path before using this method.
		/// </summary>
		public void DeleteAll()
		{
			// Be careful with using this function. Ensure you know what's being stored here; add some validation checks if necessary.
			foreach (string filePath in Directory.GetFiles(_dataPath))
			{
				File.Delete(filePath);
			}
		}

		public IEnumerable<string> ListSaveFiles()
		{
			foreach (string path in Directory.EnumerateFiles(_dataPath))
			{
				if (Path.GetExtension(path).Equals(_fileExtension))
				{
					yield return Path.GetFileNameWithoutExtension(path);
				}
			}
		}

		private string GetPathToFile(string fileName)
		{
			return Path.Combine(_dataPath, $"{fileName}.{_fileExtension}");
		}
	}
}