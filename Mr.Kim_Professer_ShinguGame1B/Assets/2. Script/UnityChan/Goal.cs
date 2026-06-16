using UnityEngine;

public class Goal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // 골인 지점에 닿았을 때
        if (other.CompareTag("Goal"))
        {
            // 100점을 채웠는지 확인
            if (Timer.Instance.IsTargetScoreReached())
            {
                Timer.Instance.TriggerClear();
            }
            else
            {
                // 점수가 부족할 때 콘솔창에 경고 (원하면 여기에 "점수 부족" UI를 띄워도 좋습니다)
                Debug.Log("점수가 부족합니다! 100점을 채우세요.");
            }
        }

        // 죽음 타일에 닿았을 때
        if (other.CompareTag("Die"))
        {
            Timer.TriggerFail();
        }
    }
}