using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombineSwitch : MonoBehaviour
{
    [SerializeField]
    GameObject m_switchPrefab = null;

    /// <summary>
    /// 캐릭터의 위치를 담을 리스트 선언
    /// </summary>
    List<Transform> m_objectList = new List<Transform>();

    /// <summary>
    /// 스위치의 리스트 선언
    /// </summary>
    List<GameObject> m_switchList = new List<GameObject>();

    /// <summary>
    /// 카메라 선언
    /// </summary>
    Camera m_cam = null;

    // Start is called before the first frame update
    void Start()
    {
        // 메인카메라를 해당 변수에 넣어줌
        m_cam = Camera.main;

        // 배열에 태그가 포함된 객체들을 저장하여 그 갯수만큼 배열의 리스트에 추가해줌
        GameObject[] t_objects = GameObject.FindGameObjectsWithTag("TilePrefab");

        for(int i =0; i < t_objects.Length; i++)
        {
            m_objectList.Add(t_objects[i].transform);

            // 캐릭터의 위치에 스위치를 생성시켜줌
            GameObject t_switch = Instantiate(m_switchPrefab, t_objects[i].transform.position, Quaternion.identity, transform);
            // 생성된 객체를 switch 리스트에도 추가해줌
            m_switchList.Add(t_switch);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // switch가 캐릭터의 머리 위에 계속 따라다니며 떠다니게 설정
        for(int i = 0; i < m_objectList.Count; i++)
        {
            // 머리위에 떠다닐 수 있도록 Y값을 1정도 추가
            m_switchList[i].transform.position = m_cam.WorldToScreenPoint(m_objectList[i].position + new Vector3(0, 1.0f));
        }
    }
}
