using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] float MoveSpeed = 10;
    float MoveDir = 0;
    Rigidbody2D rigid;

    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        rigid = GetComponent<Rigidbody2D>();
    }

    void OnEnable()
    {
        playerInput.onActionTriggered += EventSub;
    }

    void DisEnable()
    {
        playerInput.onActionTriggered -= EventSub;
    }

    void FixedUpdate()
    {
        rigid.AddForceX(MoveDir * MoveSpeed);
        rigid.linearVelocityX = Mathf.Clamp(rigid.linearVelocityX, -5, 5);
    }

    public void EventSub(InputAction.CallbackContext context)
    {
        //Debug.Log($"{context.action.name}");

        if(context.action.name == "Move")
        {
            MoveDir = context.ReadValue<float>();
        }

        if(context.action.name == "Jump")
        {
            rigid.linearVelocityY = 7.5f;
        }
    }
}
