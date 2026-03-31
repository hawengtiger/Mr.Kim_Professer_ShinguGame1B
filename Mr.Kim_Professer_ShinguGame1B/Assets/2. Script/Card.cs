using UnityEngine;
using TMPro;

public class Card : MonoBehaviour
{
    public TextMeshProUGUI numText;
    public int cardNumber;
    public float rotationSpeed;

    //변수
    //정보

    //함수

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        numText = GetComponentInChildren<TextMeshProUGUI>(); //일일히 대입하기 귀찮으니 자식TMP들을 numText변수에 대입함. (= 가져오게 함)

        cardNumber = Random.Range(0, 10);

        numText.text = cardNumber.ToString(); //ToString을 쓰는 이유는 정수값을 문자형으로 바꾸기 위함.
    }

    // Update is called once per frame
    void Update()
    {
        // 0 => 180 => - 180 => 0

        //==AND==OR==
        //==&&===||==
        if(transform.eulerAngles.y >= 0 && transform.eulerAngles.y < 180)
        {
            transform.Rotate(0, rotationSpeed, 0);
        }
    }

    //카드 돌리기.

    //카드


}
