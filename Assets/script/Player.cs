using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float      speed;
    [SerializeField] GameObject bullet,bulletOut;

    private void Update()
    {
        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        GetComponent<Rigidbody2D>().AddForce((dir-transform.position).normalized*speed *((Input.GetAxis("Vertical") > 0) ? Input.GetAxis("Vertical") : 0));//управление объекта
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);//управление поворотом обьекта (обьект смотрит на мышь)

        if (Input.GetMouseButton(0))
        {
            Instantiate(bullet, bulletOut.transform.position, bulletOut.transform.rotation);
        }
    }
}
