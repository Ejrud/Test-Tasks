using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class SelectScene : MonoBehaviour
{
    [SerializeField] private Button _objectRotationButton;
    [SerializeField] private Button _carControllerButton;
    [SerializeField] private Button _characterAnimation;
    
    private LoadingService _loadingService;
    
    [Inject]
    public void Construct(LoadingService loadingService)
    {
        _loadingService = loadingService;
        
        _objectRotationButton.onClick.AddListener(() =>
        {
            _loadingService.LoadNextScene(SceneType.Menu, SceneType.ObjectRotating);
        });
        
        _carControllerButton.onClick.AddListener(() =>
        {
            _loadingService.LoadNextScene(SceneType.Menu, SceneType.CarController);
        });
        // _loadingService.LoadNextScene(SceneType.ModelAnimation);
    }
}
