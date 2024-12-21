using UnityEngine;

public class EraserItem : MonoBehaviour
{
    public Camera playerCamera; // �÷��̾��� 1��Ī ī�޶�
    public BlackboardManager blackboardManager; // BlackboardManager ��ũ��Ʈ�� ����
    public ToastManager toastManager; // ToastManager ����

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ���콺 Ŭ�� ����
        {
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition); // ī�޶󿡼� Ray �߻�
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 5f)) // Ray �Ÿ� ����
            {
                if (hit.collider.CompareTag("Eraser")) // Eraser �±� Ȯ��
                {
                    if (blackboardManager != null)
                    {
                        blackboardManager.hasEraser = true; // ���찳 ���� ����
                    }
                    else
                    {
                        Debug.LogError("BlackboardManager is not assigned.");
                    }

                    gameObject.SetActive(false); // ���찳 ��Ȱ��ȭ

                    if (toastManager != null)
                    {
                        toastManager.ShowToast("Eraser collected!"); // �佺Ʈ �޽��� ǥ��
                    }
                    else
                    {
                        Debug.LogError("ToastManager is not assigned.");
                    }
                }
            }
        }
    }
}
