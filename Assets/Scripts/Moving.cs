using UnityEngine;

public class Moving : MonoBehaviour
{
    bool move;
    int _x2, _y2;

    void Update()
    {
        if(move == true)
        {
            Move(_x2, _y2);
        }
    }

    public void Move(int x2,int y2)
    {
       move = true; _x2 = x2; _y2 = y2;
       transform.position = Vector3.MoveTowards(transform.position, new Vector3(9.0f + 5.0f * x2, 2.0f , -11.0f + 5.0f * y2), 0.3f);
        // 움직여라 움직여!! 여기 코드는 moving스크립트를 큐브에 넣어주므로써 바로 transform.position 사용한거~

        if(transform.position == new Vector3(9.0f + 5.0f * x2, 2.0f, -11.0f + 5.0f * y2))
        {
            move = false; // 이거는 그 move가 false 가 되면 못움직인다는 소리가 되고 못움직이게 되면 스폰하려고 만들어둔 bool 함수야
        }
    }
}
