using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ===| 카드게임 메니저 |===
/// </summary>
public class CardGame : MonoBehaviour
{
    /// <summary>
    /// | public | ===========================
    /// </summary>
    
    public List<Card> cards;    //새로운 "카드" 리스트

    /// <summary>
    /// | private | =========================
    /// </summary>

    private Card firstCard = null;
    private Card secondCard = null;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartGame();
    }

    /// <summary>
    /// ===| 무작위 페어 넘버의 알고리즘 |===
    /// </summary>
    List<int> GeneratePairNumbers(int cardCount)
    {
        //페어 카드 넘버 생성

        int pairCount = cardCount / 2;      //예) 카드가 10개면 페어는 5짝이나옴
        List<int> newCardNumbers = new List<int>();     //빈 정수형 리스트 선언

        for(int i = 0; i < pairCount; ++i)
        {
            newCardNumbers.Add(i);        //2개씩 추가함 페어를 위함.
            newCardNumbers.Add(i);        //2개씩 추가된 newCardNumbers의 개수는 총 10개가 될거 임.
        }

        //현 newCardNumbers = [0][0][1][1][2][2][3][3][4][4]

        //셔플 알고리즘
        for (int i = newCardNumbers.Count - 1; i > 0; i--)
        {
            int rnd = Random.Range(0, i + 1);
            int temp = newCardNumbers[i];
            newCardNumbers[i] = newCardNumbers[rnd];
            newCardNumbers[rnd]  = temp;
        }

        //예)[1][0][1][0][2][4][3][3][4][2] || 뒤부터 index를 temp에 저장하고 랜덤index를 뒤 index값으로 할당후 랜덤 index는 temp로 할당함.

        return newCardNumbers;      //정수형 리스트 반환
    }

    /// <summary>
    /// ===| 카드를 클릭했을때 함수 |===
    /// </summary>
    public void OnClickCard(Card card)
    {
        if (firstCard == null)      //첫번 째가 널이 아니면 두번 째 패로 할당시키게 함.
        {
            firstCard = card;
        }
        else
        {
            secondCard = card;
        }

        if (firstCard != null && secondCard != null)        //둘다 널이 아닐경우 채크시작
        {
            CheckCard();
        }
    }

    /// <summary>
    /// ===| 게임 초기화 |===
    /// </summary>
    private void StartGame()
    {
        List<int> randomPairNumbers = GeneratePairNumbers(cards.Count); //사실상 randomPairNumbers = newCardNumbers라고 보면됨.


        for (int i = 0; i < cards.Count; ++i)
        {
            cards[i].SetCardNumber(randomPairNumbers[i]); //섞인 카드 호출 요청.
            cards[i].isFront = false;       //시작시 카드는 뒤집혀져 있는 상태로 시작.
        }
    }

    /// <summary>
    /// ===| 정답 확인 함수 |===
    /// </summary>
    private void CheckCard() //카드가 짝인지?
    {
        if(firstCard.cardNumber == secondCard.cardNumber)
        {
            //정답

            firstCard.isMatched = true;         //정답처리 (isMatched가 참이 됨)
            secondCard.isMatched = true;        //정답처리 (isMatched가 참이 됨)

            firstCard.ChangeColor(Color.green);         //정답 시 초록으로 처리 (첫번 째 패)
            secondCard.ChangeColor(Color.green);        //정답 시 초록으로 처리 (두번 째 패)

            firstCard = null;       //초기화
            secondCard = null;      //초기화
        }
        else
        {
            //다시 원래대로. 1초후 HideCard 호출.

            Invoke("HideCard", 1.0f);

        }
    }

    /// <summary>
    /// ===| 카드를 틀렸을 때 |===
    /// </summary>
    private void HideCard()
    {
        firstCard.isFront = false;
        secondCard.isFront = false;

        firstCard = null;
        secondCard = null;
    }



}
