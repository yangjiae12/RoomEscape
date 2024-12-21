using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : MonoBehaviour
{
    public DoorManager doorManager; // 문 스크립트를 참조

    private void OnMouseDown()
    {
        if (doorManager != null)
        {
            doorManager.hasKey = true; // 열쇠 사용 상태 저장
            gameObject.SetActive(false); // 열쇠 비활성화
        }
        else
        {
            Debug.LogWarning("DoorHandler is not assigned!");
        }
    }
}
