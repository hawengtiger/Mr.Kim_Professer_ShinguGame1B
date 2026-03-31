using System.Collections.Generic;
using UnityEngine;

public class TestArray : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 자로형 이름;
        int name = 3;




        //
        int[] arrayName = new int[10];

        //[0][1][2][3][20][][][][][]

        arrayName[0] = 10;
        arrayName[5] = 20;

        //index
        for (int i = 0; i < arrayName.Length; i++) // arrayName.Length길이만큼 접근
        {
            arrayName[i] = i;
            Debug.Log(arrayName[i]);
        }

/*        while ( 조건식 )
        {

        }*/

        List<int> testList = new List<int>(); //정수형 리스트 생성 | List<int> testList = new List<int>() {1,2,3,4 } <= 중괄호로 초기화 작업 할 수 있음.       
        testList.Add(5);
        testList.Add(10);
        testList.Add(15);

        //[5][30][15]
        testList[1] = 30;

        for (int i = 0; i < testList.Count; i++) //testList.Count 테스트의 개수를 접근
        {
            Debug.Log(testList[i]);
        }

        //

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
