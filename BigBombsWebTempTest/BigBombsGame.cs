﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BigBombsWebTempTest
{
    public class BigBombsGame
    {
        public const int gameSizeX = 14;
        public const int gameSizeY = 10;
        public const int initialMoney = 100;
        public const int allRounds = 5;
        public const int roundsPerPlayer = 2;
        public const int chickenCost = 1;
        public const int mineCost = 6;
        public const int pigCost = 7;
        public const int bombCost = 10;
        public const int moneyPerMine = 10;

        public string GroupName { get; set; }
        public int StageCount { get; set; }
        public int JoinedPlayers { get; set; }
        public char[,] MatrixUnits { get; set; }
        public int[,] MatrixUnitsCount { get; set; }
        public int FirstPlayerMoney { get; set; }
        public int SecondPlayerMoney { get; set; }

        public BigBombsGame(string groupName)
        {
            GroupName = groupName;
            StageCount = 0;
            JoinedPlayers = 1;
            MatrixUnits = new char[gameSizeY, gameSizeX];
            MatrixUnitsCount = new int[gameSizeY, gameSizeX];
            FirstPlayerMoney = initialMoney;
            SecondPlayerMoney = initialMoney;
        }

        public int DefensePointsFirstPlayer(int i, int j)
        {
            int defensivePoints = 0;
            if (IsValidSecondPlayerPigAttackCell(i, j) && MatrixUnits[i, j] == 'c')
            {
                defensivePoints += MatrixUnitsCount[i, j];
            }
            if (IsValidSecondPlayerPigAttackCell(i - 1, j - 1) && MatrixUnits[i - 1, j - 1] == 'c')
            {
                defensivePoints += MatrixUnitsCount[i - 1, j - 1];
            }
            if (IsValidSecondPlayerPigAttackCell(i - 1, j) && MatrixUnits[i - 1, j] == 'c')
            {
                defensivePoints += MatrixUnitsCount[i - 1, j];
            }
            if (IsValidSecondPlayerPigAttackCell(i - 1, j + 1) && MatrixUnits[i - 1, j + 1] == 'c')
            {
                defensivePoints += MatrixUnitsCount[i - 1, j + 1];
            }
            if (IsValidSecondPlayerPigAttackCell(i, j + 1) && MatrixUnits[i, j + 1] == 'c')
            {
                defensivePoints += MatrixUnitsCount[i, j + 1];
            }
            if (IsValidSecondPlayerPigAttackCell(i + 1, j + 1) && MatrixUnits[i + 1, j + 1] == 'c')
            {
                defensivePoints += MatrixUnitsCount[i + 1, j + 1];
            }
            if (IsValidSecondPlayerPigAttackCell(i + 1, j) && MatrixUnits[i + 1, j] == 'c')
            {
                defensivePoints += MatrixUnitsCount[i + 1, j];
            }
            if (IsValidSecondPlayerPigAttackCell(i - 1, j - 1) && MatrixUnits[i - 1, j - 1] == 'c')
            {
                defensivePoints += MatrixUnitsCount[i - 1, j - 1];
            }
            if (IsValidSecondPlayerPigAttackCell(i, j - 1) && MatrixUnits[i, j - 1] == 'c')
            {
                defensivePoints += MatrixUnitsCount[i, j - 1];
            }
            if (IsValidSecondPlayerPigAttackCell(i - 2, j) && MatrixUnits[i - 2, j] == 'c')
            {
                defensivePoints += MatrixUnitsCount[i - 2,j];
            }
            if (IsValidSecondPlayerPigAttackCell(i + 2, j) && MatrixUnits[i + 2, j] == 'c')
            {
                defensivePoints += MatrixUnitsCount[i + 2, j];
            }
            if (IsValidSecondPlayerPigAttackCell(i, j - 2) && MatrixUnits[i, j - 2] == 'c')
            {
                defensivePoints += MatrixUnitsCount[i, j - 2];
            }
            if (IsValidSecondPlayerPigAttackCell(i, j + 2) && MatrixUnits[i, j + 2] == 'c')
            {
                defensivePoints += MatrixUnitsCount[i, j + 2];
            }
            return defensivePoints;
        }

        public int DefensePointsSecondPlayer(int i, int j)
        {
            int defensivePoints = 0;
            if (IsValidFirstPlayerPigAttackCell(i, j) && MatrixUnits[i, j] == 'c')
            {
                defensivePoints += MatrixUnitsCount[i, j];
            }
            if (IsValidFirstPlayerPigAttackCell(i - 1, j - 1) && MatrixUnits[i - 1, j - 1] == 'c')
            {
                defensivePoints += MatrixUnitsCount[i - 1, j - 1];
            }
            if (IsValidFirstPlayerPigAttackCell(i - 1, j) && MatrixUnits[i - 1, j] == 'c')
            {
                defensivePoints += MatrixUnitsCount[i - 1, j];
            }
            if (IsValidFirstPlayerPigAttackCell(i - 1, j + 1) && MatrixUnits[i - 1, j + 1] == 'c')
            {
                defensivePoints += MatrixUnitsCount[i - 1, j + 1];
            }
            if (IsValidFirstPlayerPigAttackCell(i, j + 1) && MatrixUnits[i, j + 1] == 'c')
            {
                defensivePoints += MatrixUnitsCount[i, j + 1];
            }
            if (IsValidFirstPlayerPigAttackCell(i + 1, j + 1) && MatrixUnits[i + 1, j + 1] == 'c')
            {
                defensivePoints += MatrixUnitsCount[i + 1, j + 1];
            }
            if (IsValidFirstPlayerPigAttackCell(i + 1, j) && MatrixUnits[i + 1, j] == 'c')
            {
                defensivePoints += MatrixUnitsCount[i + 1, j];
            }
            if (IsValidFirstPlayerPigAttackCell(i - 1, j - 1) && MatrixUnits[i - 1, j - 1] == 'c')
            {
                defensivePoints += MatrixUnitsCount[i - 1, j - 1];
            }
            if (IsValidFirstPlayerPigAttackCell(i, j - 1) && MatrixUnits[i, j - 1] == 'c')
            {
                defensivePoints += MatrixUnitsCount[i, j - 1];
            }
            if (IsValidFirstPlayerPigAttackCell(i - 2, j) && MatrixUnits[i - 2, j] == 'c')
            {
                defensivePoints += MatrixUnitsCount[i - 2, j];
            }
            if (IsValidFirstPlayerPigAttackCell(i + 2, j) && MatrixUnits[i + 2, j] == 'c')
            {
                defensivePoints += MatrixUnitsCount[i + 2, j];
            }
            if (IsValidFirstPlayerPigAttackCell(i, j - 2) && MatrixUnits[i, j - 2] == 'c')
            {
                defensivePoints += MatrixUnitsCount[i, j - 2];
            }
            if (IsValidFirstPlayerPigAttackCell(i, j + 2) && MatrixUnits[i, j + 2] == 'c')
            {
                defensivePoints += MatrixUnitsCount[i, j + 2];
            }
            return defensivePoints;
        }

        public void ClearArea(int i, int j)
        {
            if (IsValidCell(i, j) && (MatrixUnits[i, j] == 'c' || MatrixUnits[i, j] == 'm'))
            {
                MatrixUnitsCount[i, j] = 0;
                MatrixUnits[i, j] = '0';
            }
            if (IsValidCell(i - 1, j - 1) && (MatrixUnits[i - 1, j - 1] == 'c' || MatrixUnits[i - 1, j - 1] == 'm'))
            {
                MatrixUnitsCount[i - 1, j - 1] = 0;
                MatrixUnits[i - 1, j - 1] = '0';
            }
            if (IsValidCell(i - 1, j) && (MatrixUnits[i - 1, j] == 'c' || MatrixUnits[i - 1, j] == 'm'))
            {
                MatrixUnitsCount[i - 1, j] = 0;
                MatrixUnits[i - 1, j] = '0';
            }
            if (IsValidCell(i - 1, j + 1) && (MatrixUnits[i - 1, j + 1] == 'c' || MatrixUnits[i - 1, j + 1] == 'm'))
            {
                MatrixUnitsCount[i - 1, j + 1] = 0;
                MatrixUnits[i - 1, j + 1] = '0';
            }
            if (IsValidCell(i, j + 1) && (MatrixUnits[i, j + 1] == 'c' || MatrixUnits[i, j + 1] == 'm'))
            {
                MatrixUnitsCount[i, j + 1] = 0;
                MatrixUnits[i, j + 1] = '0';
            }
            if (IsValidCell(i + 1, j + 1) && (MatrixUnits[i + 1, j + 1] == 'c' || MatrixUnits[i + 1, j + 1] == 'm'))
            {
                MatrixUnitsCount[i + 1, j + 1] = 0;
                MatrixUnits[i + 1, j + 1] = '0';
            }
            if (IsValidCell(i + 1, j) && (MatrixUnits[i + 1, j] == 'c' || MatrixUnits[i + 1, j] == 'm'))
            {
                MatrixUnitsCount[i + 1, j] = 0;
                MatrixUnits[i + 1, j] = '0';
            }
            if (IsValidCell(i + 1, j - 1) && (MatrixUnits[i + 1, j - 1] == 'c' || MatrixUnits[i + 1, j - 1] == 'm'))
            {
                MatrixUnitsCount[i + 1, j - 1] = 0;
                MatrixUnits[i + 1, j - 1] = '0';
            }
            if (IsValidCell(i, j - 1) && (MatrixUnits[i, j] == 'c' || MatrixUnits[i, j - 1] == 'm'))
            {
                MatrixUnitsCount[i, j - 1] = 0;
                MatrixUnits[i, j - 1] = '0';
            }
        }

        public void ClearBombArea(int i, int j, int unitCount)
        {
            if (unitCount > 0)
            {
                if (IsValidCell(i, j) && (MatrixUnits[i, j] == 'c' || MatrixUnits[i, j] == 'm'))
                {
                    MatrixUnitsCount[i, j] = 0;
                    MatrixUnits[i, j] = '0';
                }
            }
            if (unitCount > 1)
            {
                if (IsValidCell(i - 1, j) && (MatrixUnits[i - 1, j] == 'c' || MatrixUnits[i - 1, j] == 'm'))
                {
                    MatrixUnitsCount[i - 1, j] = 0;
                    MatrixUnits[i - 1, j] = '0';
                }
                if (IsValidCell(i, j + 1) && (MatrixUnits[i, j + 1] == 'c' || MatrixUnits[i, j + 1] == 'm'))
                {
                    MatrixUnitsCount[i, j + 1] = 0;
                    MatrixUnits[i, j + 1] = '0';
                }
                if (IsValidCell(i + 1, j) && (MatrixUnits[i + 1, j] == 'c' || MatrixUnits[i + 1, j] == 'm'))
                {
                    MatrixUnitsCount[i + 1, j] = 0;
                    MatrixUnits[i + 1, j] = '0';
                }
                if (IsValidCell(i, j - 1) && (MatrixUnits[i, j - 1] == 'c' || MatrixUnits[i, j - 1] == 'm'))
                {
                    MatrixUnitsCount[i, j - 1] = 0;
                    MatrixUnits[i, j - 1] = '0';
                }
            }
            if (unitCount > 2)
            {
                if (IsValidCell(i - 1, j - 1) && (MatrixUnits[i - 1, j - 1] == 'c' || MatrixUnits[i - 1, j - 1] == 'm'))
                {
                    MatrixUnitsCount[i - 1, j - 1] = 0;
                    MatrixUnits[i - 1, j - 1] = '0';
                }
                if (IsValidCell(i - 2, j) && (MatrixUnits[i - 2, j] == 'c' || MatrixUnits[i - 2, j] == 'm'))
                {
                    MatrixUnitsCount[i - 2, j] = 0;
                    MatrixUnits[i - 2, j] = '0';
                }
                if (IsValidCell(i - 1, j + 1) && (MatrixUnits[i - 1, j + 1] == 'c' || MatrixUnits[i - 1, j + 1] == 'm'))
                {
                    MatrixUnitsCount[i - 1, j + 1] = 0;
                    MatrixUnits[i - 1, j + 1] = '0';
                }
                if (IsValidCell(i, j + 2) && (MatrixUnits[i, j + 2] == 'c' || MatrixUnits[i, j + 2] == 'm'))
                {
                    MatrixUnitsCount[i, j + 2] = 0;
                    MatrixUnits[i, j + 2] = '0';
                }
                if (IsValidCell(i + 1, j + 1) && (MatrixUnits[i + 1, j + 1] == 'c' || MatrixUnits[i + 1, j + 1] == 'm'))
                {
                    MatrixUnitsCount[i + 1, j + 1] = 0;
                    MatrixUnits[i + 1, j + 1] = '0';
                }
                if (IsValidCell(i + 2, j) && (MatrixUnits[i + 2, j] == 'c' || MatrixUnits[i + 2, j] == 'm'))
                {
                    MatrixUnitsCount[i + 2, j] = 0;
                    MatrixUnits[i + 2, j] = '0';
                }
                if (IsValidCell(i + 1, j - 1) && (MatrixUnits[i + 1, j - 1] == 'c' || MatrixUnits[i + 1, j - 1] == 'm'))
                {
                    MatrixUnitsCount[i + 1, j - 1] = 0;
                    MatrixUnits[i + 1, j - 1] = '0';
                }
                if (IsValidCell(i, j - 2) && (MatrixUnits[i, j - 2] == 'c' || MatrixUnits[i, j - 2] == 'm'))
                {
                    MatrixUnitsCount[i, j - 2] = 0;
                    MatrixUnits[i, j - 2] = '0';
                }
            }
            if (unitCount > 3)
            {
                if (IsValidCell(i - 1, j - 2) && (MatrixUnits[i - 1, j - 2] == 'c' || MatrixUnits[i - 1, j - 2] == 'm'))
                {
                    MatrixUnitsCount[i - 1, j - 2] = 0;
                    MatrixUnits[i - 1, j - 2] = '0';
                }
                if (IsValidCell(i - 2, j - 1) && (MatrixUnits[i - 2, j - 1] == 'c' || MatrixUnits[i - 2, j - 1] == 'm'))
                {
                    MatrixUnitsCount[i - 2, j - 1] = 0;
                    MatrixUnits[i - 2, j - 1] = '0';
                }
                if (IsValidCell(i - 3, j) && (MatrixUnits[i - 3, j] == 'c' || MatrixUnits[i - 3, j] == 'm'))
                {
                    MatrixUnitsCount[i - 3, j] = 0;
                    MatrixUnits[i - 3, j] = '0';
                }
                if (IsValidCell(i - 2, j + 1) && (MatrixUnits[i - 2, j + 1] == 'c' || MatrixUnits[i - 2, j + 1] == 'm'))
                {
                    MatrixUnitsCount[i - 2, j + 1] = 0;
                    MatrixUnits[i - 2, j + 1] = '0';
                }
                if (IsValidCell(i - 1, j + 2) && (MatrixUnits[i - 1, j + 2] == 'c' || MatrixUnits[i - 1, j + 2] == 'm'))
                {
                    MatrixUnitsCount[i - 1, j + 2] = 0;
                    MatrixUnits[i - 1, j + 2] = '0';
                }
                if (IsValidCell(i, j + 3) && (MatrixUnits[i, j + 3] == 'c' || MatrixUnits[i, j + 3] == 'm'))
                {
                    MatrixUnitsCount[i, j + 3] = 0;
                    MatrixUnits[i, j + 3] = '0';
                }
                if (IsValidCell(i + 1, j + 2) && (MatrixUnits[i + 1, j + 2] == 'c' || MatrixUnits[i + 1, j + 2] == 'm'))
                {
                    MatrixUnitsCount[i + 1, j + 2] = 0;
                    MatrixUnits[i + 1, j + 2] = '0';
                }
                if (IsValidCell(i + 2, j + 1) && (MatrixUnits[i + 2, j + 1] == 'c' || MatrixUnits[i + 2, j + 1] == 'm'))
                {
                    MatrixUnitsCount[i + 2, j + 1] = 0;
                    MatrixUnits[i + 2, j + 1] = '0';
                }
                if (IsValidCell(i + 3, j) && (MatrixUnits[i + 3, j] == 'c' || MatrixUnits[i + 3, j] == 'm'))
                {
                    MatrixUnitsCount[i + 3, j] = 0;
                    MatrixUnits[i + 3, j] = '0';
                }
                if (IsValidCell(i + 2, j - 1) && (MatrixUnits[i + 2, j - 1] == 'c' || MatrixUnits[i + 2, j - 1] == 'm'))
                {
                    MatrixUnitsCount[i + 2, j - 1] = 0;
                    MatrixUnits[i + 2, j - 1] = '0';
                }
                if (IsValidCell(i + 1, j - 2) && (MatrixUnits[i + 1, j - 2] == 'c' || MatrixUnits[i + 1, j - 2] == 'm'))
                {
                    MatrixUnitsCount[i + 1, j - 2] = 0;
                    MatrixUnits[i + 1, j - 2] = '0';
                }
                if (IsValidCell(i, j - 3) && (MatrixUnits[i, j - 3] == 'c' || MatrixUnits[i, j - 3] == 'm'))
                {
                    MatrixUnitsCount[i, j - 3] = 0;
                    MatrixUnits[i, j - 3] = '0';
                }
            }
        }

        public int FirstPlayerCollects()
        {
            int firstPlayerCollects = 0;
            for (int i = 0; i < BigBombsGame.gameSizeY; i++)
            {
                for (int j = 0; j < BigBombsGame.gameSizeX / 2; j++)
                {
                    if (MatrixUnits[i, j] == 'm')
                    {
                        firstPlayerCollects++;
                    }
                }
            }
            return firstPlayerCollects * BigBombsGame.moneyPerMine;
        }

        public int SecondPlayerCollects()
        {
            int secondPlayerCollects = 0;
            for (int i = 0; i < BigBombsGame.gameSizeY; i++)
            {
                for (int j = BigBombsGame.gameSizeX / 2; j < BigBombsGame.gameSizeX; j++)
                {
                    if (MatrixUnits[i, j] == 'm')
                    {
                        secondPlayerCollects++;
                    }
                }
            }
            return secondPlayerCollects * BigBombsGame.moneyPerMine;
        }

        public int CheckGameEnd()
        {
            int winner = 0;
            if (CheckFirstPlayerWin())
            {
                winner++;
            }
            if (CheckSecondPlayerWin())
            {
                winner+=2;
            }
            if (winner > 0)
            {
                return winner;
            }
            return 0;
        }

        private bool CheckFirstPlayerWin()
        {
            for (int i = 0; i < gameSizeY; i++)
            {
                for (int j = gameSizeX / 2; j < gameSizeX; j++)
                {
                    if (MatrixUnits[i, j] == 'c' || MatrixUnits[i, j] == 'm')
                        return false;
                }
            }
            return true;
        }

        private bool CheckSecondPlayerWin()
        {
            for (int i = 0; i < gameSizeY; i++)
            {
                for (int j = 0; j < gameSizeX / 2; j++)
                {
                    if (MatrixUnits[i, j] == 'c' || MatrixUnits[i, j] == 'm')
                        return false;
                }
            }
            return true;
        }

        public bool IsPlayerOnTurn(string connectionID)
        {
            if (StageCount % allRounds < roundsPerPlayer && GroupName != connectionID)
            {
                return false;
            }
            if (StageCount % allRounds >= roundsPerPlayer && GroupName == connectionID)
            {
                return false;
            }
            return true;
        }

        public bool IsValidFirstPlayerPigAttackCell(int i, int j)
        {
            if (i < 0 || i >= gameSizeY || j < 6 || j >= gameSizeX)
            {
                return false;
            }
            return true;
        }

        public bool IsValidSecondPlayerPigAttackCell(int i, int j)
        {
            if (i < 0 || i >= gameSizeY || j < 0 || j >= gameSizeX / 2)
            {
                return false;
            }
            return true;
        }

        public bool IsValidCell(int i, int j)
        {
            if (i < 0 || i >= gameSizeY || j < 0 || j >= gameSizeX)
            {
                return false;
            }
            return true;
        }
    }
}