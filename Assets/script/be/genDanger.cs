using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class genDanger : MonoBehaviour
{
    [SerializeField] GameObject[] danger;
    [SerializeField] float        timerSpawn=5f;

    void Start()
    {
        float up    = bordersInfoInCam.borders.up;
        float down  = bordersInfoInCam.borders.down;
        float left  = bordersInfoInCam.borders.left;
        float right = bordersInfoInCam.borders.right;

        StartCoroutine(Gen(up,down,left,right));
    }
    
    private IEnumerator Gen(float up, float down, float left,float right)
    {
        while (1 > 0)
        {
            switch (Random.Range(0, 4))
            {
                case 0://генерация сверху
                    Instantiate(danger[Random.Range(0, danger.Length)],
                        new Vector2(Random.Range(left, right), up),
                        Quaternion.identity).GetComponent<danger>().rotation = 0;
                    break;
                case 1://генерация снизу
                    Instantiate(danger[Random.Range(0, danger.Length)],
                        new Vector2(Random.Range(left, right), down),
                        Quaternion.identity).GetComponent<danger>().rotation = 1;
                    break;
                case 2://генерация слева
                    Instantiate(danger[Random.Range(0, danger.Length)],
                        new Vector2(left, Random.Range(up, down)),
                        Quaternion.identity).GetComponent<danger>().rotation = 2;
                    break;
                case 3://генерация справа
                    Instantiate(danger[Random.Range(0, danger.Length)],
                        new Vector2(right, Random.Range(up, down)),
                        Quaternion.identity).GetComponent<danger>().rotation = 3;
                    break;
            }

            yield return new WaitForSeconds(timerSpawn);
        }
    }
}
