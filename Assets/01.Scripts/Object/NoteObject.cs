using UnityEngine;

[System.Serializable]
public struct NoteObjectSaveData
{
    public float x;
    public float y;
}

public class NoteObject : PoolableMono
{
    public float TransformX;
    public float TransformY;

    private void OnEnable() 
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 45));    
    }

    public NoteObjectSaveData ToSaveData()
    {
        return new NoteObjectSaveData
        {
            x = TransformX,
            y = TransformY
        };
    }

    public void LoadFrom(NoteObjectSaveData saveData)
    {
        TransformX = saveData.x;
        TransformY = saveData.y;

        transform.position = new Vector3(TransformX, TransformY);
    }
}
