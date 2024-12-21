using UnityEngine;
using UnityEngine.UI;

public class NoteManager : MonoBehaviour
{
    public Camera fixedCamera;      // ������ ī�޶�
    public ToastManager toastManager; // ToastManager ���� (�佺Ʈ �޽��� ǥ�ÿ�)
    public Image specialImage;      // ǥ���� �̹��� UI ���
    private bool hasPencil = false; // Pencil�� �����ߴ��� ����

    private void Start()
    {
        // ó������ �̹����� ������ �ʰ� ����
        specialImage.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ���콺 ���� ��ư Ŭ��
        {
            Ray ray = fixedCamera.ScreenPointToRay(Input.mousePosition); // ���� ī�޶󿡼� Ray �߻�
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) // Ray�� ��ü�� �¾Ҵ��� Ȯ��
            {
                if (hit.collider.CompareTag("Pencil")) // Pencil �������� Ŭ���� ���
                {
                    CollectPencil(hit.collider.gameObject); // Pencil ����
                }
                else if (hit.collider.CompareTag("Note") && hasPencil) // Note�� Ŭ���� ��� (Pencil�� ������ ���¿�����)
                {
                    ShowSpecialImage(); // �̹����� ǥ��
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape)) // Escape Ű�� ������ ��
        {
            HideSpecialImage(); // �̹����� ����
        }
    }

    // Pencil ������ ����
    private void CollectPencil(GameObject pencil)
    {
        hasPencil = true; // Pencil�� ����
        pencil.SetActive(false); // Pencil�� ��Ȱ��ȭ (����)
        toastManager.ShowToast("Pencil collected!"); // �佺Ʈ �޽��� ǥ��
    }

    // Note�� Ŭ���ϸ� Ư�� �̹����� ǥ��
    private void ShowSpecialImage()
    {
        specialImage.gameObject.SetActive(true); // �̹��� ǥ��
        toastManager.ShowToast("You used the pencil on the note!"); // �佺Ʈ �޽��� ǥ��
    }

    // �̹����� ����� �޼���
    public void HideSpecialImage()
    {
        specialImage.gameObject.SetActive(false); // �̹��� �����
    }
}
