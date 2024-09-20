using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(ObjectManager))]
public class MapSettingEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        ObjectManager manager = (ObjectManager)target;

        if (GUILayout.Button("맵 에딧 모드"))
        {
            manager.IsEditMode = true;
            manager.SortObjects();
        }
    }
}
#endif
