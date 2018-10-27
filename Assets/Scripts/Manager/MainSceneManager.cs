using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainSceneManager : MonoBehaviour
{
    /*默认单人*/
    private bool isSingle = true;

    private Transform pos1;

    private Transform pos2;


    private void Awake()
    {
        pos1 = transform.Find("Pos1");
        pos2 = transform.Find("Pos2");
    }

    /// <summary>
    /// 缓慢移到频幕中间
    /// </summary>
    private void Start()
    {
        transform.DOMoveY(300, 3f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) | Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (!isSingle)
            {
                isSingle = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.S) | Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (isSingle)
            {
                isSingle = false;
            }
        }


        if (isSingle)
        {
            pos1.gameObject.SetActive(true);
            pos2.gameObject.SetActive(false);
        }
        else
        {
            pos1.gameObject.SetActive(false);
            pos2.gameObject.SetActive(true);
        }


        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("Game");
            GameConst.isSingle = isSingle;
        }
    }
}