using System.Collections;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public Camera playerCamera; // 플레이어의 1인칭 카메라
    public ToastManager toastManager; // ToastManager 연결
    public bool hasKey = false; // 키를 소지하고 있는지 여부

    private void Update()
    {
        // 마우스 왼쪽 버튼 클릭한 상태에서만 Raycast 실행
        if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 버튼 클릭
        {
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition); // 카메라에서 Ray 발사
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 5f)) // Raycast가 오브젝트에 맞았는지 확인
            {
                if (hit.collider.CompareTag("Door")) // 문을 클릭한 경우
                {
                    DoorCtrl door = hit.collider.GetComponent<DoorCtrl>(); // 문인지 확인
                    if (door != null)
                    {
                        // 열쇠가 있으면 문 열기/닫기
                        if (hasKey)
                        {
                            door.ToggleDoor(); // 문 열기/닫기
                        }
                        else
                        {
                            toastManager.ShowToast("You need a key to open this door!"); // 열쇠가 없으면 토스트 메시지 출력
                        }
                    }
                }
            }
        }
    }

    // 키를 설정하는 메서드
    public void SetHasKey(bool value)
    {
        hasKey = value;
    }
}
