using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeTransition : MonoBehaviour
{
    public Camera playerCamera; // �÷��̾��� ī�޶�

    void Update()
    {
        // ���콺 Ŭ�� �� �� ��ȯ
        if (Input.GetMouseButtonDown(0)) // ���� ���콺�� Ŭ������ ��
        {
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition); // ���콺 Ŭ�� ��ġ�κ��� Ray �߻�
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 2f)) // Raycast�� ��ü�� Ŭ������ ��
            {
                if (hit.collider.CompareTag("Escape")) // "Escape" �±׸� ���� ��ü�� Ŭ���� ���
                {
                    LoadNewScene(); // �� ��ȯ �Լ� ȣ��
                }
            }
        }
    }

    // ���� ��ȯ�ϴ� �Լ�
    void LoadNewScene()
    {
        SceneManager.LoadScene("GameClear"); // ��ȯ�� �� �̸��� �����ּ���
    }
}
