using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeTransition : MonoBehaviour
{
    public Camera playerCamera; // 플레이어의 카메라

    void Update()
    {
        // 마우스 클릭 시 씬 전환
        if (Input.GetMouseButtonDown(0)) // 왼쪽 마우스를 클릭했을 때
        {
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition); // 마우스 클릭 위치로부터 Ray 발사
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 2f)) // Raycast로 객체를 클릭했을 때
            {
                if (hit.collider.CompareTag("Escape")) // "Escape" 태그를 가진 객체를 클릭한 경우
                {
                    LoadNewScene(); // 씬 전환 함수 호출
                }
            }
        }
    }

    // 씬을 전환하는 함수
    void LoadNewScene()
    {
        SceneManager.LoadScene("GameClear"); // 전환할 씬 이름을 적어주세요
    }
}
