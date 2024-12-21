using UnityEngine;
using UnityEngine.UI;

public class SinkPuzzleCtrl : MonoBehaviour
{
    public Camera playerCamera; // 플레이어의 1인칭 카메라

    // 버튼 배열 (인스펙터에서 설정)
    public Button[] buttons;

    // 이미지 배열
    public Sprite[] images;

    // 최종 이미지를 표시할 Image UI 요소
    public Image finalImage;

    // 퍼즐 UI
    public GameObject puzzleUI;

    // 클릭된 버튼들에 대한 추적
    private int[] buttonClickState;

    // 각 버튼의 현재 이미지 상태를 추적
    private Sprite[] buttonSprites;

    // 퍼즐 완료 여부 추적
    private bool isPuzzleCompleted = false;

    // 퍼즐 완성 상태를 확인할 버튼
    public Button targetButton;

    // ToastManager 연결 (토스트 메시지 표시용)
    public ToastManager toastManager;

    void Start()
    {
        // 배열 초기화
        buttonClickState = new int[buttons.Length];
        buttonSprites = new Sprite[buttons.Length];

        // 퍼즐 UI 기본 숨김
        puzzleUI.SetActive(false);
        finalImage.gameObject.SetActive(false);

        // 버튼에 클릭 이벤트 추가
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i; // 로컬 변수로 저장해야 Closure 문제 방지
            buttons[index].onClick.AddListener(() => ChangeImage(index));
        }

        // 버튼 클릭 이벤트 등록
        targetButton.onClick.AddListener(OnTargetButtonClick);
    }

     void Update()
    {
        // ESC 키로 퍼즐 UI 숨기기
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            HidePuzzleUI();
            finalImage.gameObject.SetActive(false); // 파이널 이미지 숨기기
            isPuzzleCompleted = false; // 퍼즐 완료 상태 초기화
        }

        // 마우스 클릭 시 퍼즐 UI 활성화
        if (Input.GetMouseButtonDown(0) && !isPuzzleCompleted) // 퍼즐이 완료되지 않은 경우에만
        {
            // playerCamera가 활성화된 상태인지 확인
            if (playerCamera.isActiveAndEnabled)
            {
                Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition); // 카메라에서 Ray 발사
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 5f)) // Raycast로 객체 확인
                {
                    if (hit.collider.CompareTag("Sink")) // "Sink" 태그를 가진 객체를 클릭하면
                    {
                        ShowPuzzleUI(); // 퍼즐 UI 활성화
                    }
                }
            }
        }
    }


    // 퍼즐 UI 활성화 함수
    void ShowPuzzleUI()
    {
        puzzleUI.SetActive(true);
    }

    // 이미지 변경 함수
    void ChangeImage(int buttonIndex)
    {
        // 버튼 이미지 랜덤 변경
        Image buttonImage = buttons[buttonIndex].GetComponent<Image>();
        if (buttonImage != null)
        {
            Sprite newSprite = images[Random.Range(0, images.Length)];
            buttonImage.sprite = newSprite;
            buttonSprites[buttonIndex] = newSprite; // 변경된 이미지 추적
        }

        // 버튼 클릭 상태 추적
        buttonClickState[buttonIndex] = 1;

/*        // 모든 버튼이 클릭되었는지 확인
        if (CheckSequence())
        {
            ShowFinalImage(); // 순서가 맞다면 최종 이미지 표시
            HidePuzzleUI(); // 퍼즐 UI 숨기기
            isPuzzleCompleted = true; // 퍼즐 완료 상태로 설정
        }*/
    }

    // 버튼 클릭 시 호출되는 메서드
    void OnTargetButtonClick()
    {
        if (CheckSequence())
        {
            ShowFinalImage(); // 순서가 맞다면 최종 이미지 표시
            HidePuzzleUI(); // 퍼즐 UI 숨기기
            isPuzzleCompleted = true; // 퍼즐 완료 상태로 설정
        }
        else
        {
            toastManager.ShowToast("You gave the wrong answer!"); // 틀리면 토스트 메시지 출력
        }
    }

    // 클릭된 버튼들이 순서대로 클릭되었는지 확인하는 함수
    bool CheckSequence()
    {
        if (buttonSprites[0] == images[4] && buttonSprites[1] == images[3] && buttonSprites[2] == images[1]
            && buttonSprites[3] == images[1] && buttonSprites[4] == images[2])
        {
            return true; // 버튼들이 맞는 이미지를 가지고 있으면 퍼즐 완성
        }
        return false; // 아니면 false
    }

    // 최종 이미지를 보여주는 함수
    void ShowFinalImage()
    {
        finalImage.gameObject.SetActive(true);
    }

    // 퍼즐 UI를 숨기는 함수
    void HidePuzzleUI()
    {
        puzzleUI.SetActive(false); // 퍼즐 UI 비활성화
    }
}
