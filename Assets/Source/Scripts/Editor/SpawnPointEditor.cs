using UnityEditor;
using UnityEngine;

namespace Assets.Source.Scripts.Editor
{
    [CustomEditor(typeof(SpawnPoint))]
    public class SpawnPointEditor : UnityEditor.Editor
    {
        [DrawGizmo(GizmoType.NonSelected | GizmoType.Active | GizmoType.Pickable)]
        public static void RenderCustomGizmo(SpawnPoint spawnPoint, GizmoType gizmoType)
        {
            CircleGizmo(spawnPoint.transform, 0.5f, Color.red);
        }

        private static void CircleGizmo(Transform transform, float radius, Color color)
        {
            Gizmos.color = color;
            Vector3 pos = transform.position;
            Gizmos.DrawSphere(pos, radius);
        }
    }
}