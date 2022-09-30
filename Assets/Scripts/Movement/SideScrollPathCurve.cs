using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class SideScrollPathCurve : MonoBehaviour
    {
        [SerializeField] int iterations = 20;
        float step = 0.05f;

        int order;

        // Only first 4 points are taken into account
        //   (start of next curve is passed in)
        [SerializeField] Transform[] curveAnchors;

        [field: SerializeField] public Vector3[] CurvePositions { get; private set; }

        Vector3[] ab;
        Vector3[] bc;
        Vector3[] cd;
        Vector3[] de;

        Vector3[] ab_bc;
        Vector3[] bc_cd;
        Vector3[] cd_de;

        Vector3[] abbc_bccd;
        Vector3[] bccd_cdde;

        public Transform FirstPoint
        {
            get
            {
                if (curveAnchors.Length > 0) return curveAnchors[0];

                return null;
            }
        }

        private void Awake()
        {
            step = 1f / iterations;

            var cas = GetComponentsInChildren<Transform>();
            curveAnchors = new Transform[cas.Length - 1];
            for (int i = 0; i < curveAnchors.Length; i++)
                curveAnchors[i] = cas[i + 1];

            order = curveAnchors.Length;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;

            foreach (var anchor in curveAnchors)
                Gizmos.DrawWireSphere(anchor.position, 0.5f);
        }

        public void CreateCurve(Transform nextCurve)
        {
            if (nextCurve == null) return;

            switch (order)
            {
                case 1:
                    LinearCurvePoint(curveAnchors[0], nextCurve);
                    break;
                case 2:
                    QuadraticCurvePoint(curveAnchors[0], curveAnchors[1], nextCurve);
                    break;
                case 3:
                    CubicCurvePoint(curveAnchors[0], curveAnchors[1], curveAnchors[2], nextCurve);
                    break;
                case 4:
                    QuarticCurvePoint(curveAnchors[0], curveAnchors[1], curveAnchors[2], 
                        curveAnchors[3], nextCurve);
                    break;
                default:
                    break;
            }
        }

        void LinearCurvePoint(Transform a, Transform b)
        {
            // No point lerping a linear line
            CurvePositions = new Vector3[] { a.position, b.position };
        }

        void QuadraticCurvePoint(Transform a, Transform b, Transform c)
        {
            ab = new Vector3[iterations];
            bc = new Vector3[iterations];

            CurvePositions = new Vector3[iterations];

            for (int n = 0; n < iterations; n++)
            {
                float t = step * n;

                ab[n] = Vector3.Lerp(a.position, b.position, t);
                bc[n] = Vector3.Lerp(b.position, c.position, t);

                CurvePositions[n] = Vector3.Lerp(ab[n], bc[n], t);
            }
        }

        void CubicCurvePoint(Transform a, Transform b, Transform c, Transform d)
        {
            ab = new Vector3[iterations];
            bc = new Vector3[iterations];
            cd = new Vector3[iterations];

            ab_bc = new Vector3[iterations];
            bc_cd = new Vector3[iterations];

            CurvePositions = new Vector3[iterations];

            for (int n = 0; n < iterations; n++)
            {
                float t = step * n;

                ab[n] = Vector3.Lerp(a.position, b.position, t);
                bc[n] = Vector3.Lerp(b.position, c.position, t);
                cd[n] = Vector3.Lerp(c.position, d.position, t);

                ab_bc[n] = Vector3.Lerp(ab[n], bc[n], t);
                bc_cd[n] = Vector3.Lerp(bc[n], cd[n], t);

                CurvePositions[n] = Vector3.Lerp(ab_bc[n], bc_cd[n], t);
            }
        }

        void QuarticCurvePoint(Transform a, Transform b, Transform c, Transform d, Transform e)
        {
            ab = new Vector3[iterations];
            bc = new Vector3[iterations];
            cd = new Vector3[iterations];
            de = new Vector3[iterations];

            ab_bc = new Vector3[iterations];
            bc_cd = new Vector3[iterations];
            cd_de = new Vector3[iterations];

            abbc_bccd = new Vector3[iterations];
            bccd_cdde = new Vector3[iterations];

            CurvePositions = new Vector3[iterations];

            for (int n = 0; n < iterations; n++)
            {
                float t = step * n;

                ab[n] = Vector3.Lerp(a.position, b.position, t);
                bc[n] = Vector3.Lerp(b.position, c.position, t);
                cd[n] = Vector3.Lerp(c.position, d.position, t);
                de[n] = Vector3.Lerp(d.position, e.position, t);

                ab_bc[n] = Vector3.Lerp(ab[n], bc[n], t);
                bc_cd[n] = Vector3.Lerp(bc[n], cd[n], t);
                cd_de[n] = Vector3.Lerp(cd[n], de[n], t);

                abbc_bccd[n] = Vector3.Lerp(ab_bc[n], bc_cd[n], t);
                bccd_cdde[n] = Vector3.Lerp(bc_cd[n], cd_de[n], t);

                CurvePositions[n] = Vector3.Lerp(abbc_bccd[n], bccd_cdde[n], t);
            }
        }
    }
}