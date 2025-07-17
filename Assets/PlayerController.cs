using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float laneDistance = 2.5f; // Distância entre as "faixas" laterais
    private int currentLane = 1; // 0 = esquerda, 1 = meio, 2 = direita

    private Vector3 targetPosition;

    void Start()
    {
        targetPosition = transform.position;
    }

    void Update()
    {
        HandleInput();
        MoveToTarget();
    }

    void HandleInput()
    {
        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            if (currentLane > 0)
            {
                currentLane--;
                UpdateTargetPosition();
            }
        }
        else if (Keyboard.current.dKey.wasPressedThisFrame)
        {
            if (currentLane < 2)
            {
                currentLane++;
                UpdateTargetPosition();
            }
        }
    }

    void UpdateTargetPosition()
    {
        targetPosition = new Vector3((currentLane - 1) * laneDistance, transform.position.y, transform.position.z);
    }

    void MoveToTarget()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * moveSpeed);
    }
}
