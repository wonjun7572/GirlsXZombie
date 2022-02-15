using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindCharacterValue : MonoBehaviour
{
    private static FindCharacterValue instance;
    public static FindCharacterValue Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public int CharacterValue = 0;

    public void SetCharacterValue()
    {

        // 태그 탐색
        var d1 = GameObject.FindWithTag("D1");
        var d2 = GameObject.FindWithTag("D2");
        var c1 = GameObject.FindWithTag("C1");
        var c2 = GameObject.FindWithTag("C2");
        var b1 = GameObject.FindWithTag("B1");
        var b2 = GameObject.FindWithTag("B2");
        var a1 = GameObject.FindWithTag("A1");
        var a2 = GameObject.FindWithTag("A2");
        var s1 = GameObject.FindWithTag("S1");
        var s2 = GameObject.FindWithTag("S2");

        // 태그 탐색에 s2가 있다면, CharacterValue 를 10으로
        if (s2 != null)
        {
            CharacterValue = 10;
        }

        // 태그 탐색에 s2는 없지만 s1이 있다면, CharacterValue를 9로 ... 
        else if (s1 != null && s2 == null)
        {
            CharacterValue = 9;
        }

        else if (a2 != null && s1 == null && s2 == null)
        {
            CharacterValue = 8;
        }

        else if (a1 != null && a2 == null && s1 == null && s2 == null)
        {
            CharacterValue = 7;
        }

        else if (b2 != null && a1 == null && a2 == null && s1 == null && s2 == null)
        {
            CharacterValue = 6;
        }

        else if (b1 != null && b2 == null && a1 == null && a2 == null && s1 == null && s2 == null)
        {
            CharacterValue = 5;
        }

        else if (c2 != null && b1 == null && b2 == null && a1 == null && a2 == null && s1 == null && s2 == null)
        {
            CharacterValue = 4;
        }

        else if (c1 != null && c2 == null && b1 == null && b2 == null && a1 == null && a2 == null && s1 == null && s2 == null)
        {
            CharacterValue = 3;
        }

        else if (d2 != null && c1 == null && c2 == null && b1 == null && b2 == null && a1 == null && a2 == null && s1 == null && s2 == null)
        {
            CharacterValue = 2;
        }

        else if (d1 != null && d2 == null && c1 == null && c2 == null && b1 == null && b2 == null && a1 == null && a2 == null && s1 == null && s2 == null)
        {
            CharacterValue = 1;
        }


        // 아비게일 D등급 1성이면
        // D1 tag를 찾아서, 그 값을 d1 << 1로 지정
        // D2 tag d2 << 2로지정
        // c b a s 
        // 제일 높은 s2가 10
        // 캐릭터마다 벨류값이 정해지므로, 그 중에서 제일높은 벨류값을 가진 캐릭터의 이미지를 출력시키면 된다.

        if (CharacterValue == 10)
        {
            ShowResult.Instance.Show_S_2();
            CharacterValue = 0;
        }

        else if (CharacterValue == 9)
        {
            ShowResult.Instance.Show_S_1();
            CharacterValue = 0;
        }

        else if (CharacterValue == 8)
        {
            ShowResult.Instance.Show_A_2();
            CharacterValue = 0;
        }

        else if (CharacterValue == 7)
        {
            ShowResult.Instance.Show_A_1();
            CharacterValue = 0;
        }

        else if (CharacterValue == 6)
        {
            ShowResult.Instance.Show_B_2();
            CharacterValue = 0;
        }

        else if (CharacterValue == 5)
        {
            ShowResult.Instance.Show_B_1();
            CharacterValue = 0;
        }
        else if (CharacterValue == 4)
        {
            ShowResult.Instance.Show_C_2();
            CharacterValue = 0;
        }

        else if (CharacterValue == 3)
        {
            ShowResult.Instance.Show_C_1();
            CharacterValue = 0;
        }

        else if (CharacterValue == 2)
        {
            ShowResult.Instance.Show_D_2();
            CharacterValue = 0;
        }

        else if (CharacterValue == 1)
        {
            ShowResult.Instance.Show_D_1();
            CharacterValue = 0;
        }

    }
}
