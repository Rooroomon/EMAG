using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;

    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();

        playerInput.onActionTriggered += asd;
    }

    void OnEnable()
    {
        
    }

    void Update()
    {
        
    }

    void asd(InputAction.CallbackContext context)
    {
        print("sdflkjhsdf");
    }
}
