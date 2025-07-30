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
 * Video Title: Better Singletons in Unity C#
 * Author: git-amend
 * Date of Video: 01/14/24
 * Link: https://www.youtube.com/watch?v=LFOXge7Ak3E
 * ----------------------------------------------------------------------------
 */

using UnityEngine;
// using Sirenix.OdinInspector;

namespace ObstacleCourse.Utils
{
    public class PersistentSingleton<T> : MonoBehaviourReference where T : Component
    {
        // [FoldoutGroup("Inherited Information (Persistent Singleton)", false)]
        [Tooltip("if this is true, this singleton will auto detach if it finds itself parented on awake")]
        public bool UnParentOnAwake = true;

        public static bool HasInstance => Current != null;
        private static T Current { get; set; }

        public static T Instance
        {
            get
            {
                if (Current != null)
                {
                    return Current;
                }

                Current = FindFirstObjectByType<T>();
                if (Current != null)
                {
                    return Current;
                }

                GameObject obj = new()
                {
                    name = typeof(T).Name + " [Auto-Generated]"
                };

                Current = obj.AddComponent<T>();
                return Current;
            }
        }

        protected virtual void Awake() { this.InitializeSingleton(); }

        protected virtual void InitializeSingleton()
        {
            if (!Application.isPlaying)
            {
                return;
            }

            if (UnParentOnAwake)
            {
                this.transform.SetParent(null);
            }

            if (Current == null)
            {
                Current = this as T;
                DontDestroyOnLoad(this.transform.gameObject);
                this.enabled = true;
            }
            else
            {
                if (this != Current)
                {
                    Destroy(this.gameObject);
                }
            }
        }
    }
}