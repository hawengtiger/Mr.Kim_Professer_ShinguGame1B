using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;

public class Timer : MonoBehaviour
{
    public static Timer Instance { get; private set; }

    [Header("타이머 설정")]
    [SerializeField] private float limitTime = 60.0f;
    [SerializeField] private TextMeshProUGUI timerText;

    [Header("점수 설정")]
    [SerializeField] private int targetScore = 100;     // 목표 점수 (100점)
    [SerializeField] private TextMeshProUGUI scoreText; // 점수를 표시할 TMP 텍스트
    private int currentScore = 0;                       // 현재 점수

    [Header("클리어 UI 설정")]
    [SerializeField] private GameObject clearPanel;
    [SerializeField] private CanvasGroup panelCanvasGroup;
    [SerializeField] private Transform panelContent;

    private bool isGameOver = false;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        SoundManager.instance.PlayBGMSound();

        if (clearPanel != null) clearPanel.SetActive(false);
        Time.timeScale = 1f;

        // 시작할 때 점수 텍스트 초기화
        UpdateScoreText();
    }

    void Update()
    {
        if (isGameOver) return;

        if (limitTime > 0)
        {
            limitTime -= Time.deltaTime;
            if (timerText != null)
            {
                timerText.text = "Time: " + limitTime.ToString("F1");
            }
        }
        else
        {
            limitTime = 0;
            TriggerFail();
        }
    }

    // [점수 추가 함수] 외부 아이템이나 몬스터 처치 시 이 함수를 호출해 점수를 올립니다.
    public void AddScore(int amount)
    {
        if (isGameOver) return;

        currentScore += amount;
        UpdateScoreText();

        // 야무진 연출: 점수가 오를 때 텍스트가 살짝 커졌다 작아지는 DOTween 효과
        if (scoreText != null)
        {
            scoreText.transform.DOKill(); // 기존 애니메이션 중복 방지
            scoreText.transform.localScale = Vector3.one; // 크기 초기화
            scoreText.transform.DOScale(1.2f, 0.1f).OnComplete(() =>
            {
                scoreText.transform.DOScale(1.0f, 0.1f);
            });
        }
    }

    // 점수 텍스트 업데이트
    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = $"Score: {currentScore} / {targetScore}";
        }
    }

    // 골인 지점에서 100점이 넘었는지 체크하는 헬퍼 함수
    public bool IsTargetScoreReached()
    {
        return currentScore >= targetScore;
    }

    public static void TriggerFail()
    {
        SceneManager.LoadScene("GameOverScene");
    }

    public void TriggerClear()
    {
        if (isGameOver) return;
        isGameOver = true;

        if (clearPanel != null)
        {
            clearPanel.SetActive(true);

            if (panelContent != null)
            {
                panelContent.localScale = Vector3.zero;
                panelContent.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack).SetUpdate(true);
            }

            if (panelCanvasGroup != null)
            {
                panelCanvasGroup.alpha = 0f;
                panelCanvasGroup.DOFade(1f, 0.3f).SetUpdate(true);
            }
        }

        Time.timeScale = 0f;
    }
}