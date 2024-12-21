using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera playerCamera;   // 기본 플레이어 카메라
    public Camera noteCamera;     // 노트를 클릭했을 때 사용하는 카메라
    public Camera cabinetCamera;  // 캐비넷을 클릭했을 때 사용하는 카메라
    public Camera blackboardCamera;    // 칠판을 클릭했을 때 사용하는 카메라
    public Camera dispenserCamera;    // 글로브 디스펜서를 클릭했을 때 사용하는 카메라
    public Camera trolleyCamera;    // 트롤리를 클릭했을 때 사용하는 카메라
    public Camera jarCamera;    // 병을 클릭했을 때 사용하는 카메라
    public Camera sinkCamera;    // 세면대를 클릭했을 때 사용하는 카메라
    public Camera trashCamera;    // 쓰레기통을 클릭했을 때 사용하는 카메라
    public Camera metalSinkCamera;    // 싱크대를 클릭했을 때 사용하는 카메라

    private bool isUsingFixedCamera = false; // 고정 카메라 활성 상태 확인

    private float escapeTimeLimit = 0.3f;      // 1초 이내로 두 번 눌려야 함
    private float lastEscapeTime = 0f;       // 마지막 Escape 키를 누른 시간

    void Start()
    {
        // 처음에는 고정 카메라들을 모두 비활성화
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
        if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 버튼 클릭
        {
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition); // 기본 카메라에서 Ray 발사
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 5f)) // Ray가 물체에 맞았는지 확인
            {
                if (hit.collider.CompareTag("Note")) // Note 클릭 시
                {
                    ActivateCamera(noteCamera); // Note 카메라 활성화
                }
                else if (hit.collider.CompareTag("Cabinet")) // Cabinet 클릭 시
                {
                    ActivateCamera(cabinetCamera); // Cabinet 카메라 활성화
                }
                else if (hit.collider.CompareTag("Blackboard")) // Blackboard 클릭 시
                {
                    ActivateCamera(blackboardCamera);  // Blackboard 카메라 활성화
                }
                else if (hit.collider.CompareTag("Dispenser")) // Dispenser 클릭 시
                {
                    ActivateCamera(dispenserCamera);  // Dispenser 카메라 활성화
                }
                else if (hit.collider.CompareTag("Trolley")) // Trolley 클릭 시
                {
                    ActivateCamera(trolleyCamera);  // Trolley 활성화
                }
                else if (hit.collider.CompareTag("Jar")) // Jar 클릭 시
                {
                    ActivateCamera(jarCamera);  // Jar 활성화
                }
                else if (hit.collider.CompareTag("Sink")) // Sink 클릭 시
                {
                    ActivateCamera(sinkCamera);  // Sink 활성화
                }
                else if (hit.collider.CompareTag("Trash")) // Trash 클릭 시
                {
                    ActivateCamera(trashCamera);  // Trash 카메라 활성화
                }
                else if (hit.collider.CompareTag("MetalSink")) // Trash 클릭 시
                {
                    ActivateCamera(metalSinkCamera);  // Trash 카메라 활성화
                }
            }
        }

        // 고정 카메라가 활성화되어 있을 때
        if (isUsingFixedCamera)
        {
            // ESC 키가 눌렸을 때
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                // 첫 번째 Escape 키 입력
                if (Time.time - lastEscapeTime <= escapeTimeLimit)
                {
                    // 두 번째 Escape 키 입력 (1초 이내)
                    DeactivateFixedCamera(); // 고정 카메라 비활성화
                }
                else
                {
                    // 첫 번째 Escape 키 입력, 시간 기록
                    lastEscapeTime = Time.time;
                    Debug.Log("First Escape pressed");
                }
            }
        }

    }

    private void ActivateCamera(Camera fixedCam)
    {
        // 현재 사용 중인 카메라 비활성화
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

        // 클릭된 물체에 해당하는 고정 카메라 활성화
        fixedCam.gameObject.SetActive(true);
        isUsingFixedCamera = true;
    }

    private void DeactivateFixedCamera()
    {
        isUsingFixedCamera = false;
        noteCamera.gameObject.SetActive(false); // 노트 카메라 비활성화
        cabinetCamera.gameObject.SetActive(false); // 캐비넷 카메라 비활성화
        blackboardCamera.gameObject.SetActive(false); // 칠판 카메라 비활성화
        dispenserCamera.gameObject.SetActive(false); // 디스펜서 카메라 비활성화
        trolleyCamera.gameObject.SetActive(false); // ㅌ롤리 카메라 비활성화
        jarCamera.gameObject.SetActive(false); // 병 카메라 비활성화
        sinkCamera.gameObject.SetActive(false); // 세면대 카메라 비활성화
        trashCamera.gameObject.SetActive(false); // 쓰레기통 카메라 비활성화
        metalSinkCamera.gameObject.SetActive(false); // 싱크대 카메라 비활성화
        playerCamera.gameObject.SetActive(true); // 기본 카메라 활성화
    }
}
