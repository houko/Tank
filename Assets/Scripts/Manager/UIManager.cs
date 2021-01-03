using Constant;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Manager
{
    public class UIManager : MonoBehaviour
    {
        private Text textScore;

        private Text textHp1;

        private Text textHp2;

        private GameObject gameOver;

        private void Awake()
        {
            textScore = GameObject.Find("ScoreText").GetComponent<Text>();
            textHp1 = GameObject.Find("HpText1").GetComponent<Text>();
            textHp2 = GameObject.Find("HpText2").GetComponent<Text>();

            gameOver = transform.Find("GameOver").gameObject;
        }


        /// <summary>
        /// 更新分数
        /// 更新血量
        /// 检测游戏是否结束
        /// </summary>
        private void Update()
        {
            textScore.text = GameContext.Score.ToString();
            textHp1.text = GameContext.Player1Hp.ToString();
            textHp2.text = GameContext.Player2Hp.ToString();

            if (!GameContext.IsGameOver) return;
            gameOver.SetActive(true);
            Invoke(nameof(ReturnToMain), 5f);
        }

        /// <summary>
        /// 回到游戏选项界面
        /// </summary>
        private void ReturnToMain()
        {
            SceneManager.LoadScene("Main");
            GameContext.Reset();
        }
    }
}