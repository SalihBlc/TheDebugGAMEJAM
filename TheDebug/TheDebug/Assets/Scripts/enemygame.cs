using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemygame : MonoBehaviour
{
    [SerializeField] float enemySpeed = 5f;
    public float enemyXrange = 6f;
    public float enemyZdestroy = 10f;
    [SerializeField] float minumumRot = -45f;
    [SerializeField] float maximumRot = 45f;

    private Rigidbody2D enemyRb;
    private float rotation;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        enemyRb.gravityScale = 0f;

        //rastgele dönüş açısı oluşturmak için
        rotation = Random.Range(minumumRot, maximumRot);


        //Yön ve Hızı ayarlama
        Vector2 direction = new Vector2(rotation, 2f).normalized;
        enemyRb.velocity = direction * enemySpeed;
    }
    void Update()
    {
        transform.Translate(Vector2.up * enemySpeed * Time.deltaTime);
        if (transform.position.y > enemyZdestroy)
        {
            //Destroy(gameObject);
        }
    }


}
