using UnityEngine;
using TMPro;

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
    public bool isClick = false;

    /// <summary>
    /// | private | =========================
    /// </summary>
    private Quaternion flipRotation = Quaternion.Euler(0, 180f, 0);
    private Quaternion originRotation = Quaternion.Euler(0, 0, 0);


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
        if(isClick)    //만약 각도가 0보다 같거나 크거나 180보다 작고 isClick이 ture일 경우 실행됨.
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, flipRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, originRotation, rotationSpeed * Time.deltaTime);
        }

        //Time.deltaTime 드랍되는 프레임을 곱해줌으로 써 일정한 프레임을 유지하기 위한 코드.
    }

    /// <summary>
    /// ===| 카드를 클릭했을 때 |===
    /// </summary>
    public void ClickCard()
    {
        isClick = !isClick;     //클릭 유무확인 bool변수
    }

    //카드 돌리기.

    //카드

    //카드가 뒤집혔을때 유니티 특성상 뒷면은 적용이 안되게되는데. (Ignore Reversed Graphics를 비활성화)
}
