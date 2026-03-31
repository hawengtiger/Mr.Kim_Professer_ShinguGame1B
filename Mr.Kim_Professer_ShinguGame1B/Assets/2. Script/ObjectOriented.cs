using UnityEngine;

public class ObjectOriented : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class Human
{
    public string name;
    public float height;
    public float kg;
    public int age;
    public int hp;



    public void Walk()
    {
        Debug.Log("걷기");
    }

    public void Eat()
    {
        Debug.Log("먹기");
    }

    public void Sleep()
    {
        Debug.Log("잠자기");
    }

    public void Introduce()
    {
        Debug.Log("안녕하세요 저는 " + name + "입니다.");
    }

    public void Attack(Human target)
    {
        target.hp -= 5;
    }

}
