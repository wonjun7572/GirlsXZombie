using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCountUI : MonoBehaviour
{
    public Text currentEnemyCountText;

    // Update is called once per frame
    void Update()
    {
        currentEnemyCountText.text = Spawner.Instance.EnemyCurrentCountNum + "";
    }
}
