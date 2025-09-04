using UnityEngine;
using UnityEngine.InputSystem;

public class SpaceshipController : MonoBehaviour
{
    // Speed settings
    public float speed;
    public float minSpeed = 50f;
    public float maxSpeed = 250f;
    public float accelerationRate = 35f;
    private float speedInput = 0f;
    
    // Rotation settings
    public float rotationSpeed = 50f;
    public float pitchSpeed = 50f;
    private float rotationInput = 0f;
    private float pitchInput = 0f;

    private void Update()
    {
        speed += speedInput * accelerationRate * Time.deltaTime;
        
        speed = Mathf.Clamp(speed, minSpeed, maxSpeed);
        
        transform.position += transform.forward * (speed * Time.deltaTime);
        
        if (rotationInput != 0f)
        {
            transform.Rotate(0f, 0f, -rotationInput * rotationSpeed * Time.deltaTime); 
        }

        if (pitchInput != 0f)
        {
            transform.Rotate(pitchInput * pitchSpeed * Time.deltaTime, 0f, 0f); 
        }
    }
    
    public void Speed (InputAction.CallbackContext context)
    {
        speedInput = context.ReadValue<float>();
    }
    
    public void Rotate (InputAction.CallbackContext context)
    {
        rotationInput = context.ReadValue<float>();
    }
    
    public void Pitch (InputAction.CallbackContext context)
    {
        pitchInput = context.ReadValue<float>();
    }
}
