using Assets.Source.Scripts.AbilitiesSystem.StaticData;
using Assets.Source.Scripts.AbilitiesSystem.Tree;
using UnityEditor;
using UnityEngine;

namespace Assets.Source.Scripts.Editor
{
    [CustomEditor(typeof(Branch))]
    public class BranchEditor : UnityEditor.Editor
    {
        Vector2 leafSize = new Vector2(150, 150);
        float minWindowHeight = 720f;
        float minwindowWidth = 1000f;
        Vector2 incomingEdgePoint = new Vector2 (100f, 10f);
        Vector2 outgoingEdgePoint = new Vector2(-12f, 10f);
        Vector2 upArrowVec = new Vector2(-5f, -5f);
        Vector2 downArrowVec = new Vector2(-5f, 5f);
        Vector2 nextLineVec = new Vector2(0, 20f);
        Vector2 indentVec = new Vector2(102f, 0);
        Vector2 leafContentSize = new Vector2(40f, 20f);
        Vector2 leafLabelSize = new Vector2(100f, 20f);

        Vector2 mouseSelectionOffset;
        Vector2 scrollPosition = Vector2.zero;
        Vector2 scrollStartPosition;

        Leaf activeLeaf;
        Leaf selectedLeaf;
        Event _currentEvent;
        EventType _uiEvent;

        
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            Branch branch = (Branch)target;

            _currentEvent = Event.current;
            int controlId = GUIUtility.GetControlID(FocusType.Passive);
            _uiEvent = _currentEvent.GetTypeForControl(controlId);

           
            EditorGUILayout.BeginScrollView(Vector2.zero, GUILayout.MinHeight(720));

            for(int leafIndex = 0; leafIndex < branch.Leafs.Count; leafIndex++)
            {
                Leaf currentLeaf = branch.Leafs[leafIndex];

                Rect leafRect = new Rect(currentLeaf.UIPosition - scrollPosition, leafSize);

                DrawLeaf(currentLeaf, leafRect, branch);
                DrawConnectionLines(branch, currentLeaf, leafRect);
                HandleConnectionAttempt(branch, leafIndex, currentLeaf, leafRect);
            }

            if (_currentEvent.button == 2)
            {
                if(_currentEvent.type == EventType.MouseDown)
                    scrollStartPosition = (_currentEvent.mousePosition + scrollPosition);
                else if(_currentEvent.type == EventType.MouseDrag)
                {
                    scrollPosition = -(_currentEvent.mousePosition - scrollStartPosition);
                    Repaint();
                }
            }

            if (selectedLeaf != null && _currentEvent.button == 1)
            {
                Handles.DrawBezier(_currentEvent.mousePosition,
                    selectedLeaf.UIPosition - scrollPosition + incomingEdgePoint,
                    _currentEvent.mousePosition + Vector2.left * 100f,
                    selectedLeaf.UIPosition - scrollPosition + incomingEdgePoint + Vector2.right * 100f,
                    Color.white,
                    null,
                    1.5f);

                Repaint();
            }

            if(_uiEvent == EventType.MouseUp)
            {
                activeLeaf = null;
            }
            else if(_uiEvent == EventType.MouseDrag)
            {
                if (activeLeaf != null)
                    activeLeaf.UIPosition = _currentEvent.mousePosition + mouseSelectionOffset;
            }

            if(_currentEvent.type == EventType.DragUpdated)
            {
                DragAndDrop.visualMode = DragAndDropVisualMode.Copy;
            }
            else if(_currentEvent.type == EventType.DragPerform)
            {
                for(int i = 0; i < DragAndDrop.objectReferences.Length; i++)
                {
                    if (DragAndDrop.objectReferences[i] is AbilityStaticData data)
                        branch.AddLeaf(data, _currentEvent.mousePosition + scrollPosition);
                }
            }

            EditorGUILayout.EndScrollView();

            EditorUtility.SetDirty(branch);

        }

        private void HandleConnectionAttempt(Branch branch,  int leafIndex, Leaf currentLeaf, Rect leafRect)
        {
            if (leafRect.Contains(_currentEvent.mousePosition))
            {
                if (_uiEvent == EventType.MouseDown)
                {
                    if (_currentEvent.button == 0)
                    {
                        activeLeaf = currentLeaf;
                        mouseSelectionOffset = activeLeaf.UIPosition - _currentEvent.mousePosition;
                    }

                    if (_currentEvent.button == 1)
                    {
                        selectedLeaf = currentLeaf;
                        Repaint();
                    }
                }

                if (_uiEvent == EventType.MouseUp)
                {
                    if (_currentEvent.button == 1 && selectedLeaf != null && selectedLeaf != currentLeaf)
                    {
                        if (currentLeaf.Requirements.Contains(selectedLeaf.AbilityData))
                            currentLeaf.Requirements.Remove(selectedLeaf.AbilityData);
                        else if (selectedLeaf.Requirements.Contains(currentLeaf.AbilityData))
                            selectedLeaf.Requirements.Remove(currentLeaf.AbilityData);

                        if (branch.IsConnectible(branch.Leafs.IndexOf(selectedLeaf), leafIndex))
                        {
                            currentLeaf.Requirements.Add(selectedLeaf.AbilityData);

                            for (int i = 0; i < branch.Leafs.Count; i++)
                                branch.CorrectRequirementCascade(i);
                        }

                    }
                }
            }
        }

        private void DrawConnectionLines(Branch branch, Leaf currentLeaf, Rect leafRect)
        {
            foreach (AbilityStaticData requiredData in currentLeaf.Requirements)
            {
                int requiredIndex = branch.FindLeafIndex(requiredData);

                if (requiredIndex != -1)
                {
                    Leaf requiredLeaf = branch.Leafs[requiredIndex];

                    Handles.DrawBezier(currentLeaf.UIPosition + outgoingEdgePoint - scrollPosition,
                        requiredLeaf.UIPosition - scrollPosition + new Vector2(leafSize.x, 0),
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
        }

        private void DrawLeaf(Leaf currentLeaf, Rect leafRect, Branch branch)
        {

            GUIStyle standartStyle = new GUIStyle(EditorStyles.helpBox);
            GUIStyle selectedStyle = new GUIStyle(EditorStyles.helpBox);
            selectedStyle.fontStyle = FontStyle.BoldAndItalic;
            selectedStyle.alignment = TextAnchor.UpperCenter;
            standartStyle.alignment = TextAnchor.UpperCenter;
            selectedStyle.normal.background = (Texture2D)Resources.Load("GridCell");
            


            GUIStyle labelStyle = new GUIStyle();
            labelStyle.alignment = TextAnchor.UpperCenter;

            Rect iconRect = new Rect(currentLeaf.UIPosition - Vector2.down * 20 + Vector2.right * leafSize.x / 4 - scrollPosition, leafSize / 2);
            Rect descriptionRect = new Rect(new Vector2(leafRect.xMin, iconRect.yMax), new Vector2(leafSize.x, leafSize.y - iconRect.height));


            EditorGUI.BeginFoldoutHeaderGroup(leafRect, true, currentLeaf.AbilityData.Name, (selectedLeaf == currentLeaf ? selectedStyle : standartStyle));
            EditorGUI.DrawPreviewTexture(iconRect, currentLeaf.AbilityData.Icon.texture, null, ScaleMode.StretchToFill, 1);
            EditorGUI.LabelField(descriptionRect, currentLeaf.AbilityData.Description, labelStyle);
            EditorGUI.EndFoldoutHeaderGroup();

            GUIContent asd = new GUIContent("Delete", (Texture2D)Resources.Load("GridCell"));

            Rect buttonRect = new Rect(new Vector2(leafRect.x, leafRect.yMax), new Vector2(leafSize.x, 20));
            if(EditorGUI.LinkButton(buttonRect, asd))
            {


                branch.RemoveLeaf(selectedLeaf.AbilityData);

                if (activeLeaf == selectedLeaf)
                    activeLeaf = null;

                selectedLeaf = null;
            }
        }
    }
}
