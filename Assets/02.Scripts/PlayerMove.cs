using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public static PlayerMove instance;

    [Header("Player Control")]
    [SerializeField] private float battleEnterHp = 100f;
    private float inGameMaxHp;
    private float currnetHp;

    [SerializeField] private float battleEnterMoveSpeed = 100f;
    private float inGameBaseMoveSpeed;
    private float currnetMoveSpeed;

    [Header("Attack Value Setting")]
    [SerializeField] private float battleEnterAttackDamage = 25f;
    [SerializeField] private float battleEnterAttackSpeed = 1f;
    [SerializeField] private float battleEnterFireObjectSpeed = 600f;
    

    [Header("Connect Component")]
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private GameObject playerGun;

    

    private bool playerLookToggle = false;
    public Vector3 playerMoveLook;

    private void InputValueSettingSystem()
    {
        //Hp
        inGameMaxHp = battleEnterHp;
        currnetHp = inGameMaxHp;

        //MoveSpeed
        inGameBaseMoveSpeed = battleEnterMoveSpeed;
        currnetMoveSpeed = inGameBaseMoveSpeed;

        PlayerAttack.instance.GetAttackValue(battleEnterAttackDamage, battleEnterAttackSpeed, battleEnterFireObjectSpeed);
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        InputValueSettingSystem();
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

        playerRb.velocity = playerMoveVector.normalized * currnetMoveSpeed;
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

    private void ADDBuff(float time, float buffValue)
    {

    }
    ///
    /// 실행 될때마다 배열 혹은 리스트를 검색해서 가장 높은수의 버프 적용
    /// 그리고 버프가 추가 될때 끝날 때 마다 실행한다면 괜찮지 않을까
    /// 같은 버프는 타이머를 초기화시키면 될듯
    /// 
    /// 인풋 밸류들은 다 플레이어 무브에서 하고 옮겨주는게 편할듯
    ///
}
