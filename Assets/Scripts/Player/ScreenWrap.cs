using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    private Camera mainCamera;
    private float screenHalfWidth;

    private void Start()
    {
        mainCamera = Camera.main;
        screenHalfWidth = mainCamera.orthographicSize * mainCamera.aspect;
    }

    private void Update()
    {
        Vector3 playerPosition = transform.position;

        // ȭ�� ��� ���
        float leftEdge = mainCamera.transform.position.x - screenHalfWidth;
        float rightEdge = mainCamera.transform.position.x + screenHalfWidth;

        // ���� ��ġ �̵�
        if (playerPosition.x < leftEdge)
        {
            playerPosition.x = rightEdge;
        }
        else if (playerPosition.x > rightEdge)
        {
            playerPosition.x = leftEdge;
        }

        transform.position = playerPosition;
    }
}
