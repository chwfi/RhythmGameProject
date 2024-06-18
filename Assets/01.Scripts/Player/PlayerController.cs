using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] private float _speed;

    [Header("Option")]
    public bool MapEdit = true;
    public bool AutoPlay = false;

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
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            if (MapEdit) CreateObject();
            Flip();
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
        if (AutoPlay)
        {
            Flip();
            collision.gameObject.SetActive(false);
        }
    }
}
