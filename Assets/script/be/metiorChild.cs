using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class metiorChild : MonoBehaviour
{
    [SerializeField] float      speed = 20f;
    [SerializeField] GameObject bang;

    private void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;

        if (transform.position.x > bordersInfoInCam.borders.right ||
            transform.position.x < bordersInfoInCam.borders.left ||
            transform.position.y > bordersInfoInCam.borders.up ||
            transform.position.y < bordersInfoInCam.borders.down)
            Destroy(this.gameObject);
    }
    public void Die()//вызывается когда в астероид попали
    {
        Instantiate(bang, transform.position, Quaternion.identity);
        UI.ui.ShotMetior();
        Destroy(this.gameObject);
    }
}
