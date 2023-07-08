using UnityEngine;

public class CarSettings : MonoBehaviour
{
    public float motorForce, breakForce, maxSteerAngle;
    public float steerengSensitive = 0.4f;
    public float currentbreakForce { get; set; }
    public bool isBreaking { get; set; }
}
