﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


    public class GameManager : MonoBehaviour
    {
    public AudioSource audioSrc;
        private Canvas ui;
        private CountDown countDown;
        private IMiniGame game;


        void Awake()
        {
            ui = GameObject.Find("UICanvas/Canvas").GetComponent<Canvas>();
            game = GameObject.Find("Game").GetComponent<IMiniGame>();

            countDown = ui.transform.Find("CountDown").gameObject.GetComponent<CountDown>();
        }

        // Use this for initialization
        void Start()
        {
            // Init game
            game.initGame(IMiniGame.MiniGameDificulty.EASY, this);
            

            // Begin Countdown
            StartCoroutine(StartGame());
        }

        IEnumerator StartGame()
        {
            // Launch CountDown
            yield return StartCoroutine(countDown.BeginCountDown());

            // Disable CountDown
            countDown.gameObject.SetActive(false);

            // Start the Game
            game.beginGame();
            audioSrc.Play();
    }

        //Game must call this method to finish a minigame
        public void EndGame(IMiniGame.MiniGameResult result)
        {
            //Minigame end Status

            if (result == IMiniGame.MiniGameResult.LOSE)
            {
                SceneManager.LoadScene("Lose");
            }
            else
            {
                MenuManager.Instance.WonGame();
                SceneManager.LoadScene("Win");
            }
        }
    }

