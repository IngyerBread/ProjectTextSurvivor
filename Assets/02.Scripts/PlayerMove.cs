using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Player Control")]
    [SerializeField] private float basicMaxHp = 100f;
    [SerializeField] private float basicAttackPower = 100f;
    [SerializeField] private float basicMoveSpeed = 100f;
    

    [Header("Connect Component")]
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private GameObject playerGun;

    private float _playerHp;
    private float _playerMoveSpeed;
    private bool playerLookToggle = false;
    private Vector3 playerMoveLook;

    private void Start()
    {
        _playerHp = basicMaxHp;
        _playerMoveSpeed = basicMoveSpeed;
    }

    void Update()
    {
        PlayerMoveControl();
        playerGun.transform.LookAt(PlayerLookSystem());
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

        playerMoveLook = playerMoveVector;

        playerRb.velocity = playerMoveVector.normalized * _playerMoveSpeed;
    }

    private Vector3 PlayerLookSystem()
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

        result = Camera.main.ScreenToWorldPoint(mousePos);
        return result;
    }
    /// <summary>
    /// �÷��̾� ĳ���Ͱ� �ٶ󺸴�(��ݹ���)�� �켱������
    /// 1���� ��Ŭ
    /// 2���� ��Ŭ(���)
    /// 3���� Ű���� (�ֱ� �̵��� ������ �ٶ�)
    /// </summary>
    /// <param name="damage"></param>

    public void PlayerDamaged(float damage)
    {

    }

    private float PercentCalculator(float value, float percent)
    {
        float resultValue = value / 100 * percent;

        return resultValue;
    }
}
