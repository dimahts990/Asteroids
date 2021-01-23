using UnityEngine;

public class bordersInfoInCam : MonoBehaviour
{
    static public    bordersInfoInCam borders;
    public           float            up, down, left, right;
    [SerializeField] Transform[]      borderTrans;

    private void Start()
    {
        borders = this;
        up = borderTrans[0].position.y;
        down = borderTrans[1].position.y;
        left = borderTrans[2].position.x;
        right = borderTrans[3].position.x;
    }
}
