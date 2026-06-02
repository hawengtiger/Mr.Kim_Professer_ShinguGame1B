using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 0.03f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        /*for (int i = 0; i < 10; i++)
        {
            Debug.Log(i);
        }*/

        int i = 0;

        while (i < 10)
        {
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.forward * speed *Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.back * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
    }
}
