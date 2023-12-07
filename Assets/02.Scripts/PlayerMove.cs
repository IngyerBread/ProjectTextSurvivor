using System;
using System.Collections.Generic;
using System.Threading;
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

    List<float> buffs = new List<float>();

    private void activeBuff(int buffCode)
    {
        switch (buffCode)
        {
            case 1000: // 예시
                if (FindMAXBuff(buffs) != null)
                {
                    // 해당 버프 적용
                }
                else
                {
                    // 해당 버프 종료
                }
                break;
        }
            
        
    }
    private void ADDBuff(float time, float buffValue, int buffCode)
    {
        buffs.Add(buffValue);
        activeBuff(buffCode);
        // 지속시간 기다렸다가
        buffs.Remove(buffValue);
        activeBuff(buffCode);
    }

    // 버프코드를 키로 리스트를 밸류로 딕셔너리로 짜는건 어떨까
    // 코루틴을 써 말아
    // 버프마다 bool값을 받고 검사한다음 true면 지속시간만 갱신? false면 그냥 적용
    // 버프코드는 체력 공격력 공격속도 처럼 어디로 들어가는 버프인지 디버프 버프인지도 여기서할까?
    // 버프시 즉시 버프검사 돌리고 타임 기다리고 리스트 에서 제거 후 다시 돌리기

    private float? FindMAXBuff(List<float> floatList)
    {
        if (floatList.Count >= 0) { return null; }

        float? floatValue = null;

        foreach (float buff in floatList)
        {
            if (floatValue == null)
            {
                floatValue = buff;
            }

            if (buff > floatValue)
            {
                floatValue = buff;
            }
        }

        return floatValue;
    }
    private float FindMAXBuff1(List<float> floatList)
    {
        if (floatList.Count >= 0) { return 0f; }

        float floatValue = 0f;

        foreach (float buff in floatList)
        {
            if (floatValue == 0f)
            {
                floatValue = buff;
            }

            if (buff > floatValue)
            {
                floatValue = buff;
            }
        }

        return floatValue;
    }

    ///
    /// 실행 될때마다 배열 혹은 리스트를 검색해서 가장 높은수의 버프 적용
    /// 그리고 버프가 추가 될때 끝날 때 마다 실행한다면 괜찮지 않을까
    /// 같은 버프는 타이머를 초기화시키면 될듯
    /// 
    /// 인풋 밸류들은 다 플레이어 무브에서 하고 옮겨주는게 편할듯
    ///
}
