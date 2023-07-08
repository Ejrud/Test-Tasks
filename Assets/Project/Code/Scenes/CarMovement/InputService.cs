using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputService : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    private InputMap _inputMap;
    
    public Vector2 moveInput { get; private set; }
    public Vector2 lookInput { get; private set; }
    public bool isBreaking { get; private set; }
    public bool isGamepad { get; private set; }

    private void Awake()
    {
        _inputMap = new InputMap();
        _inputMap.CarInput.Enable();
    }

    private void Update()
    {
        float throttleInput = _inputMap.CarInput.Throttle.ReadValue<float>();
        float steeringInput = _inputMap.CarInput.Steering.ReadValue<float>();

        lookInput = _inputMap.CarInput.CameraRotation.ReadValue<Vector2>();
        moveInput = new Vector2(steeringInput, throttleInput);
        isBreaking = _inputMap.CarInput.Brake.ReadValue<float>() > 0 ? true : false;
    }
    
    public void ControlsChanged()
    {
        if (_playerInput.currentControlScheme.Equals("Gamepad"))
        {
            isGamepad = true;
            return;
        }

        isGamepad = false;
    }
}