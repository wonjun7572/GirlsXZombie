using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 유니티 랜덤 가차 시스템
/// </summary>
public class RandomSelect : MonoBehaviour
{
    /// <summary>
    /// 카드들을 담을 리스트 생성
    /// </summary>
    public List<Card> deck = new List<Card>();
    public int total = 0;

    void Start()
    {
        for (int i = 0; i < deck.Count; i++)
        {
            // 스크립트가 활성화 되면 카드 덱의 모든 카드의 총 가중치를 구해줌
            total += deck[i].weight;
        }

        // 실행
        ResultSelect();
    }
    public List<Card> result = new List<Card>();
    public Transform parent;
    public GameObject cardprefab;

    public void ResultSelect()
    {
        for (int i = 0; i< 9; i++)
        { 
        // 가중치 랜덤을 돌리면서 결과 리스트에 넣어줌
        result.Add(RandomCard());
        // 비어 있는 카드를 생성하고
        CardUI cardUI = Instantiate(cardprefab, parent).GetComponent<CardUI>();
        // 생성 된 카드에 결과 리스트의 정보를 넣어줌
        cardUI.CardUISet(result[i]);
        }
    }

    /// <summary>
    /// 카드 클래스를 반환형으로 받는 메서드를 생성
    /// </summary>
    /// <returns></returns>
    public Card RandomCard()
    {
        int weight = 0;
        int selectNum = 0;

        selectNum = Mathf.RoundToInt(total * Random.Range(0.0f, 1.0f));

        for (int i =0; i<deck.Count;i++)
        {
            weight += deck[i].weight;
            if (selectNum <= weight)
            {
                Card temp = new Card(deck[i]);
                return temp;
            }
        }
        return null;
        // 랜덤으로 리스트에서 한장을 뽑아서 리턴해줌
        // return deck[Random.Range(0, deck.Count)];
    }

    
}
