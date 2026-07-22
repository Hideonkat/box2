using UnityEngine;
using UnityEngine.InputSystem;

public class ArrowAim : MonoBehaviour
{
    public float minAngle = 0f;
    public float maxAngle = 70f;
    public float rotateSpeed = 150f;

    private bool isHolding = false;
    private float currentAngle = 0f;      // Holds the exact angle of the arrow
    private bool isMovingUp = true;       // Controls the ping-pong direction

    void Start()
    {
        currentAngle = minAngle;
    }

    void Update()
    {
        if (Mouse.current != null)
        {
            if (Mouse.current.leftButton.isPressed)
            {
                isHolding = true;
            }
            else
            {
                isHolding = false;
            }
        }

        // Only rotate and update angle when NOT holding the mouse
        if (!isHolding)
        {
            CalculateCustomPingPong();
            transform.rotation = Quaternion.Euler(0f, 0f, currentAngle);
        }
    }

    void CalculateCustomPingPong()
    {
        // Increase or decrease angle based on direction and deltaTime
        if (isMovingUp)
        {
            currentAngle += rotateSpeed * Time.deltaTime;
            if (currentAngle >= maxAngle)
            {
                currentAngle = maxAngle;
                isMovingUp = false; // Reverse direction to down
            }
        }
        else
        {
            currentAngle -= rotateSpeed * Time.deltaTime;
            if (currentAngle <= minAngle)
            {
                currentAngle = minAngle;
                isMovingUp = true; // Reverse direction to up
            }
        }
    }
}

