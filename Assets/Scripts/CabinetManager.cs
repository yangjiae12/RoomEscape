using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CabinetManager : MonoBehaviour
{
    public Camera playerCamera; // �÷��̾��� 1��Ī ī�޶�
    public float interactionDistance = 3f; // ������ ��ȣ�ۿ� �Ÿ�
    public ToastManager toastManager; // ToastManager ����

    public Image specialImage;      // ǥ���� �̹��� UI ���
    public Text specialText;        // �ؽ�Ʈ UI ���
    public InputField inputField;   // ����ڰ� �Է��� InputField
    public GameObject cabinetDoor; // CabinetDoor ������Ʈ

    // Ű ������Ʈ
    public GameObject keyObject;   // ���� ������Ʈ

    // DoorManager �ν��Ͻ� �߰�
    public DoorManager doorManager; // DoorManager �ν��Ͻ��� ����

    void Start()
    {
        // ó������ �̹����� �ؽ�Ʈ�� ������ �ʰ� ����
        specialImage.gameObject.SetActive(false);
        specialText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            HideUI(); // UI ��� ��Ȱ��ȭ
        }

        if (Input.GetMouseButtonDown(0)) // ���콺 ���� ��ư Ŭ��
        {
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition); // ī�޶󿡼� Ray �߻�
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, interactionDistance)) // Ray�� ������Ʈ�� �¾Ҵ��� Ȯ��
            {
                if (hit.collider.CompareTag("Cabinet")) // Cabinet Ŭ���� ���
                {
                    ShowSpecialImageAndText(); // �̹����� �ؽ�Ʈ�� ǥ��

                    // �ؽ�Ʈ�� "105"�� ��� CabinetDoor ��ü�� ��Ȱ��ȭ
                    if (inputField.text == "105") // InputField���� "105"�� �Է��ߴ��� Ȯ��
                    {
                        DestroyCabinetDoor(); // CabinetDoor ��Ȱ��ȭ
                        HideUI(); // UI ��� ��Ȱ��ȭ

                        // Ű�� ����ٴ� ���� DoorManager�� ����
                        doorManager.SetHasKey(true); // DoorManager�� hasKey ���� true�� ����

                        // 1�� �ڿ� Ű�� ������� �ϰ� �佺Ʈ �޽��� ǥ��
                        StartCoroutine(KeyDisappearsAndToast());
                    }
                }
            }
        }
    }

    // CabinetDoor�� Ŭ���ϸ� Ư�� �̹����� ǥ���ϰ� �ؽ�Ʈ�� ����
    private void ShowSpecialImageAndText()
    {
        specialImage.gameObject.SetActive(true); // �̹��� ǥ��
        specialText.gameObject.SetActive(true);  // �ؽ�Ʈ ǥ��

        // �ؽ�Ʈ ���� ����
        specialText.text = "Pencil : "; // �⺻ �ȳ� �޽���
    }

    // CabinetDoor ������Ʈ�� ��Ȱ��ȭ �Ǵ� ����
    private void DestroyCabinetDoor()
    {
        if (cabinetDoor != null)
        {
            Destroy(cabinetDoor); // ��ü ����
        }
    }

    // UI ��Ҹ� ��Ȱ��ȭ
    private void HideUI()
    {
        specialImage.gameObject.SetActive(false);  // �̹��� �����
        specialText.gameObject.SetActive(false);   // �ؽ�Ʈ �����
    }

    // 1�� �ڿ� Ű�� ������� �ϰ� �佺Ʈ �޽��� ǥ���ϴ� �ڷ�ƾ
    private IEnumerator KeyDisappearsAndToast()
    {
        // 1�� ���
        yield return new WaitForSeconds(1f);

        // Ű�� ������� (��Ȱ��ȭ �Ǵ� ����)
        if (keyObject != null)
        {
            Destroy(keyObject);  // Ű ������Ʈ ����
        }

        // Ű�� ����ٴ� �佺Ʈ �޽��� ǥ��
        toastManager.ShowToast("Key Collected!");
    }
}
