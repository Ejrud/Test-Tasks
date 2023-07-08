using System.Collections.Generic;
using UnityEngine;

public class HistoryService : MonoBehaviour
{
    private Stack<SceneType> _sceneHistory = new Stack<SceneType>();

    public void SaveCurrentScene(SceneType sceneType)
    {
        Debug.Log(sceneType);
        _sceneHistory.Push(sceneType);
    }

    public SceneType GetPreviousScene()
    {
        SceneType sceneType = _sceneHistory.Pop();
        return sceneType;
    }

    public bool IsHistoryEmpty()
    {
        if (_sceneHistory.Count == 0)
        {
            return true;
        }

        return false;
    }
}
