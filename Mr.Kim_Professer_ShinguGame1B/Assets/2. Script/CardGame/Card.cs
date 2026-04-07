using UnityEngine;
using TMPro;
using UnityEngine.UI;
using NUnit.Framework;

/// <summary>
/// ===| 카드 스크립트 |===
/// </summary>
public class Card : MonoBehaviour
{
    /// <summary>
    /// | public | ===========================
    /// </summary>
    
    public TextMeshProUGUI numText;
    public int cardNumber;
    public float rotationSpeed;
    public bool isFront = false;
    public bool isMatched = false;
    public CardGame cardGame;

    /// <summary>
    /// | private | =========================
    /// </summary>

    private Quaternion flipRotation = Quaternion.Euler(0, 180f, 0);
    private Quaternion originRotation = Quaternion.Euler(0, 0, 0);

    // Update is called once per frame
    void Update()
    {
        // 0 => 180 => - 180 => 0

        //==AND==OR==
        //==&&===||==
        if(isFront)    // isFront가 참이 됐으면 0도 그 외엔 180도.
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, originRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, flipRotation, rotationSpeed * Time.deltaTime);
        }

        //Time.deltaTime 드랍되는 프레임을 곱해줌으로 써 일정한 프레임을 유지하기 위한 코드.
    }

    /// <summary>
    /// ===| 카드를 클릭했을 때 |===
    /// </summary>
    public void ClickCard()
    {
        if(!isMatched) //짝이 아니면 계속 뒤집을 수 있게 설정
        {
            isFront = !isFront;     //클릭 유무확인 bool변수
            cardGame.OnClickCard(this);
        }
    }

    //카드 돌리기.

    /// <summary>
    /// ===| 카드 설정 함수 |===
    /// </summary>
    public void SetCardNumber(int newNumber)        //newNumber는 섞인 카드 
    {
        numText = GetComponentInChildren<TextMeshProUGUI>(); //일일히 대입하기 귀찮으니 자식TMP들을 numText변수에 대입함. (= 가져오게 함)

        cardNumber = newNumber;     //섞인카드를 출력

        numText.text = cardNumber.ToString(); //ToString을 쓰는 이유는 정수값을 문자형으로 바꾸기 위함.
    }

    /// <summary>
    /// ===| 카드 색깔 바꾸는 함수 |===
    /// </summary>
    public void ChangeColor(Color newColor)
    {
        GetComponent<Image>().color = newColor;         //Image컴포넌트의 색을 newColor값으로 바꿈
    }
    

    //카드

    //카드가 뒤집혔을때 유니티 특성상 뒷면은 적용이 안되게되는데. (Ignore Reversed Graphics를 비활성화)
}
