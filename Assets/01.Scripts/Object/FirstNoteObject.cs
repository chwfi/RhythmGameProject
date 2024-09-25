using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstNoteObject : MonoBehaviour
{
    private BoxCollider2D _collider;

    private void Awake() 
    {
        _collider = transform.GetComponent<BoxCollider2D>();

        _collider.edgeRadius = 0.45f;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        AudioManager.Instance.PlayAudio();    
    }
}
