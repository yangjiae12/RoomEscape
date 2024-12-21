using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CabinetManager : MonoBehaviour
{
    public Camera playerCamera; // 플레이어의 1인칭 카메라
    public float interactionDistance = 3f; // 문과의 상호작용 거리
    public ToastManager toastManager; // ToastManager 연결

    public Image specialImage;      // 표시할 이미지 UI 요소
    public Text specialText;        // 텍스트 UI 요소
    public InputField inputField;   // 사용자가 입력할 InputField
    public GameObject cabinetDoor; // CabinetDoor 오브젝트

    // 키 오브젝트
    public GameObject keyObject;   // 열쇠 오브젝트

    // DoorManager 인스턴스 추가
    public DoorManager doorManager; // DoorManager 인스턴스를 연결

    void Start()
    {
        // 처음에는 이미지와 텍스트가 보이지 않게 설정
        specialImage.gameObject.SetActive(false);
        specialText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            HideUI(); // UI 요소 비활성화
        }

        if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 버튼 클릭
        {
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition); // 카메라에서 Ray 발사
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, interactionDistance)) // Ray가 오브젝트에 맞았는지 확인
            {
                if (hit.collider.CompareTag("Cabinet")) // Cabinet 클릭한 경우
                {
                    ShowSpecialImageAndText(); // 이미지와 텍스트를 표시

                    // 텍스트가 "105"일 경우 CabinetDoor 물체를 비활성화
                    if (inputField.text == "105") // InputField에서 "105"을 입력했는지 확인
                    {
                        DestroyCabinetDoor(); // CabinetDoor 비활성화
                        HideUI(); // UI 요소 비활성화

                        // 키를 얻었다는 값을 DoorManager로 전달
                        doorManager.SetHasKey(true); // DoorManager의 hasKey 값을 true로 설정

                        // 1초 뒤에 키를 사라지게 하고 토스트 메시지 표시
                        StartCoroutine(KeyDisappearsAndToast());
                    }
                }
            }
        }
    }

    // CabinetDoor를 클릭하면 특정 이미지를 표시하고 텍스트를 설정
    private void ShowSpecialImageAndText()
    {
        specialImage.gameObject.SetActive(true); // 이미지 표시
        specialText.gameObject.SetActive(true);  // 텍스트 표시

        // 텍스트 내용 설정
        specialText.text = "Pencil : "; // 기본 안내 메시지
    }

    // CabinetDoor 오브젝트를 비활성화 또는 삭제
    private void DestroyCabinetDoor()
    {
        if (cabinetDoor != null)
        {
            Destroy(cabinetDoor); // 물체 없앰
        }
    }

    // UI 요소를 비활성화
    private void HideUI()
    {
        specialImage.gameObject.SetActive(false);  // 이미지 숨기기
        specialText.gameObject.SetActive(false);   // 텍스트 숨기기
    }

    // 1초 뒤에 키를 사라지게 하고 토스트 메시지 표시하는 코루틴
    private IEnumerator KeyDisappearsAndToast()
    {
        // 1초 대기
        yield return new WaitForSeconds(1f);

        // 키를 사라지게 (비활성화 또는 삭제)
        if (keyObject != null)
        {
            Destroy(keyObject);  // 키 오브젝트 삭제
        }

        // 키를 얻었다는 토스트 메시지 표시
        toastManager.ShowToast("Key Collected!");
    }
}
