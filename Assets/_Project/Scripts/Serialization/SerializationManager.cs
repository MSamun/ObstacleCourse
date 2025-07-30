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

using ObstacleCourse.Utils;

namespace ObstacleCourse.Serialization
{
	public class SerializationManager : PersistentSingleton<SerializationManager>
	{
		private static IDataService _dataService;

		protected override void Awake()
		{
			base.Awake();
			_dataService = new FileDataService(new JsonSerializer());
		}

		public void SaveData(BaseJsonSaveData data, bool shouldOverwrite = true)
		{
			_dataService.Save(data, shouldOverwrite);
		}

		public T LoadDataFromFile<T>(string fileName)
		{
			return _dataService.Load<T>(fileName);
		}

		public void DeleteData(string fileName)
		{
			_dataService.Delete(fileName);
		}
	}
}