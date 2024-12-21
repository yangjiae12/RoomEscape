using UnityEngine;

public class BlackboardManager : MonoBehaviour
{
    public Camera playerCamera; // �÷��̾��� 1��Ī ī�޶�
    public ToastManager toastManager; // ToastManager ����
    public GameObject specialImage; // ����� �̹��� UI
    public bool hasEraser = false; // ���찳 ���� ����

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ���콺 Ŭ�� ����
        {
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 5f)) // Ray �Ÿ� ����
            {
                if (hit.collider != null && hit.collider.CompareTag("Blackboard")) // ĥ�� �±� Ȯ��
                {
                    if (hasEraser)
                    {
                        // ���찳�� ���� �� ����� UI ǥ��
                        if (specialImage != null)
                        {
                            specialImage.SetActive(true); // ����� �̹��� Ȱ��ȭ
                            toastManager.ShowToast("You used an eraser on the blackboard!");
                        }
                        else
                        {
                            Debug.LogError("Special Image UI is not assigned.");
                        }
                    }
                    else
                    {
                        // ���찳�� ���� ��
                        toastManager.ShowToast("You need an eraser!");
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape)) // Escape Ű�� ������ ��
        {
            HideSpecialImage(); // �̹����� ����
        }
    }

    // �̹����� ����� �޼���
    public void HideSpecialImage()
    {
        specialImage.gameObject.SetActive(false); // �̹��� �����
    }
}
