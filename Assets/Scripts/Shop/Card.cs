using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 열거형을 사용하여 카드의 등급 분류
/// </summary>
public enum CardGrade { S,A,B,C,D }

// 직렬화
[System.Serializable]
public class Card
{
    public string cardName;
    public Sprite cardImage;
    public CardGrade cardGrade;
    public Font cardFont;
    // 가중치 랜덤을 적용하기 위해 선언, 클수록 확률이 높음
    public int weight;

    /// <summary>
    /// 생성자에는 매개변수로 카드 클래스를 받아서 현재 카드 클래스를 초기화 해줌
    /// </summary>
    /// <param name="card"></param>
    public Card(Card card)
    {
        this.cardName = card.cardName;
        this.cardImage = card.cardImage;
        this.cardGrade = card.cardGrade;
        this.cardFont = card.cardFont;
        this.weight = card.weight;
    }
}
