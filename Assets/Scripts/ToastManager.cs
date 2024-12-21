using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ToastManager : MonoBehaviour
{
    public GameObject toastPanel; // 토스트 메시지의 배경 (Panel)
    public Text toastText;        // 토스트 메시지 내용 (Text)
    public float duration = 2f;   // 메시지가 표시될 시간

    private Coroutine currentToast;

    public void ShowToast(string message)
    {
        if (currentToast != null)
        {
            StopCoroutine(currentToast); // 기존 메시지 제거
        }
        currentToast = StartCoroutine(DisplayToast(message));
    }

    private IEnumerator DisplayToast(string message)
    {
        toastText.text = message;        // 메시지 설정
        toastPanel.SetActive(true);     // 패널 활성화
        yield return new WaitForSeconds(duration); // 지정된 시간 대기
        toastPanel.SetActive(false);    // 패널 비활성화
    }
}
