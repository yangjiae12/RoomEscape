using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ToastManager : MonoBehaviour
{
    public GameObject toastPanel; // �佺Ʈ �޽����� ��� (Panel)
    public Text toastText;        // �佺Ʈ �޽��� ���� (Text)
    public float duration = 2f;   // �޽����� ǥ�õ� �ð�

    private Coroutine currentToast;

    public void ShowToast(string message)
    {
        if (currentToast != null)
        {
            StopCoroutine(currentToast); // ���� �޽��� ����
        }
        currentToast = StartCoroutine(DisplayToast(message));
    }

    private IEnumerator DisplayToast(string message)
    {
        toastText.text = message;        // �޽��� ����
        toastPanel.SetActive(true);     // �г� Ȱ��ȭ
        yield return new WaitForSeconds(duration); // ������ �ð� ���
        toastPanel.SetActive(false);    // �г� ��Ȱ��ȭ
    }
}
