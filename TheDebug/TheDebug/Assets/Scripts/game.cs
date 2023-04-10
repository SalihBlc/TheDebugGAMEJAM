using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float Xrange = 10f;
    [SerializeField] float Zdestroy = -10f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        float MovementX = inputHorizontal * speed * Time.deltaTime;
        float XnewPos = Mathf.Clamp(transform.position.x + MovementX, -Xrange, Xrange);
        transform.position = new Vector2(XnewPos, transform.position.y);


        if (transform.position.y < Zdestroy)
        {
            //Destroy(gameObject);
        }
    }

}
