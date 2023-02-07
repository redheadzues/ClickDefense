using Assets.Source.Scripts.AbilitiesSystem.StaticData;
using Assets.Source.Scripts.AbilitiesSystem.Tree;
using UnityEditor;
using UnityEngine;

namespace Assets.Source.Scripts.Editor
{
    [CustomEditor(typeof(Branch))]
    public class BranchEditor : UnityEditor.Editor
    {
        Vector2 leafSize = new Vector2(100f, 70f);
        float minWindowHeight = 720f;
        float minwindowWidth = 1000f;
        Vector2 incomingEdgePoint = new Vector2 (100f, 10f);
        Vector2 outgoingEdgePoint = new Vector2(-12f, 10f);
        Vector2 upArrowVec = new Vector2(-10f, -10f);
        Vector2 downArrowVec = new Vector2(-10f, 10f);
        Vector2 nextLineVec = new Vector2(0, 20f);
        Vector2 indentVec = new Vector2(102f, 0);
        Vector2 leafContentSize = new Vector2(40f, 20f);
        Vector2 leafLabelSize = new Vector2(100f, 20f);

        Vector2 mouseSelectionOffset;
        Vector2 scrollPosition = Vector2.zero;
        Vector2 scrollStartPosition;

        Leaf activeLeaf;
        Leaf selectedLeaf;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            Branch branch = (Branch)target;

            Event currentEvent = Event.current;
            int controlId = GUIUtility.GetControlID(FocusType.Passive);
            EventType UIEvent = currentEvent.GetTypeForControl(controlId);

            GUIStyle standartStyle = new GUIStyle(EditorStyles.helpBox);
            GUIStyle selectedStyle = new GUIStyle(EditorStyles.helpBox);
            selectedStyle.fontStyle = FontStyle.BoldAndItalic;
            
            EditorGUILayout.BeginScrollView(Vector2.zero, GUILayout.MinHeight(720));

            for(int leafIndex = 0; leafIndex < branch.Leafs.Count; leafIndex++)
            {
                Leaf currentLeaf = branch.Leafs[leafIndex];

                Rect leafRect = new Rect(currentLeaf.UIPosition - scrollPosition, leafSize);
                EditorGUI.BeginFoldoutHeaderGroup(leafRect, true, currentLeaf.AbilityData.Name,(selectedLeaf == currentLeaf ? selectedStyle : standartStyle));
                EditorGUI.EndFoldoutHeaderGroup();


                foreach (AbilityStaticData requiredData in currentLeaf.Requirements)
                {
                    int requiredIndex = branch.FindLeafIndex(requiredData);

                    if (requiredIndex == -1)
                    {
                        Leaf requiredLeaf = branch.Leafs[requiredIndex];

                        Handles.DrawBezier(currentLeaf.UIPosition - scrollPosition + outgoingEdgePoint,
                            requiredLeaf.UIPosition - scrollPosition + incomingEdgePoint,
                            currentLeaf.UIPosition - scrollPosition + outgoingEdgePoint + Vector2.left * 100f,
                            requiredLeaf.UIPosition - scrollPosition + incomingEdgePoint + Vector2.right * 100f,
                            Color.green,
                            null,
                            3f);

                        Vector2 arrowPoint = currentLeaf.UIPosition - scrollPosition + outgoingEdgePoint;

                        Handles.DrawLine(arrowPoint, arrowPoint + upArrowVec);
                        Handles.DrawLine(arrowPoint, arrowPoint + downArrowVec);
                    }
                    else
                        Debug.LogWarning("missing leaf" + currentLeaf.AbilityData.name);
                }

                if(leafRect.Contains(currentEvent.mousePosition))
                {
                    if(UIEvent == EventType.MouseDown)
                    {
                        if(currentEvent.button == 0)
                        {
                            activeLeaf = currentLeaf;
                            mouseSelectionOffset = activeLeaf.UIPosition - currentEvent.mousePosition;
                        }

                        if(currentEvent.button == 1)
                        {
                            selectedLeaf = currentLeaf;
                            Repaint();
                        }
                    }

                    if(UIEvent == EventType.MouseUp)
                    {
                        if(currentEvent.button == 1 && selectedLeaf != null && selectedLeaf != currentLeaf)
                        {
                            if(currentLeaf.Requirements.Contains(selectedLeaf.AbilityData))
                                currentLeaf.Requirements.Remove(selectedLeaf.AbilityData);
                            else if(selectedLeaf.Requirements.Contains(currentLeaf.AbilityData))
                                selectedLeaf.Requirements.Remove(currentLeaf.AbilityData);

                            if(branch.IsConnectible(branch.Leafs.IndexOf(selectedLeaf), leafIndex))
                            {
                                currentLeaf.Requirements.Add(selectedLeaf.AbilityData);

                                for (int i = 0; i < branch.Leafs.Count; i++)
                                    branch.CorrectRequirementCascade(i);
                            }

                        }
                    }
                }
            }

            if(currentEvent.button == 2)
            {
                if(currentEvent.type == EventType.MouseDown)
                    scrollStartPosition = (currentEvent.mousePosition + scrollPosition);
                else if(currentEvent.type == EventType.MouseDrag)
                {
                    scrollPosition = -(currentEvent.mousePosition - scrollStartPosition);
                    Repaint();
                }
            }

            if (selectedLeaf != null && currentEvent.button == 1)
            {
                Handles.DrawBezier(currentEvent.mousePosition,
                    selectedLeaf.UIPosition - scrollPosition + incomingEdgePoint,
                    currentEvent.mousePosition + Vector2.left * 100f,
                    selectedLeaf.UIPosition - scrollPosition + incomingEdgePoint + Vector2.right * 100f,
                    Color.white,
                    null,
                    1.5f);


                Repaint();
            }

            if(UIEvent == EventType.MouseUp)
            {
                activeLeaf = null;
            }
            else if(UIEvent == EventType.MouseDrag)
            {
                if (activeLeaf != null)
                    activeLeaf.UIPosition = currentEvent.mousePosition + mouseSelectionOffset;
            }

            if(currentEvent.type == EventType.DragUpdated)
            {
                DragAndDrop.visualMode = DragAndDropVisualMode.Copy;
            }
            else if(currentEvent.type == EventType.DragPerform)
            {
                for(int i = 0; i < DragAndDrop.objectReferences.Length; i++)
                {
                    if (DragAndDrop.objectReferences[i] is AbilityStaticData data)
                        branch.AddLeaf(data, currentEvent.mousePosition + scrollPosition);
                }
            }

            EditorGUILayout.EndScrollView();

            EditorUtility.SetDirty(branch);

        }
    }
}
