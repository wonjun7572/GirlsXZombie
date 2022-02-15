using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] prefabArray;

    bool wait ,move;

    int x, y, z,i;

    Vector3 firstPos, gap;

    private int objectSpawnCount = 1; // 버튼 누를때마다 생성개수

    GameObject[,] Square = new GameObject[4,4];

    public Transform[] spawnPointArray;

    private void Awake()
    {
        Spawn();
        //Spawn();
    }

    public void Spawn()
    {
        while(true)
        {
            x = Random.Range(0, 4);
            y = Random.Range(0, 4);
            if(Square[x,y] == null)
            {
                break;
            }
        }
        Square[x,y]= Instantiate(prefabArray[0], new Vector3(9.0f + 5.0f *x, 2.0f, -11.0f +5.0f*z), Quaternion.identity);
        //애니메이션 자리 넣는곳 (스폰시) getcomponent<Animator> 활용한다.
    }

    public void Update()
    {
        // 문지름
        if (Input.GetMouseButtonDown(0) || (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            wait = true;
            firstPos = Input.GetMouseButtonDown(0) ? Input.mousePosition : (Vector3)Input.GetTouch(0).position;
        }

        if (Input.GetMouseButton(0) || (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved))
        {
            gap = (Input.GetMouseButton(0) ? Input.mousePosition : (Vector3)Input.GetTouch(0).position) - firstPos;
            if (gap.magnitude < 100) return;
            gap.Normalize();
            // 스와이프는 정말 완벽하게 되고잇음!!
            if (wait)
            {
                wait = false;
                // 위
                if (gap.y > 0 && gap.x > -0.5f && gap.x < 0.5f) for (x = 0; x <= 3; x++) for (y = 0; y <= 2; y++) for (i = 3; i >= y + 1; i--) MoveOrCombine(x, i - 1, x, i);
                // 아래
                else if (gap.y < 0 && gap.x > -0.5f && gap.x < 0.5f) for (x = 0; x <= 3; x++) for (y = 3; y >= 1; y--) for (i = 0; i <= y - 1; i++) MoveOrCombine(x, i + 1, x, i);
                // 오른쪽
                else if (gap.x > 0 && gap.y > -0.5f && gap.y < 0.5f) for (y = 0; y <= 3; y++) for (y = 0; y <= 2; y++) for (i = 3; i >= x + 1; i--) MoveOrCombine(i - 1, y, i, y);
                // 왼쪽
                else if (gap.x < 0 && gap.y > -0.5f && gap.y < 0.5f) for (y = 0; y <= 3; y++) for (x = 3; x >= 1; x--) for (i = 0; i <= x - 1; i++) MoveOrCombine(i + 1, y, i, y);

                //좌표가 이상한지 움직이기는 하는데 좀 이상함 이게 vector3 인데 2차행렬을 사용해서 그런가..?

                else return;

                if (move == true)
                {
                    move = false;
                    //Spawn();
                }
            }
        }
    }
    //[x1,y1]은 이동 전 좌표 ,2는 이동 될 좌표
    public void MoveOrCombine(int x1, int x2, int y1, int y2)
    {
        if(Square[x2,y2] ==null && Square[x1,y1] !=null) //이동 후 좌표는 비어있어야하고 이동 전 좌표는 차있어야함
        {
            move = true;
            Square[x1, y1].GetComponent<Moving>().Move(x2, y2); // 부드럽게 만드려고 moving스크립트 하나 생성한 다음에 거기다가 넣어준거야 왜냐하면 update에 넣어야하는데 못넣어서 스크립트 만들어준거얌
            Square[x2, y2] = Square[x1, y1];
            Square[x1, y1] = null;// 좆같다 죽고싶다.. 왜 안될까 비어져있는 자리를 null로 표현했는데 왜 계속 거기도 차있다고 생성이 안될까? 
        }
    }


    public void OnClickSpawnBtn()
    {
        // 덱을 구성할 때 생성되어있지 않는 위치들만 뽑아서 덱을 구성
        // 이렇게 하고 덱 셔플 때리고
        // 맨위에 있는거 하나 뽑아서 쓰면 됨.
        var deck = new List<int>();
        for (int i = 0; i < spawnPointArray.Length; i++)
        {
            if (spawnPointArray[i].childCount == 0)
            {
                deck.Add(i);
            }
        }
        if (deck.Count == 0)
            return;

        ShuffleList<int>(deck);
        var Index = deck.First();
        int prefabIndex = Random.Range(0, prefabArray.Length);

        Vector3 position = new Vector3(spawnPointArray[Index].position.x, 2.0f, spawnPointArray[Index].position.z); //x,z 랜덤 y는 고정

        GameObject clone = Instantiate(prefabArray[prefabIndex], position, Quaternion.identity); // clone 생성 
        clone.transform.parent = spawnPointArray[Index];

        for (int i = 0; i < objectSpawnCount; ++i)
        {

        }
    }

    public static void ShuffleList<T>(List<T> list)
    {
        int random1;
        int random2;

        T tmp;

        for (int index = 0; index < list.Count; ++index)
        {
            random1 = UnityEngine.Random.Range(0, list.Count);
            random2 = UnityEngine.Random.Range(0, list.Count);

            tmp = list[random1];
            list[random1] = list[random2];
            list[random2] = tmp;
        }
    }
}
