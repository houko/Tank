using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    private Text textScore;

    private Text textHp;

    private GameObject gameOver;

    private void Awake()
    {
        textScore = GameObject.Find("ScoreText").GetComponent<Text>();
        textHp = GameObject.Find("HpText").GetComponent<Text>();
        gameOver = transform.Find("Image").gameObject;
    }


    private void Update()
    {
        textScore.text = GameContext.score.ToString();
        textHp.text = GameContext.playerHp.ToString();


        if (GameContext.isGameOver)
        {
            gameOver.SetActive(true);
            Invoke("ReturnToMain", 5f);
        }
    }

    private void ReturnToMain()
    {
        SceneManager.LoadScene("Main");
        GameContext.reset();
    }
}