using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletSYS : MonoBehaviour
{
    [SerializeField] float speed=6f;

    private void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;

        if (transform.position.x > bordersInfoInCam.borders.right ||
            transform.position.x < bordersInfoInCam.borders.left ||
            transform.position.y > bordersInfoInCam.borders.up ||
            transform.position.y < bordersInfoInCam.borders.down)
            Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "asteroid")
        {
            collision.GetComponent<danger>().Die();
            Destroy(this.gameObject);
        }
    }
}
