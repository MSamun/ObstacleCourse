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

namespace ObstacleCourse.Serialization
{
	public interface ISerializer
	{
		string Serialize<T>(T obj);
		T Deserialize<T>(string json);
	}
}