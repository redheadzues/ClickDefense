using Assets.Source.Scripts.BehaviourTreeAI;
using Assets.Source.Scripts.BehaviourTreeAI.Editor;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.Callbacks;

public class BehaviuorTreeEditor : EditorWindow
{
    BehaviourTreeView treeView;
    InspectorView inspectorVew;

    [MenuItem("BehaviuorTreeEditor/Editor")]

    public static void OpenWindow()
    {
        BehaviuorTreeEditor wnd = GetWindow<BehaviuorTreeEditor>();
        wnd.titleContent = new GUIContent("BehaviuorTreeEditor");
    }

    [OnOpenAsset]
    public static bool OnOpenAssets(int instanceId, int line)
    {
        if(Selection.activeObject is BehaviourTree)
        {
            OpenWindow();
            return true;
        }

        return false;
    }

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // Import UXML
        VisualTreeAsset visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Source/Scripts/BehaviourTreeAI/Editor/BehaviuorTreeEditor.uxml");
        visualTree.CloneTree(root);


        // A stylesheet can be added to a VisualElement.
        // The style will be applied to the VisualElement and all of its children.
        StyleSheet styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Source/Scripts/BehaviourTreeAI/Editor/BehaviuorTreeEditor.uss");
        root.styleSheets.Add(styleSheet);

        treeView = root.Q<BehaviourTreeView>();
        inspectorVew = root.Q<InspectorView>();
        treeView.OnNodeSelected += OnNodeSelectionChanged;

        OnSelectionChange();
    }


    private void OnSelectionChange()
    {
        BehaviourTree tree = Selection.activeObject as BehaviourTree;

        if(tree && AssetDatabase.CanOpenAssetInEditor(tree.GetInstanceID()))
            treeView.FillView(tree);
    }

    private void OnNodeSelectionChanged(NodeView nodeView) =>
        inspectorVew.UpdateSelection(nodeView);
    
}