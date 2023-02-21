using Assets.Source.Scripts.GameOver;
using UnityEditor;
using UnityEngine;

namespace Assets.Source.Scripts.Editor
{
    [CustomEditor(typeof(TargetPoint))]
    public class TargetPointEditor : UnityEditor.Editor
    {
        [DrawGizmo(GizmoType.NonSelected | GizmoType.Active | GizmoType.Pickable)]
        public static void RenderCustomGizmo(TargetPoint targetPoint, GizmoType gizmoType)
        {
            BoxGizmo(targetPoint.transform, Color.green);
        }

        private static void BoxGizmo(Transform transform, Color color)
        {
            Vector3 size = transform.gameObject.GetComponent<BoxCollider>().size;
            Gizmos.color = color;
            Vector3 pos = transform.position;
            Gizmos.DrawCube(pos, size);
        }
    }
}
