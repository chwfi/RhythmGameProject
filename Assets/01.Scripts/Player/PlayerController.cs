using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : PoolableMono
{
    [Header("Values")]
    [SerializeField] private float _speed;

    [Header("Setting")]
    [SerializeField] private LayerMask _objLayer;

    private bool isRotated = true;

    private Queue<NoteObject> _objs = new Queue<NoteObject>();

    private void Awake()
    {
        NoteObject[] squareObjects = FindObjectsOfType<NoteObject>();
        foreach (NoteObject obj in squareObjects)
        {
            _objs.Enqueue(obj);
        }
    }

    private void Update()
    {
        PlayerMove();
        PlayerInput();
    }

    private void PlayerMove()
    {
        transform.Translate(Vector3.up * Time.deltaTime * _speed);
    }

    private void PlayerInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (ObjectManager.Instance.IsEditMode)
            {
                CreateObject();
                Flip();
            }
            else
            {
                Flip();
                CheckObjects();
            }
        }
    }

    private void CheckObjects()
    {
        Collider2D coll = Physics2D.OverlapBox(transform.position, Vector2.one, 0, _objLayer);

        if (coll != null)
        {
            coll.gameObject.SetActive(false);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }

    private void CreateObject()
    {
        if (_objs.Count > 0)
        {
            var obj = _objs.Dequeue();
            obj.transform.position = transform.position;
        }
        else
        {
            Debug.LogWarning("No more objects to create.");
        }
    }

    public void Flip()
    {
        transform.rotation = Quaternion.Euler(0, 0, isRotated ? -45f : 45f);
        isRotated = !isRotated;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (ObjectManager.Instance.IsAutoMode)
        {
            Flip();
            collision.gameObject.SetActive(false);
        }
    }
}
