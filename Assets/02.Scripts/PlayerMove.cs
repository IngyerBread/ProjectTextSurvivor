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
        PlayerLookSystem();
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

        if (Input.anyKey)
        playerMoveLook = gameObject.transform.position + playerMoveVector;

        playerRb.velocity = playerMoveVector.normalized * _playerMoveSpeed;
    }

    private void MoveVectorSetting(Vector3 valuePos)
    {
        playerMoveLook = gameObject.transform.position + valuePos;
    }

    private void PlayerLookSystem()
    {
        playerGun.transform.right = (PlayerLookVector() - transform.position).normalized;
    }

    private Vector3 PlayerLookVector()
    {
        Vector3 playerLookVector;

        if (Input.GetMouseButton(0))
        {
            playerLookVector = MouseLookMethod();

            return playerLookVector;
        }

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

        if (playerLookToggle)
        {
            playerLookVector = MouseLookMethod();

            return playerLookVector;
        }

        return playerMoveLook;
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
    /// �÷��̾� ĳ���Ͱ� �ٶ󺸴�(��ݹ���)�� �켱������
    /// 1���� ��Ŭ
    /// 2���� ��Ŭ(���)
    /// 3���� Ű���� (�ֱ� �̵��� ������ �ٶ�)
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
