using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectManager : MonoSingleton<ObjectManager>
{
    #region SavePath
    private const string kSaveFileName = "objectsData.json";
    private string SaveFilePath => Path.Combine(Application.persistentDataPath, kSaveFileName);
    #endregion

    [SerializeField] private List<NoteObject> _transformDataList;
    public List<NoteObject> TransformDataList => _transformDataList;

    [Header("Options")]
    public bool IsEditMode = false;
    public bool IsAutoMode = false;

    private void OnApplicationQuit() 
    {
        if (IsEditMode)
            Save();    
    }

    private void Start() 
    {
        if (!IsEditMode)
            Load();    

        if (_transformDataList.Count > 0)
        {
            var firstNote = _transformDataList.First();
            firstNote.gameObject.AddComponent<FirstNoteObject>();
        }
    }

    private void Update() 
    {
        if (IsEditMode && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void CreateBlowObject(Transform trm, Quaternion quaternion)
    {
        var obj = PoolManager.Instance.Pop("BlowObject");
        obj.transform.position = trm.position;
        obj.transform.rotation = quaternion;
    }

    private bool Load()
    {
        if (File.Exists(SaveFilePath))
        {
            var jsonContent = File.ReadAllText(SaveFilePath);
            var root = JObject.Parse(jsonContent);

            LoadSaveDatas(root["objects"], LoadNoteObject);

            Debug.Log("Data loaded from JSON file.");
            return true;
        }
        else
        {
            Debug.Log("Save file not found.");
            return false;
        }
    }

    private void Save()
    {
        var root = new JObject
        {
            { "objects", CreateSaveDatas(_transformDataList) }
        };

        File.WriteAllText(SaveFilePath, root.ToString());
        Debug.Log($"Data saved to {SaveFilePath}");
    }

    private JArray CreateSaveDatas(IReadOnlyList<NoteObject> objects)
    {
        var saveDatas = new JArray();
        foreach (var obj in objects)
        {
            saveDatas.Add(JObject.FromObject(obj.ToSaveData()));
        }
        return saveDatas;
    }

    private void LoadSaveDatas(JToken datasToken, Action<NoteObjectSaveData> onSuccess)
    {
        var datas = datasToken as JArray;
        foreach (var data in datas)
        {
            var saveData = data.ToObject<NoteObjectSaveData>();
            onSuccess?.Invoke(saveData);
        }
    }

    private void LoadNoteObject(NoteObjectSaveData saveData)
    {
        var newObj = PoolManager.Instance.Pop("Object_Square") as NoteObject;
        newObj.LoadFrom(saveData);
        
        _transformDataList.Add(newObj);
    }
}