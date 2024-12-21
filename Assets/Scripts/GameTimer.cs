using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;  // UI 작업을 위한 네임스페이스

public class GameTimer : MonoBehaviour
{
    public Text timerText;  // 타이머 UI를 표시할 텍스트
    public float timeLimit = 10f;  // 시간 제한 (초 단위)
    private float timeRemaining;

    void Start()
    {
        timeRemaining = timeLimit;  // 타이머 초기화
    }

    void Update()
    {
        if (timeRemaining > 0f)
        {
            timeRemaining -= Time.deltaTime;  // 남은 시간에서 델타 타임을 빼기
            DisplayTime(timeRemaining);  // 타이머 표시
        }
        else
        {
            // 시간이 다 되면 게임 종료 또는 타임오버 처리
            TimeIsUp();
        }
    }

    // 남은 시간을 시, 분, 초 형태로 표시
    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // 시간 초과 시 처리
    void TimeIsUp()
    {
        // 게임 오버 화면으로 전환
        Debug.Log("Time's up!");
        SceneManager.LoadScene("GameOver");
    }
}
