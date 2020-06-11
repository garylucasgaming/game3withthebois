using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    private GameManager _gameManager;
    private ShipModel _player;
    private TextMeshProUGUI _ScoreUI;
    private TextMeshProUGUI _FinalScore;
    private TextMeshProUGUI _LivesUI;
    [SerializeField]
    private GameObject[] _PlayerLifeIcons = new GameObject[5];
    private GameObject _endScreen;
    private GameObject _pauseScreen;
    private GameObject _phoneUI;




    private void Awake()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<ShipModel>();
        _ScoreUI = GameObject.Find("ScoreUI").GetComponent<TextMeshProUGUI>();
        _LivesUI = GameObject.Find("LivesUI").GetComponent<TextMeshProUGUI>();
        _endScreen = GameObject.Find("EndScreen");
        _pauseScreen = GameObject.Find("PauseMenu");
        _phoneUI = GameObject.Find("PhoneUI");

        //TODO REMOVE COMMENT
       // _phoneUI.SetActive(false);
        _endScreen.SetActive(false);
        _pauseScreen.SetActive(false);

#if (UNITY_ANDROID || UNITY_IOS)
        _phoneUI.SetActive(true);

#endif

    }

    private void Update()
    {
        UpdateScore();
        UpdateLives();
    }

    private void UpdateScore()
    {
        //set score text to "SCORE\n" + game manager score 

        _ScoreUI.text = "Score\n" + _gameManager.Score;
        print(_ScoreUI.text);

    }

    private void UpdateLives()
    {
        int i = 1;
        foreach (GameObject go in _PlayerLifeIcons)
        {
            if (_player.Lives >  0 &&  i <=  _player.Lives) { _PlayerLifeIcons[i-1].SetActive(true); i++; continue; }
            if (i > _player.Lives ) {  _PlayerLifeIcons[i-1].SetActive(false); i++; continue; }

            

        }
      

    }

    public void SetPauseMenuActive( )
    {

        if (!_pauseScreen.activeInHierarchy)
        {
            Time.timeScale = 0;
            _pauseScreen.SetActive(true);
            return;
        }

        Time.timeScale = 1;
        _pauseScreen.SetActive(false);
    }

    public void ActivateEndScreen()
    {

        Time.timeScale = 0;

        _ScoreUI.gameObject.SetActive(false);
        _LivesUI.gameObject.SetActive(false);
        _endScreen.gameObject.SetActive(true);
        _FinalScore = GameObject.Find("FinalScore").GetComponent<TextMeshProUGUI>();
        _FinalScore.text = "Final Score\n" + _gameManager.Score;



    }

}
