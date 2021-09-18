using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject board;//원판의 부모 객체
    public GameObject[] boardCube;//원판을 배열로 받아옴
    public TowerLeft leftTower;//왼쪽 탑의 동작 담당
    public TowerMid midTower;//중앙 탑의 동작 담당
    public TowerRight rightTower;//오른쪽 탑의 동작 담당
    public Text errorText;//에러메시지 출력
    public GameObject panel;

    public bool isLeftCheck;
    public bool isMidCheck;
    public bool isRightCheck;
    public bool isCurrentCheck;

    public Stack<int> stackLeft = new Stack<int>();
    public Stack<int> stackMid = new Stack<int>();
    public Stack<int> stackRight = new Stack<int>();

    private void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.SetResolution(1920, 1080, true);
    }

    // Start is called before the first frame update
    void Start()
    {
        isLeftCheck = false;
        isMidCheck = false;
        isRightCheck = false;
        isCurrentCheck = false;

        errorText.text = "";

        panel.SetActive(false);
        boardCube = new GameObject[board.transform.childCount];

        for (int i = board.transform.childCount; i > 0; i--)
        {
            stackLeft.Push(i);
            boardCube[i - 1] = board.transform.GetChild(i - 1).gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (stackRight.Count >= 5)
        {
            panel.SetActive(true);
            errorText.text = "끝! 축하드립니다!";
            errorText.color = Color.white;
            leftTower.GetComponent<BoxCollider>().enabled = false;
            midTower.GetComponent<BoxCollider>().enabled = false;
            rightTower.GetComponent<BoxCollider>().enabled = false;
            Time.timeScale = 0f;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    IEnumerator EmptyError()
    {
        errorText.text = "탑이 비어있습니다.";
        yield return new WaitForSeconds(1.0f);
        errorText.text = "";
    }

    IEnumerator OverflowError()
    {
        errorText.text = "큰 원판이 들어왔습니다.";
        yield return new WaitForSeconds(1.0f);
        errorText.text = "";
    }

    public void Restart()
    {
        SceneManager.LoadScene("MainGameScene");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
