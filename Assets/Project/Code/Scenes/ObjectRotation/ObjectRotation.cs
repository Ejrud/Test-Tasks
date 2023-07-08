using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    [Header("Rotation settings")]
    [SerializeField] private float _xRotationSpeed;
    [SerializeField] private float _yRotationSpeed;
    [SerializeField] private float _zRotationSpeed;

    private Transform _selfTransform;
    
    private void Start()
    {
        _selfTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        Vector3 rotation = new Vector3(
            1 * _xRotationSpeed * Time.deltaTime,
            1 * _yRotationSpeed * Time.deltaTime,
            1 * _zRotationSpeed * Time.deltaTime
        );
        
        _selfTransform.Rotate(rotation);
    }
}
