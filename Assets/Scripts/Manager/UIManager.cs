using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    private Text textScore;

    private Text textHp;

    private Image gameOver;

    private void Awake()
    {
        textScore = GameObject.Find("ScoreText").GetComponent<Text>();
        textHp = GameObject.Find("HpText").GetComponent<Text>();
//        gameOver = GameObject.Find("Image").GetComponent<Image>();
    }


    private void Update()
    {
        textScore.text = GameContext.score.ToString();
        textHp.text = GameContext.playerHp.ToString();


        if (GameContext.isGameOver)
        {
//            gameOver.GetComponent<Renderer>().enabled = true;
            Invoke("ReturnToMain", 3f);
        }
    }

    private void ReturnToMain()
    {
        SceneManager.LoadScene("Main");
        GameContext.reset();
    }
}