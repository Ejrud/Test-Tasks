using UnityEngine.UI;
using UnityEngine;
using Zenject;

public class PreviousSceneLoader : MonoBehaviour
{
    [SerializeField] private Button[] _buttonTriggers;
    private LoadingService _loadingService;
    
    [Inject]
    private void Construct(LoadingService loadingService)
    {
        _loadingService = loadingService;
        ApplyAllTriggers();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _loadingService.LoadPreviousScene();
        }
    }

    private void ApplyAllTriggers()
    {
        foreach (Button button in _buttonTriggers)
        {
            button.onClick.AddListener(() => { _loadingService.LoadPreviousScene(); });
        }
    }
}
