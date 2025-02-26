using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    [SerializeField] TMP_Text scoreboardText;
    
    int score = 0;

    public void IncreaseScore(int amount)
    { 
        score += amount;

        if (score < 1000)
        {
            scoreboardText.text = "000" + score.ToString();
        }

        else if (score >= 1000 && score < 10000)
        {
            scoreboardText.text = "00" + score.ToString();
        }

        else if (score >= 10000 && score < 100000)
        {
            scoreboardText.text = "0" + score.ToString();
        }

        else if(score >= 100000)
        {
            scoreboardText.text = score.ToString();
        }
        
    }
}
