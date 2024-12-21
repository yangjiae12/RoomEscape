using UnityEngine;
using UnityEngine.UI;

public class NoteManager : MonoBehaviour
{
    public Camera fixedCamera;      // 고정된 카메라
    public ToastManager toastManager; // ToastManager 연결 (토스트 메시지 표시용)
    public Image specialImage;      // 표시할 이미지 UI 요소
    private bool hasPencil = false; // Pencil을 소지했는지 여부

    private void Start()
    {
        // 처음에는 이미지가 보이지 않게 설정
        specialImage.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 버튼 클릭
        {
            Ray ray = fixedCamera.ScreenPointToRay(Input.mousePosition); // 고정 카메라에서 Ray 발사
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) // Ray가 물체에 맞았는지 확인
            {
                if (hit.collider.CompareTag("Pencil")) // Pencil 아이템을 클릭한 경우
                {
                    CollectPencil(hit.collider.gameObject); // Pencil 수집
                }
                else if (hit.collider.CompareTag("Note") && hasPencil) // Note를 클릭한 경우 (Pencil을 소지한 상태에서만)
                {
                    ShowSpecialImage(); // 이미지를 표시
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape)) // Escape 키가 눌렸을 때
        {
            HideSpecialImage(); // 이미지를 숨김
        }
    }

    // Pencil 아이템 수집
    private void CollectPencil(GameObject pencil)
    {
        hasPencil = true; // Pencil을 소지
        pencil.SetActive(false); // Pencil을 비활성화 (수집)
        toastManager.ShowToast("Pencil collected!"); // 토스트 메시지 표시
    }

    // Note를 클릭하면 특정 이미지를 표시
    private void ShowSpecialImage()
    {
        specialImage.gameObject.SetActive(true); // 이미지 표시
        toastManager.ShowToast("You used the pencil on the note!"); // 토스트 메시지 표시
    }

    // 이미지를 숨기는 메서드
    public void HideSpecialImage()
    {
        specialImage.gameObject.SetActive(false); // 이미지 숨기기
    }
}
