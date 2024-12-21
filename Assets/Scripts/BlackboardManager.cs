using UnityEngine;

public class BlackboardManager : MonoBehaviour
{
    public Camera playerCamera; // 플레이어의 1인칭 카메라
    public ToastManager toastManager; // ToastManager 연결
    public GameObject specialImage; // 스페셜 이미지 UI
    public bool hasEraser = false; // 지우개 소지 여부

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 마우스 클릭 감지
        {
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 5f)) // Ray 거리 제한
            {
                if (hit.collider != null && hit.collider.CompareTag("Blackboard")) // 칠판 태그 확인
                {
                    if (hasEraser)
                    {
                        // 지우개가 있을 때 스페셜 UI 표시
                        if (specialImage != null)
                        {
                            specialImage.SetActive(true); // 스페셜 이미지 활성화
                            toastManager.ShowToast("You used an eraser on the blackboard!");
                        }
                        else
                        {
                            Debug.LogError("Special Image UI is not assigned.");
                        }
                    }
                    else
                    {
                        // 지우개가 없을 때
                        toastManager.ShowToast("You need an eraser!");
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape)) // Escape 키가 눌렸을 때
        {
            HideSpecialImage(); // 이미지를 숨김
        }
    }

    // 이미지를 숨기는 메서드
    public void HideSpecialImage()
    {
        specialImage.gameObject.SetActive(false); // 이미지 숨기기
    }
}
