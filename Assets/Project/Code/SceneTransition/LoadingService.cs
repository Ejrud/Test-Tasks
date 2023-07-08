using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadingService : MonoBehaviour
{
    [SerializeField] private LoadingScreen _loadingScreen;
    [SerializeField] private HistoryService _historyService;
    
    [SerializeField] private int _menuId = 1;
    [SerializeField] private int _objectRotateId = 2;
    [SerializeField] private int _carControllerId = 3;

    private void Start()
    {
        _loadingScreen.SetActive(false);
    }

    public void LoadNextScene(SceneType currentScene, SceneType nextScene, bool saveHistory = true)
    {
        if (saveHistory)
            _historyService.SaveCurrentScene(currentScene);
            
        int sceneId = GetLevelId(nextScene);
        StartCoroutine(LoadScene(sceneId));
    }

    public void LoadPreviousScene()
    {
        if (_historyService.IsHistoryEmpty())
            return;
        
        int sceneId = GetLevelId(_historyService.GetPreviousScene());
        StartCoroutine(LoadScene(sceneId));
    }

    private IEnumerator LoadScene(int sceneId)
    {
        _loadingScreen.SetActive(true);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneId);
        asyncLoad.allowSceneActivation = false;
        
        _loadingScreen.OnLoadAnimationComplete += () =>
        {
            asyncLoad.allowSceneActivation = true;
            _loadingScreen.SetActive(false);
        };

        while (!asyncLoad.allowSceneActivation)
        {
            _loadingScreen.UpdateLoad(asyncLoad.progress);
            yield return null;
        }
        
        yield return null;
    }

    private int GetLevelId(SceneType type)
    {
        // Default value
        int sceneId = _menuId; 
        
        switch (type)
        {
            case SceneType.ObjectRotating:
                sceneId = _objectRotateId;
                break;
            
            case SceneType.CarController:
                sceneId = _carControllerId;
                break;
        }

        return sceneId;
    }
}
