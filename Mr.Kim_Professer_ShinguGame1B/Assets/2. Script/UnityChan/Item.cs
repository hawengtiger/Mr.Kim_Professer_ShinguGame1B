using UnityEngine;

public class Item : MonoBehaviour
{

    [SerializeField] private int scoreValue = 10; // 이 아이템을 먹으면 오를 점수

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // Timer 스크립트에 점수 추가 요청
        Timer.Instance.AddScore(scoreValue);

        SoundManager.instance.PlaySound(); // 아이템 먹는 효과음 재생

        // 먹은 아이템은 파괴
        Destroy(gameObject);
    }
}
