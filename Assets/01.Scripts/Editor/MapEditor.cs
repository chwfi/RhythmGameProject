using UnityEditor;
using UnityEngine;

// 커스텀 에디터로 수정하려는 스크립트 지정
[CustomEditor(typeof(ObjectManager))]
public class MapEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("맵 파일로 저장하기"))
        {
            ObjectManager manager = ObjectManager.Instance;

            manager.SaveAsResourceFile();
        }
    }
}