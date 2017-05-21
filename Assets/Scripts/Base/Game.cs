﻿using System;
using System.Collections.Generic;

namespace UnityChess
{
    public class Game
    {
        //use static here? Idea is to create a new game instance
        public LinkedListNode<Board> CurrentBoardNode { get; set; }
        public Side CurrentTurn { get; set; }
        public int TurnCount { get; set; }
        public ModeType Mode { get; set; }
        public BoardList BList { get; set; }
        public List<Movement> PreviousMoves;

        public Game(ModeType mode)
        {
            this.CurrentTurn = Side.White;
            this.TurnCount = 0;
            this.Mode = mode;
            this.BList = new BoardList(this.TurnCount);
            this.BList.AddLastBoard(CurrentBoardNode);
            this.PreviousMoves = new List<Movement>();
        }

        //adds a new instance of a Board that represents the board achieved my making a certain move.
        public void ExecuteTurn(Movement move)
        {
            //validate move is legal
            //if (!isLegal(move)) return; //call to gui method which notifies user made invalid move

            //add new board to history of boards (linked list)
            this.BList.AddLastBoard(new LinkedListNode<Board>(new Board(CurrentBoardNode.Value, move)));

            //increment turn count, save move is history of moves
            this.TurnCount++;
            this.PreviousMoves[TurnCount] = move;

            //switch sides (toggle CurrentTurn)
            CurrentTurn = CurrentTurn == Side.White ? Side.Black : Side.White;
        }
    }
}
