using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCtrl : MonoBehaviour
{
    private bool isOpen = false; // 문이 열렸는지 상태 확인
    public float openAngle = 90f; // 문이 열리는 각도
    public float openSpeed = 3f; // 문 열리는 속도

    private Quaternion closedRotation; // 닫힌 상태의 회전값
    private Quaternion openRotation; // 열린 상태의 회전값

    void Start()
    {
        // 현재 회전을 닫힌 상태로 설정
        closedRotation = transform.rotation;

        // 열린 상태 회전값 계산 (음수 각도로 바깥쪽으로 열림)
        openRotation = Quaternion.Euler(0, openAngle, 0) * transform.rotation;
    }

    public void ToggleDoor()
    {
        // 상태 전환: 열려 있으면 닫고, 닫혀 있으면 염
        isOpen = !isOpen;
    }

    void Update()
    {
        // 현재 상태에 따라 문을 천천히 열거나 닫음
        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            isOpen ? openRotation : closedRotation,
            Time.deltaTime * openSpeed
        );
    }
}
