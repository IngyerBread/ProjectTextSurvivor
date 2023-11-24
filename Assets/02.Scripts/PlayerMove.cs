using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Player Control")]
    [SerializeField] private float playerMoveSpeed = 1;
    [SerializeField] private Rigidbody2D playerRb;

    void Update()
    {
        Vector2 playerMoveVector = Vector2.zero;

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

        playerRb.velocity = playerMoveVector.normalized * playerMoveSpeed;
    }
}
