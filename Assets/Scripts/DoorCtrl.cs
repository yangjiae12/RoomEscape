using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCtrl : MonoBehaviour
{
    private bool isOpen = false; // ���� ���ȴ��� ���� Ȯ��
    public float openAngle = 90f; // ���� ������ ����
    public float openSpeed = 3f; // �� ������ �ӵ�

    private Quaternion closedRotation; // ���� ������ ȸ����
    private Quaternion openRotation; // ���� ������ ȸ����

    void Start()
    {
        // ���� ȸ���� ���� ���·� ����
        closedRotation = transform.rotation;

        // ���� ���� ȸ���� ��� (���� ������ �ٱ������� ����)
        openRotation = Quaternion.Euler(0, openAngle, 0) * transform.rotation;
    }

    public void ToggleDoor()
    {
        // ���� ��ȯ: ���� ������ �ݰ�, ���� ������ ��
        isOpen = !isOpen;
    }

    void Update()
    {
        // ���� ���¿� ���� ���� õõ�� ���ų� ����
        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            isOpen ? openRotation : closedRotation,
            Time.deltaTime * openSpeed
        );
    }
}
