using UnityEngine;

public class EraserItem : MonoBehaviour
{
    public Camera playerCamera; // 플레이어의 1인칭 카메라
    public BlackboardManager blackboardManager; // BlackboardManager 스크립트를 참조
    public ToastManager toastManager; // ToastManager 연결

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 마우스 클릭 감지
        {
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition); // 카메라에서 Ray 발사
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 5f)) // Ray 거리 제한
            {
                if (hit.collider.CompareTag("Eraser")) // Eraser 태그 확인
                {
                    if (blackboardManager != null)
                    {
                        blackboardManager.hasEraser = true; // 지우개 상태 저장
                    }
                    else
                    {
                        Debug.LogError("BlackboardManager is not assigned.");
                    }

                    gameObject.SetActive(false); // 지우개 비활성화

                    if (toastManager != null)
                    {
                        toastManager.ShowToast("Eraser collected!"); // 토스트 메시지 표시
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
