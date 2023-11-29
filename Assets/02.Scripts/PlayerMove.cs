using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public static PlayerMove instance;

    [Header("Player Control")]
    [SerializeField] private float basicMaxHp = 100f;
    [SerializeField] private float basicAttackPower = 100f;
    [SerializeField] private float basicAttackSpeed = 10f;
    [SerializeField] private float basicMoveSpeed = 100f;
    

    [Header("Connect Component")]
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private GameObject playerGun;

    private float _playerHp;
    private float _playerMoveSpeed;
    public float _attackSpeed
    {
        get { return _attackSpeed; }
        private set { _attackSpeed = value; }
    }
    private bool playerLookToggle = false;
    private Vector3 playerMoveLook;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        _playerHp = basicMaxHp;
        _playerMoveSpeed = basicMoveSpeed;
    }

    void Update()
    {
        PlayerMoveControl();
    }

    private void PlayerMoveControl()
    {
        Vector3 playerMoveVector = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            playerMoveVector.y = 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            playerMoveVector.x = -1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            playerMoveVector.y = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerMoveVector.x = 1;
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            playerMoveLook = gameObject.transform.position + playerMoveVector;
        }
        PlayerLookSystem();


        gameObject.transform.position = gameObject.transform.position + (playerMoveVector.normalized * _playerMoveSpeed * Time.deltaTime);
        //playerRb.velocity = playerMoveVector.normalized * _playerMoveSpeed;
    }

    private void MoveVectorSetting(Vector3 valuePos)
    {
        playerMoveLook = gameObject.transform.position + valuePos;
    }

    private void PlayerLookSystem()
    {
        PlayerLookVector();

        playerGun.transform.right = (playerMoveLook - transform.position).normalized;
    }

    private void PlayerLookVector()
    {
        if (playerMoveLook != null)
        {
            if (Input.GetMouseButtonDown(1))
            {
                if (playerLookToggle == false)
                {
                    playerLookToggle = true;
                }

                else if (playerLookToggle == true)
                {
                    playerLookToggle = false;
                }
            }

            if (Input.GetMouseButton(0))
            {
                playerMoveLook = MouseLookMethod();
            }

            else if (playerLookToggle)
            {
                playerMoveLook = MouseLookMethod();
            }
        }
    }

    private Vector3 MouseLookMethod()
    {
        Vector3 result;
        Vector3 mousePos = Input.mousePosition;

        result = mousePos;
        playerMoveLook = result;
        return result;
    }
    /// <summary>
    /// 플레이어 캐릭터가 바라보는(사격방향)의 우선순위는
    /// 1순위 좌클
    /// 2순위 우클(토글)
    /// 3순위 키보드 (최근 이동한 방향을 바라봄)
    /// </summary>

    public void PlayerDamaged(float damage)
    {

    }

    private float PercentCalculator(float value, float percent)
    {
        float resultValue = value / 100 * percent;

        return resultValue;
    }
}
