using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using Unity.Cinemachine;


public class Player : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] float MoveSpeed = 10;
    public CinemachineImpulseSource impulseSource;

    float MoveDir = 0;
    Rigidbody2D rigid;
    public int maxHp = 5;
    public int currentHp = 5;
    bool invincibilityTime = false;
    float iCoolTime = 1;
    public System.Action OnHealthChange;
    public bool DamageTrigger = false;

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

        if(DamageTrigger)
        {
            TakeDamage(1);
            DamageTrigger = false;
        }
    }

    public void EventSub(InputAction.CallbackContext context)
    {
        if(context.action.name == "Move")
        {
            MoveDir = context.ReadValue<float>();
        }

        if(context.action.name == "Jump")
        {
            rigid.linearVelocityY = 6f;
        }
    }

    public void TakeDamage(int damage)
    {
        if (!invincibilityTime)
        {
            invincibilityTime = true;
            currentHp -= damage;
            impulseSource.GenerateImpulse();
            OnHealthChange?.Invoke();
            StartCoroutine(IColltimeControl());
        }
    }

    private IEnumerator IColltimeControl()
    {
        yield return new WaitForSeconds(iCoolTime);
        invincibilityTime = false;
    }
    
    public void ResetPlayer()
    {
        StopAllCoroutines();
        currentHp = maxHp;
        invincibilityTime = false;
        OnHealthChange?.Invoke();
    }
}
