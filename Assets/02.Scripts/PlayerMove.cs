using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public static PlayerMove instance;

    [Header("Player Control")]
    [SerializeField] private float basicMaxHp = 100f;
    [SerializeField] private float basicAttackPower = 25f;
    [SerializeField] private float basicAttackSpeed = 1f;
    [SerializeField] private float basicMoveSpeed = 100f;
    

    [Header("Connect Component")]
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private GameObject playerGun;

    private float PLAYERHP;
    public float _playerHp
    {
        get { return PLAYERHP; }
        private set { PLAYERHP = value; }
    }

    private float PLAYERMOVESPEED;
    public float _playerMoveSpeed
    {
        get { return PLAYERMOVESPEED; }
        private set { PLAYERMOVESPEED = value; }
    }

    private float ATTACKSPEED;
    public float _attackSpeed
    {
        get { return ATTACKSPEED; }
        private set { ATTACKSPEED = value; }
    }

    public float _attackPower
    {
        get { return basicAttackPower; }
        set { basicAttackPower = value; }
    }
    

    private bool playerLookToggle = false;
    public Vector3 playerMoveLook;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        _playerHp = basicMaxHp;
        _playerMoveSpeed = basicMoveSpeed;
        _attackSpeed = basicAttackSpeed;
    }

    private void Start()
    {
        
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
            playerMoveLook = playerMoveVector.normalized;
        }

        PlayerLookSystem();

        playerRb.velocity = playerMoveVector.normalized * _playerMoveSpeed;
    }

    private void MoveVectorSetting(Vector3 valuePos)
    {
        playerMoveLook = gameObject.transform.position + valuePos;
    }


    private void PlayerLookSystem()
    {
        Vector3 playerLookVector = PlayerLookVector();

        playerGun.transform.right = playerLookVector;
    }


    private Vector3 PlayerLookVector()
    {
        Vector3 vectorValue;

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
            vectorValue = MouseLookMethod();
            return vectorValue;
        }

        else if (playerLookToggle)
        {
            vectorValue = MouseLookMethod();
            return vectorValue;
        }

        return playerMoveLook;
    }

    private Vector3 MouseLookMethod()
    {
        Vector3 result;
        Vector3 mousePos = Input.mousePosition;

        result = mousePos - gameObject.transform.position;
        return result.normalized;
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
