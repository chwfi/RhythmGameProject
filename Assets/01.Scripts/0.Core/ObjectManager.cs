using UnityEngine;

public class ObjectManager : MonoSingleton<ObjectManager>
{
    [SerializeField] private GameObject[] _objs;
    [SerializeField] private BlowObject _blowObjectPrefab;

    [Header("Options")]
    public bool IsEditMode = false;
    public bool IsAutoMode = false;

    public void SortObjects()
    {
        foreach (GameObject obj in _objs)
        {
            obj.transform.position = new Vector3(0, -10, 0);

            if (obj.TryGetComponent(out FirstNoteObject component))
            {
                DestroyImmediate(component);
            }
        }
    }

    public void CreateBlowObject(Transform trm)
    {
        Instantiate(_blowObjectPrefab, trm);
    }
}