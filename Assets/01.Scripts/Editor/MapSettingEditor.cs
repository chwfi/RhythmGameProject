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

        if (GUILayout.Button("맵 재정렬하기"))
        {
            manager.SortObjects();
        }
    }
}
#endif
