using System;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private InputService _inputService;
    [SerializeField] private CarSettings _settings;
    
    [Header("Wheel collider")]
    [SerializeField] private WheelCollider frontLeftWheelCollider, frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider, rearRightWheelCollider;

    [Header("Wheel transform")]
    [SerializeField] private Transform frontLeftWheelTransform, frontRightWheelTransform;
    [SerializeField] private Transform rearLeftWheelTransform, rearRightWheelTransform;

    private float _currentSteerAngle;
    private float _steerAngleNormalized;
    
    private void FixedUpdate() 
    {
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }

    private void HandleMotor() 
    {
        frontLeftWheelCollider.motorTorque = _inputService.moveInput.y * _settings.motorForce;
        frontRightWheelCollider.motorTorque = _inputService.moveInput.y * _settings.motorForce;
        rearLeftWheelCollider.motorTorque = _inputService.moveInput.y * _settings.motorForce;
        rearRightWheelCollider.motorTorque = _inputService.moveInput.y * _settings.motorForce;
        _settings.currentbreakForce = _inputService.isBreaking ? _settings.breakForce : 0f;
        ApplyBreaking();
    }

    private void ApplyBreaking() 
    {
        frontRightWheelCollider.brakeTorque = _settings.currentbreakForce;
        frontLeftWheelCollider.brakeTorque = _settings.currentbreakForce;
        rearLeftWheelCollider.brakeTorque = _settings.currentbreakForce;
        rearRightWheelCollider.brakeTorque = _settings.currentbreakForce;
    }

    private void HandleSteering()
    {
        
        if (!_inputService.isGamepad)
        {
            _steerAngleNormalized = ApplySensitiveToInput(_steerAngleNormalized, _inputService.moveInput.x);
        }
        else
        {
            _steerAngleNormalized = _inputService.moveInput.x;
        }
        
        _currentSteerAngle = _steerAngleNormalized * _settings.maxSteerAngle;
        frontLeftWheelCollider.steerAngle = _currentSteerAngle;
        frontRightWheelCollider.steerAngle = _currentSteerAngle;
    }

    private void UpdateWheels() 
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform) 
    {
        Vector3 pos;
        Quaternion rot; 
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }

    private float ApplySensitiveToInput(float currentAngle, float rawInput)
    {
        if (rawInput != 0)
            currentAngle = Mathf.Clamp((currentAngle + rawInput * _settings.steerengSensitive), -1, 1);
        else
        {
            currentAngle -= currentAngle * _settings.steerengSensitive;
        }
        
        return currentAngle;
    }
}
