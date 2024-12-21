using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;  // UI �۾��� ���� ���ӽ����̽�

public class GameTimer : MonoBehaviour
{
    public Text timerText;  // Ÿ�̸� UI�� ǥ���� �ؽ�Ʈ
    public float timeLimit = 10f;  // �ð� ���� (�� ����)
    private float timeRemaining;

    void Start()
    {
        timeRemaining = timeLimit;  // Ÿ�̸� �ʱ�ȭ
    }

    void Update()
    {
        if (timeRemaining > 0f)
        {
            timeRemaining -= Time.deltaTime;  // ���� �ð����� ��Ÿ Ÿ���� ����
            DisplayTime(timeRemaining);  // Ÿ�̸� ǥ��
        }
        else
        {
            // �ð��� �� �Ǹ� ���� ���� �Ǵ� Ÿ�ӿ��� ó��
            TimeIsUp();
        }
    }

    // ���� �ð��� ��, ��, �� ���·� ǥ��
    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // �ð� �ʰ� �� ó��
    void TimeIsUp()
    {
        // ���� ���� ȭ������ ��ȯ
        Debug.Log("Time's up!");
        SceneManager.LoadScene("GameOver");
    }
}
