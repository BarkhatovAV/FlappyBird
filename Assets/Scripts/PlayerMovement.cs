using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speedX;
    [SerializeField] private float _speedY;

    [SerializeField] private float _gravity;
    [SerializeField] private float _jumpStrength;

    [SerializeField] private Transform _trail;

    private bool _isSoftJumping;

    void FixedUpdate()
    {
        _speedY += _gravity;
        if (_isSoftJumping) _speedY += _jumpStrength;
        
        _trail.position += new Vector3(0, _speedY);
        transform.position += new Vector3(_speedX,0);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        _isSoftJumping = context.phase switch
        {
            InputActionPhase.Started => true,
            InputActionPhase.Canceled => false,
            _ => _isSoftJumping
        };
    }
}
