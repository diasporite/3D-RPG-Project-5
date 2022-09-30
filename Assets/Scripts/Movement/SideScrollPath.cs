using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    [System.Serializable]
    public class PathPoint
    {
        [field: SerializeField] public Vector3 Pos { get; private set; }
        [field: SerializeField] public Vector3 ToNext { get; private set; }
        [field: SerializeField] public Vector3 ToPrevious { get; private set; }

        [field: SerializeField] public float DistNext { get; private set; }
        [field: SerializeField] public float DistLast { get; private set; }

        public PathPoint(Vector3 pos, Vector3 right, Vector3 left)
        {
            Pos = pos;

            ToNext = right;
            ToPrevious = left;

            DistNext = ToNext.magnitude;
            DistLast = ToPrevious.magnitude;
        }
    }

    public class SideScrollPath : MonoBehaviour
    {
        [SerializeField] SideScrollPathCurve[] curves;

        [SerializeField] List<PathPoint> path = new List<PathPoint>();

        List<Vector3> curvePositions = new List<Vector3>();

        private void Awake()
        {
            curves = GetComponentsInChildren<SideScrollPathCurve>();
        }

        private void Start()
        {
            BuildPath();
        }

        private void OnDrawGizmos()
        {
            foreach(var point in path)
                Gizmos.DrawWireSphere(point.Pos, 0.05f);
        }

        void BuildPath()
        {
            for (int i = 0; i < curves.Length - 1; i++)
            {
                curves[i].CreateCurve(curves[i + 1].FirstPoint);

                var cPos = curves[i].CurvePositions;

                for (int j = 0; j < cPos.Length; j++)
                {
                    var pos = cPos[j];

                    if (!curvePositions.Contains(pos))
                    {
                        curvePositions.Add(pos);

                        PathPoint point;

                        if (j <= 0)
                            point = new PathPoint(pos, cPos[j + 1] - pos, Vector3.zero);
                        else if (j >= cPos.Length - 1)
                            point = new PathPoint(pos, Vector3.zero, pos - cPos[j - 1]);
                        else point = new PathPoint(pos, cPos[j + 1] - pos, pos - cPos[j - 1]);

                        path.Add(point);
                    }
                }
            }
        }
    }
}