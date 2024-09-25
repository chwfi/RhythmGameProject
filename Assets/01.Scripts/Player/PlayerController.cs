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
            ObjectManager.Instance.CreateBlowObject(coll.transform, coll.transform.rotation);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }

    private void CreateObject()
    {
        var instance = ObjectManager.Instance;

        var obj = PoolManager.Instance.Pop("Object_Square") as NoteObject;

        obj.transform.position = transform.position;
        obj.TransformX = transform.position.x;
        obj.TransformY = transform.position.y;

        instance.TransformDataList.Add(obj);
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
