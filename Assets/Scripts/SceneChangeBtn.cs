using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeBtn : MonoBehaviour
{
    // ���� ��ȯ�ϴ� �Լ�
    public void OnButtonClick()
    {
        // ���� �ε�
        SceneManager.LoadScene("RoomEscapeScene");
    }
}
