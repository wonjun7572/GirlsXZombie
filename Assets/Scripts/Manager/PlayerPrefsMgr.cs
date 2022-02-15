using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsMgr : MonoBehaviour
{
    // Gold라는 스트링을 키로 지정해서 쓰겠다  변하지않을꺼니까 const사용
    private const string _GoldKey = "Gold";

    // LabMap
    private const string _LabMapKey = "Lab";

    // Map
    private const string _MapUseKey = "Map";

    public static int _gold = 0;

    public static int _lab = 0;

    public static int _map = 0;

    // Start is called before the first frame update
    void Start()
    {
        _gold = PlayerPrefs.GetInt(_GoldKey);

        _lab = PlayerPrefs.GetInt(_LabMapKey);

        _map = PlayerPrefs.GetInt(_MapUseKey);
    }

    private void OnEnable()
    {
        // 저장된걸 가져옴
        _gold = PlayerPrefs.GetInt(_GoldKey);

        _lab = PlayerPrefs.GetInt(_LabMapKey);

        _map = PlayerPrefs.GetInt(_MapUseKey);
    }

    private void OnDisable()
    {
        // 저장시킴
        PlayerPrefs.SetInt(_GoldKey, _gold);
        PlayerPrefs.SetInt(_LabMapKey, _lab);
        PlayerPrefs.SetInt(_MapUseKey, _map);
        PlayerPrefs.Save();
    }
}
