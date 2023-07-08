using UnityEngine;

public class CameraRaycaster : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    
    private void Update()
    {
        if (!Input.GetMouseButtonUp(0))
            return;
        
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        if (!Physics.Raycast(ray, out RaycastHit hit))
            return;
        
        if (hit.transform.TryGetComponent<IUsable>(out IUsable iUsableObj))
        {
            iUsableObj.Use();
        }
    }
}
