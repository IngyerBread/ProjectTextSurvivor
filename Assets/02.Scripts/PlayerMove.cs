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

    private void ADDBuff(float time, float buffValue)
    {

    }
    ///
    /// ���� �ɶ����� �迭 Ȥ�� ����Ʈ�� �˻��ؼ� ���� �������� ���� ����
    /// �׸��� ������ �߰� �ɶ� ���� �� ���� �����Ѵٸ� ������ ������
    /// ���� ������ Ÿ�̸Ӹ� �ʱ�ȭ��Ű�� �ɵ�
    /// 
    /// ��ǲ ������� �� �÷��̾� ���꿡�� �ϰ� �Ű��ִ°� ���ҵ�
    ///
}
