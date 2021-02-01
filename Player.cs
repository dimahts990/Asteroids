using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float      speed;
    [SerializeField] GameObject bullet,bulletOut,bang;

    private void Update()
    {
        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        GetComponent<Rigidbody2D>().AddForce((dir-transform.position).normalized*speed *((Input.GetAxis("Vertical") > 0) ? Input.GetAxis("Vertical") : 0));//управление объекта
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);//управление поворотом обьекта (обьект смотрит на мышь)

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, bulletOut.transform.position, bulletOut.transform.rotation);
        }
        if (transform.position.x > 11.6f) transform.position = new Vector2(-11.6f, transform.position.y);
        if (transform.position.x < -11.6f) transform.position = new Vector2(11.6f, transform.position.y);
        if (transform.position.y > 5.6f) transform.position = new Vector2(transform.position.x, -5.6f);
        if (transform.position.y < -5.6f) transform.position = new Vector2(transform.position.x, 5.6f);
    }

    void DiePlayer()
    {
        Instantiate(bang, transform.position, Quaternion.identity);
        UI.ui.die();
        gameObject.SetActive(false);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag== "childAsteroid" || collision.transform.tag == "asteroid")
        {
            DiePlayer();
        }
    }
}
