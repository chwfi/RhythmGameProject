using System.Collections;
using System.Collections.Generic;
using Rito.Conveniences;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    private SaveTransformDuringPlay _saveTrm;

    private void OnEnable() 
    {
        _saveTrm = transform.GetComponent<SaveTransformDuringPlay>();

        _saveTrm._on = ObjectManager.Instance.IsEditMode;
    }
}
