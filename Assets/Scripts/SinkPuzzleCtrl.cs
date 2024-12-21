using UnityEngine;
using UnityEngine.UI;

public class SinkPuzzleCtrl : MonoBehaviour
{
    public Camera playerCamera; // �÷��̾��� 1��Ī ī�޶�

    // ��ư �迭 (�ν����Ϳ��� ����)
    public Button[] buttons;

    // �̹��� �迭
    public Sprite[] images;

    // ���� �̹����� ǥ���� Image UI ���
    public Image finalImage;

    // ���� UI
    public GameObject puzzleUI;

    // Ŭ���� ��ư�鿡 ���� ����
    private int[] buttonClickState;

    // �� ��ư�� ���� �̹��� ���¸� ����
    private Sprite[] buttonSprites;

    // ���� �Ϸ� ���� ����
    private bool isPuzzleCompleted = false;

    // ���� �ϼ� ���¸� Ȯ���� ��ư
    public Button targetButton;

    // ToastManager ���� (�佺Ʈ �޽��� ǥ�ÿ�)
    public ToastManager toastManager;

    void Start()
    {
        // �迭 �ʱ�ȭ
        buttonClickState = new int[buttons.Length];
        buttonSprites = new Sprite[buttons.Length];

        // ���� UI �⺻ ����
        puzzleUI.SetActive(false);
        finalImage.gameObject.SetActive(false);

        // ��ư�� Ŭ�� �̺�Ʈ �߰�
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i; // ���� ������ �����ؾ� Closure ���� ����
            buttons[index].onClick.AddListener(() => ChangeImage(index));
        }

        // ��ư Ŭ�� �̺�Ʈ ���
        targetButton.onClick.AddListener(OnTargetButtonClick);
    }

     void Update()
    {
        // ESC Ű�� ���� UI �����
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            HidePuzzleUI();
            finalImage.gameObject.SetActive(false); // ���̳� �̹��� �����
            isPuzzleCompleted = false; // ���� �Ϸ� ���� �ʱ�ȭ
        }

        // ���콺 Ŭ�� �� ���� UI Ȱ��ȭ
        if (Input.GetMouseButtonDown(0) && !isPuzzleCompleted) // ������ �Ϸ���� ���� ��쿡��
        {
            // playerCamera�� Ȱ��ȭ�� �������� Ȯ��
            if (playerCamera.isActiveAndEnabled)
            {
                Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition); // ī�޶󿡼� Ray �߻�
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 5f)) // Raycast�� ��ü Ȯ��
                {
                    if (hit.collider.CompareTag("Sink")) // "Sink" �±׸� ���� ��ü�� Ŭ���ϸ�
                    {
                        ShowPuzzleUI(); // ���� UI Ȱ��ȭ
                    }
                }
            }
        }
    }


    // ���� UI Ȱ��ȭ �Լ�
    void ShowPuzzleUI()
    {
        puzzleUI.SetActive(true);
    }

    // �̹��� ���� �Լ�
    void ChangeImage(int buttonIndex)
    {
        // ��ư �̹��� ���� ����
        Image buttonImage = buttons[buttonIndex].GetComponent<Image>();
        if (buttonImage != null)
        {
            Sprite newSprite = images[Random.Range(0, images.Length)];
            buttonImage.sprite = newSprite;
            buttonSprites[buttonIndex] = newSprite; // ����� �̹��� ����
        }

        // ��ư Ŭ�� ���� ����
        buttonClickState[buttonIndex] = 1;

/*        // ��� ��ư�� Ŭ���Ǿ����� Ȯ��
        if (CheckSequence())
        {
            ShowFinalImage(); // ������ �´ٸ� ���� �̹��� ǥ��
            HidePuzzleUI(); // ���� UI �����
            isPuzzleCompleted = true; // ���� �Ϸ� ���·� ����
        }*/
    }

    // ��ư Ŭ�� �� ȣ��Ǵ� �޼���
    void OnTargetButtonClick()
    {
        if (CheckSequence())
        {
            ShowFinalImage(); // ������ �´ٸ� ���� �̹��� ǥ��
            HidePuzzleUI(); // ���� UI �����
            isPuzzleCompleted = true; // ���� �Ϸ� ���·� ����
        }
        else
        {
            toastManager.ShowToast("You gave the wrong answer!"); // Ʋ���� �佺Ʈ �޽��� ���
        }
    }

    // Ŭ���� ��ư���� ������� Ŭ���Ǿ����� Ȯ���ϴ� �Լ�
    bool CheckSequence()
    {
        if (buttonSprites[0] == images[4] && buttonSprites[1] == images[3] && buttonSprites[2] == images[1]
            && buttonSprites[3] == images[1] && buttonSprites[4] == images[2])
        {
            return true; // ��ư���� �´� �̹����� ������ ������ ���� �ϼ�
        }
        return false; // �ƴϸ� false
    }

    // ���� �̹����� �����ִ� �Լ�
    void ShowFinalImage()
    {
        finalImage.gameObject.SetActive(true);
    }

    // ���� UI�� ����� �Լ�
    void HidePuzzleUI()
    {
        puzzleUI.SetActive(false); // ���� UI ��Ȱ��ȭ
    }
}
