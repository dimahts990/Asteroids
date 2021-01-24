using UnityEngine;

public class danger : MonoBehaviour
{
    [SerializeField] float        speed = 20f;
    [SerializeField] GameObject[] childMetior;
    [SerializeField] GameObject   bang;
    public           int          rotation;


    private void Start()
    {
        switch (rotation)
        {
            case 0://полетит свреху
                transform.rotation = Quaternion.Euler(0, 0, Random.Range(105, 255));
                break;
            case 1://полетит снизу
                transform.rotation = Quaternion.Euler(0, 0, Random.Range(-75, 75));
                break;
            case 2://полетит слева
                transform.rotation = Quaternion.Euler(0, 0, Random.Range(-165, -15));
                break;
            case 3://полетит справа
                transform.rotation = Quaternion.Euler(0, 0, Random.Range(15, 165));
                break;
        }
    }

    void Update()
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
        //создаем 2 префаба метиорита
        for(int i = 0; i < 2; i++)
        {
            Instantiate(childMetior[Random.Range(0,childMetior.Length)], transform.position, Quaternion.Euler(0,0,Random.Range(0,361)));
        }
        Instantiate(bang, transform.position, Quaternion.identity);
        UI.ui.ShotMetior();
        Destroy(this.gameObject);
    }
}
