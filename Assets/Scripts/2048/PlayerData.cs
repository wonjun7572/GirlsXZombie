using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Player data. used to save player score. we serialize it in order to keep punctuation from match to match.
/// </summary>
[System.Serializable]
public class PlayerData 
{
	public List<ScoreAmount> scores;
	//public List<EnemyAmount> enemys;
	
	public PlayerData()
	{
		scores = new List<ScoreAmount>();		
	}

    //public PlayerData()
    //   {
    //	enemys = new List<EnemyAmount>();
    //   }

    public void AddScore(int index, float amount)
    {
        if (scores.Count > index)
        {
            if (scores[index].amount < amount)
            {
                scores[index].amount = amount;
                //GooglePlayManager.instance.SubmitScore("leaderboard_all", (long)amount);
            }

        }
        else
        {
            ScoreAmount sam = new ScoreAmount();
            sam.index = index;
            sam.amount = amount;

            scores.Insert(index, sam);
        }
    }
  //  public void GameOverScore(int amount)
  //  {
		//if (enemys.Count > amount)
  //      {

  //      }
  //  }
}

[System.Serializable]
public class ScoreAmount
{
    public int index;
    public float amount;

}

//public class EnemyAmount
//{
//	public int amount;
//}