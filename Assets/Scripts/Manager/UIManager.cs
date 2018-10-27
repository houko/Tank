using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{

    private Text textScore;
    
    private Text textHp;
    
    private void Awake()
    {
        textScore = GameObject.Find("ScoreText").GetComponent<Text>();
        textHp = GameObject.Find("HpText").GetComponent<Text>();
    }


    private void Update()
    {
        textScore.text = Enemy.score.ToString();
        textHp.text = Player.hp.ToString();
    }
}