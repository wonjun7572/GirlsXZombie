using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectBtn : MonoBehaviour
{
    /// <summary>
    /// 스위치 버튼
    /// </summary>
    //[SerializeField]
   // private GameObject switch_Button;

    /// <summary>
    /// 섀이더 관련
    /// </summary>
    Shader outline_shader;
    Shader normal_shader;
    Renderer rend;

    /// <summary>
    /// 클릭 중인 시간
    /// </summary>
    private float clickTime;

    /// <summary>
    /// 최소 클릭 시간
    /// </summary>
    public float minClickTime = 1;

    /// <summary>
    /// 클릭 중인지 판단
    /// </summary>
    private bool is_Click;

    /// <summary>
    /// 버튼 클릭했을 때
    /// </summary>
    public void ButtonClick()
    {
        // Debug.Log("오브젝트 클릭");
    }

    /// <summary>
    /// 버튼 클릭을 시작했을 때
    /// </summary>
    public void ButtonDown()
    {
        is_Click = true;

        // 쉐이더 변경
        var materials = rend.materials;
        for (int i = 0; i < materials.Length; i++)
        {
            materials[i].shader = outline_shader;
        }
    }

    /// <summary>
    /// 버튼 클릭이 끝났을 때
    /// </summary>
    public void ButtonUp()
    {
        is_Click = false;   
        
        // 클릭 중인 시간이 최소 클릭시간 이상이라면
        if(clickTime >= minClickTime)
        {
            print(clickTime);
            Debug.Log("특정 기능 수행");
        }

        // 쉐이더 변경
        var materials = rend.materials;
        for (int i = 0; i < materials.Length; i++)
        {
            materials[i].shader = normal_shader;
        }
    }

    private void Start()
    {
        rend = GetComponent<Renderer>();
        outline_shader = Shader.Find("Custom/Outline_2Pass");
        normal_shader = Shader.Find("Standard");
    }

    private void Update()
    {
        // 클릭 중이라면
        if (is_Click)
        {
            // 클릭시간 측정
            clickTime += Time.deltaTime;
        }
        else
        {
            // 클릭시간 초기화
            clickTime = 0;
        }
    }
}
