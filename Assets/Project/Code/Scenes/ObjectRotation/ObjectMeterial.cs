using UnityEngine;

public class ObjectMeterial : MonoBehaviour, IUsable
{   
    private Renderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }
    
    public void Use()
    {
        Color newColor = new Color(
            Random.Range(0f, 1f), 
            Random.Range(0f, 1f), 
            Random.Range(0f, 1f), 
            1f);
        
        SetColor(newColor);
    }

    public void SetColor(Color color)
    {
        _renderer.materials[0].color = color;
    }
}
