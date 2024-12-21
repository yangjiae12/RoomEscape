using System.Collections;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public Camera playerCamera; // �÷��̾��� 1��Ī ī�޶�
    public ToastManager toastManager; // ToastManager ����
    public bool hasKey = false; // Ű�� �����ϰ� �ִ��� ����

    private void Update()
    {
        // ���콺 ���� ��ư Ŭ���� ���¿����� Raycast ����
        if (Input.GetMouseButtonDown(0)) // ���콺 ���� ��ư Ŭ��
        {
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition); // ī�޶󿡼� Ray �߻�
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 5f)) // Raycast�� ������Ʈ�� �¾Ҵ��� Ȯ��
            {
                if (hit.collider.CompareTag("Door")) // ���� Ŭ���� ���
                {
                    DoorCtrl door = hit.collider.GetComponent<DoorCtrl>(); // ������ Ȯ��
                    if (door != null)
                    {
                        // ���谡 ������ �� ����/�ݱ�
                        if (hasKey)
                        {
                            door.ToggleDoor(); // �� ����/�ݱ�
                        }
                        else
                        {
                            toastManager.ShowToast("You need a key to open this door!"); // ���谡 ������ �佺Ʈ �޽��� ���
                        }
                    }
                }
            }
        }
    }

    // Ű�� �����ϴ� �޼���
    public void SetHasKey(bool value)
    {
        hasKey = value;
    }
}
