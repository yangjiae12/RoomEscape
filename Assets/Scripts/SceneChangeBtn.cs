using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeBtn : MonoBehaviour
{
    // 씬을 전환하는 함수
    public void OnButtonClick()
    {
        // 씬을 로드
        SceneManager.LoadScene("RoomEscapeScene");
    }
}
