using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ObjectManager))]
public class MyWindowEditor : EditorWindow
{
    ObjectManager objectEditManager;

    [MenuItem("도구/정렬 도구 %F1")] // Ctrl + F1 단축키 설정  
    public static void ShowWindow()
    {
        GetWindow<MyWindowEditor>("정렬 도구");
    }

    void OnGUI()
    {
        GUIStyle largeLabelStyle = new GUIStyle(EditorStyles.boldLabel)
        {
            fontSize = 30,
            alignment = TextAnchor.MiddleCenter
        };

        GUILayout.Label("<오브젝트 정렬>", largeLabelStyle, GUILayout.Height(40));

        GUILayout.FlexibleSpace(); 

        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace(); 

        if (GUILayout.Button("초기화 포지션으로 일괄 정렬\n(주의 : 맵이 완전히 초기화됩니다.)", GUILayout.Width(400), GUILayout.Height(80)))
        {
            objectEditManager = FindAnyObjectByType<ObjectManager>();

            objectEditManager.SortObjects();
        }

        GUILayout.FlexibleSpace(); 
        GUILayout.EndHorizontal();

        GUILayout.FlexibleSpace(); 
    }
}
