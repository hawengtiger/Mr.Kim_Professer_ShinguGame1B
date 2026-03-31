using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    /// <summary>
    /// 객체 지향 언어.
    /// 절차 지향 언어.
    /// C#
    /// </summary>

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        Human man = new Human();

        man.name = "신구";
        man.age = 20;
        man.height = 180.5f;
        man.kg = 70.2f;
        man.hp = 100;

        Human man2 = new Human();

        man2.name = "대학생";
        man2.age = 23;
        man2.height = 170.5f;
        man2.kg = 68.2f;
        man2.hp = 100;

        man.Introduce();
        man2.Introduce();

        man.Attack(man2);

        Debug.Log(man2.hp);


        int a = 5;
        float b;
        string c;
        bool d;

        Debug.Log(PlusMinus(10, 10, false));

/*        if(10 > a) //부등식 또는 불변수를 넣어 참또는 거짓으로 판단하여 결과값을 나타냄.
        {

        }
        else
        {
            
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int Plus(int left, int right)
    {
        return left + right;
    }
    
    int Minus(int left, int right)
    {
        return left - right;
    }

    int Multiply(int left, int right)
    {
        return left * right;
    }

    int Divide(int left, int right)
    {
        return left / right;
    }

    int PlusMinus(int left, int right, bool isPlus)
    {
        if(isPlus)
        {
            return left + right;
        }
        else
        {
            return left - right;
        }
    }
}
