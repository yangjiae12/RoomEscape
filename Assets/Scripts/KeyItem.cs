using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : MonoBehaviour
{
    public DoorManager doorManager; // �� ��ũ��Ʈ�� ����

    private void OnMouseDown()
    {
        if (doorManager != null)
        {
            doorManager.hasKey = true; // ���� ��� ���� ����
            gameObject.SetActive(false); // ���� ��Ȱ��ȭ
        }
        else
        {
            Debug.LogWarning("DoorHandler is not assigned!");
        }
    }
}
