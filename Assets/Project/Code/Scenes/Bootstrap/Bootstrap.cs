using UnityEngine;
using Zenject;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private SceneType _currentScene;
    [SerializeField] private SceneType _nextScene;
    
    [Inject]
    private void Construct(LoadingService loadingService)
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 120;
        loadingService.LoadNextScene(_currentScene, _nextScene, false);
    }
}
