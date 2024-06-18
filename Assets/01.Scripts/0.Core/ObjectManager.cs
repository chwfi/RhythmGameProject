using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _objs;

    public void SortObjects()
    {
        foreach (GameObject obj in _objs)
        {
            obj.transform.position = new Vector3(0, -10, 0);
        }
    }    
}
