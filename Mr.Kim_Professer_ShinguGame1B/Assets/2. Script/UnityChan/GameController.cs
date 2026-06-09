using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    
    public TextMeshProUGUI scoreText;

    public GameObject clearText;

    private float currentScore = 0f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(float value)
    {
        currentScore += value;

        scoreText.text = "Score : " + currentScore.ToString();
    }
    
    public void GameClear()
    {
        clearText.SetActive(true);
    }
}
