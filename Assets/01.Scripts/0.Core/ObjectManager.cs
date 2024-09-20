using UnityEngine;

public class ObjectManager : MonoSingleton<ObjectManager>
{
    [SerializeField] private GameObject[] _objs;

    [Header("Options")]
    public bool IsEditMode = false;
    public bool IsAutoMode = false;

    public void SortObjects()
    {
        foreach (GameObject obj in _objs)
        {
            obj.transform.position = new Vector3(0, -10, 0);
        }
    }
}