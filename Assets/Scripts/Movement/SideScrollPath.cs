using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    [System.Serializable]
    public class PathPoint
    {
        [field: SerializeField] public Vector3 Pos { get; private set; }
        [field: SerializeField] public Vector3 Right { get; private set; }
        [field: SerializeField] public Vector3 Left { get; private set; }

        public PathPoint()
        {

        }

        public PathPoint(Vector3 pos, Vector3 right)
        {
            Pos = pos;
            Right = right;
        }

        public PathPoint(Vector3 pos, Vector3 right, Vector3 left)
        {
            Pos = pos;
            Right = right;
            Left = left;
        }
    }

    public class SideScrollPath : MonoBehaviour
    {
        [SerializeField] float step = 0.05f;

        [SerializeField] Transform[] waypoints;
        [SerializeField] List<PathPoint> path = new List<PathPoint>();

        private void Awake()
        {
            waypoints = GetComponentsInChildren<Transform>();
        }

        private void OnDrawGizmos()
        {
            
        }

        void BuildPath()
        {
            for(int i = 0; i < waypoints.Length - 1; i++)
            {
                var start = waypoints[i];
                var end = waypoints[i + 1];

                var t = 0f;

                while (t < 1)
                {
                    path.Add(new PathPoint());
                    t += step;
                }
            }
        }
    }
}