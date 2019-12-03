﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SnakeKike : IMiniGame
{
   GameManager game;
    public override void beginGame()
    {
       game.EndGame(MiniGameResult.WIN);
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        game = gm;
    }
}