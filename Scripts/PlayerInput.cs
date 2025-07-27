using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{

    [SerializeField] private InputActionReference fire;
    private bool firing = false;
    private bool firingStart = false;
    private float firingStartTime = 0;
    [SerializeField] private InputActionReference mousePosition;
    private Vector2 mousePos;
    [SerializeField] private InputActionReference mouseDelta;
    private Vector2 mouseDel;

    private void Update()
    {
        mousePos = mousePosition.action.ReadValue<Vector2>();
        mouseDel = mouseDelta.action.ReadValue<Vector2>();
    }

    private void OnEnable()
    {
        fire.action.performed += PerformFire;
        fire.action.canceled += StopFire;
    }

    private void OnDisable()
    {
        fire.action.performed -= PerformFire;
        fire.action.canceled -= StopFire;
    }

    public bool GetFire()
    {
        return firing;
    }

    public bool GetFireStart()
    {
        return firingStartTime == Time.time;
    }

    private void PerformFire(InputAction.CallbackContext obj)
    {
        firing = true;
        firingStartTime = Time.time;
    }

    private void StopFire(InputAction.CallbackContext obj)
    {
        firing = false;
    }

    public Vector2 GetMousePos()
    {
        return mousePos;
    }

    public Vector2 GetMouseDelta()
    {
        return mouseDel;
    }
    
}
