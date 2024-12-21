using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera playerCamera;   // �⺻ �÷��̾� ī�޶�
    public Camera noteCamera;     // ��Ʈ�� Ŭ������ �� ����ϴ� ī�޶�
    public Camera cabinetCamera;  // ĳ����� Ŭ������ �� ����ϴ� ī�޶�
    public Camera blackboardCamera;    // ĥ���� Ŭ������ �� ����ϴ� ī�޶�
    public Camera dispenserCamera;    // �۷κ� ���漭�� Ŭ������ �� ����ϴ� ī�޶�
    public Camera trolleyCamera;    // Ʈ�Ѹ��� Ŭ������ �� ����ϴ� ī�޶�
    public Camera jarCamera;    // ���� Ŭ������ �� ����ϴ� ī�޶�
    public Camera sinkCamera;    // ����븦 Ŭ������ �� ����ϴ� ī�޶�
    public Camera trashCamera;    // ���������� Ŭ������ �� ����ϴ� ī�޶�
    public Camera metalSinkCamera;    // ��ũ�븦 Ŭ������ �� ����ϴ� ī�޶�

    private bool isUsingFixedCamera = false; // ���� ī�޶� Ȱ�� ���� Ȯ��

    private float escapeTimeLimit = 0.3f;      // 1�� �̳��� �� �� ������ ��
    private float lastEscapeTime = 0f;       // ������ Escape Ű�� ���� �ð�

    void Start()
    {
        // ó������ ���� ī�޶���� ��� ��Ȱ��ȭ
        noteCamera.gameObject.SetActive(false);
        cabinetCamera.gameObject.SetActive(false);
        blackboardCamera.gameObject.SetActive(false);
        dispenserCamera.gameObject.SetActive(false);
        trolleyCamera.gameObject.SetActive(false);
        jarCamera.gameObject.SetActive(false);
        sinkCamera.gameObject.SetActive(false);
        trashCamera.gameObject.SetActive(false);
        metalSinkCamera.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ���콺 ���� ��ư Ŭ��
        {
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition); // �⺻ ī�޶󿡼� Ray �߻�
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 5f)) // Ray�� ��ü�� �¾Ҵ��� Ȯ��
            {
                if (hit.collider.CompareTag("Note")) // Note Ŭ�� ��
                {
                    ActivateCamera(noteCamera); // Note ī�޶� Ȱ��ȭ
                }
                else if (hit.collider.CompareTag("Cabinet")) // Cabinet Ŭ�� ��
                {
                    ActivateCamera(cabinetCamera); // Cabinet ī�޶� Ȱ��ȭ
                }
                else if (hit.collider.CompareTag("Blackboard")) // Blackboard Ŭ�� ��
                {
                    ActivateCamera(blackboardCamera);  // Blackboard ī�޶� Ȱ��ȭ
                }
                else if (hit.collider.CompareTag("Dispenser")) // Dispenser Ŭ�� ��
                {
                    ActivateCamera(dispenserCamera);  // Dispenser ī�޶� Ȱ��ȭ
                }
                else if (hit.collider.CompareTag("Trolley")) // Trolley Ŭ�� ��
                {
                    ActivateCamera(trolleyCamera);  // Trolley Ȱ��ȭ
                }
                else if (hit.collider.CompareTag("Jar")) // Jar Ŭ�� ��
                {
                    ActivateCamera(jarCamera);  // Jar Ȱ��ȭ
                }
                else if (hit.collider.CompareTag("Sink")) // Sink Ŭ�� ��
                {
                    ActivateCamera(sinkCamera);  // Sink Ȱ��ȭ
                }
                else if (hit.collider.CompareTag("Trash")) // Trash Ŭ�� ��
                {
                    ActivateCamera(trashCamera);  // Trash ī�޶� Ȱ��ȭ
                }
                else if (hit.collider.CompareTag("MetalSink")) // Trash Ŭ�� ��
                {
                    ActivateCamera(metalSinkCamera);  // Trash ī�޶� Ȱ��ȭ
                }
            }
        }

        // ���� ī�޶� Ȱ��ȭ�Ǿ� ���� ��
        if (isUsingFixedCamera)
        {
            // ESC Ű�� ������ ��
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                // ù ��° Escape Ű �Է�
                if (Time.time - lastEscapeTime <= escapeTimeLimit)
                {
                    // �� ��° Escape Ű �Է� (1�� �̳�)
                    DeactivateFixedCamera(); // ���� ī�޶� ��Ȱ��ȭ
                }
                else
                {
                    // ù ��° Escape Ű �Է�, �ð� ���
                    lastEscapeTime = Time.time;
                    Debug.Log("First Escape pressed");
                }
            }
        }

    }

    private void ActivateCamera(Camera fixedCam)
    {
        // ���� ��� ���� ī�޶� ��Ȱ��ȭ
        playerCamera.gameObject.SetActive(false);
        noteCamera.gameObject.SetActive(false);
        cabinetCamera.gameObject.SetActive(false);
        blackboardCamera.gameObject.SetActive(false);
        dispenserCamera.gameObject.SetActive(false);
        trolleyCamera.gameObject.SetActive(false);
        jarCamera.gameObject.SetActive(false);
        sinkCamera.gameObject.SetActive(false);
        trashCamera.gameObject.SetActive(false);
        metalSinkCamera.gameObject.SetActive(false);

        // Ŭ���� ��ü�� �ش��ϴ� ���� ī�޶� Ȱ��ȭ
        fixedCam.gameObject.SetActive(true);
        isUsingFixedCamera = true;
    }

    private void DeactivateFixedCamera()
    {
        isUsingFixedCamera = false;
        noteCamera.gameObject.SetActive(false); // ��Ʈ ī�޶� ��Ȱ��ȭ
        cabinetCamera.gameObject.SetActive(false); // ĳ��� ī�޶� ��Ȱ��ȭ
        blackboardCamera.gameObject.SetActive(false); // ĥ�� ī�޶� ��Ȱ��ȭ
        dispenserCamera.gameObject.SetActive(false); // ���漭 ī�޶� ��Ȱ��ȭ
        trolleyCamera.gameObject.SetActive(false); // ���Ѹ� ī�޶� ��Ȱ��ȭ
        jarCamera.gameObject.SetActive(false); // �� ī�޶� ��Ȱ��ȭ
        sinkCamera.gameObject.SetActive(false); // ����� ī�޶� ��Ȱ��ȭ
        trashCamera.gameObject.SetActive(false); // �������� ī�޶� ��Ȱ��ȭ
        metalSinkCamera.gameObject.SetActive(false); // ��ũ�� ī�޶� ��Ȱ��ȭ
        playerCamera.gameObject.SetActive(true); // �⺻ ī�޶� Ȱ��ȭ
    }
}
