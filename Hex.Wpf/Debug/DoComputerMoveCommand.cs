﻿//-----------------------------------------------------------------------
// <copyright> 
// Copyright (c) Anthony Steele 
//  This source code is part of Hex http://github.com/AnthonySteele/Hex
//  and is made available under the terms of the Microsoft Reciprocal License (Ms-RL)
//  http://www.opensource.org/licenses/ms-rl.html
// </copyright>
//----------------------------------------------------------------------- 
namespace Hex.Wpf.Debug
{
    using Hex.Wpf.Controls;
    using Hex.Wpf.Helpers;
    using Hex.Wpf.Model;

    public class DoComputerMoveCommand : GenericCommand<DebugBoardWindowViewModel>    
    {
        private DebugBoardWindowViewModel currentViewModel;
        private bool canExecute = true;

        public override void ExecuteOnValue(DebugBoardWindowViewModel value)
        {
            this.currentViewModel = value;
            ComputerMoveCalculator moveCalculator = new ComputerMoveCalculator(value.HexBoard.Game, this.MoveCompleted, 1);
            moveCalculator.Move();
        }

        public override bool CanExecuteOnValue(DebugBoardWindowViewModel value)
        {
            return this.canExecute;
        }

        private void MoveCompleted(ComputerMoveData computerMoveData)
        {
            HexBoardViewModel hexBoard = this.currentViewModel.HexBoard;
            HexCellViewModel cellToPlay = hexBoard.GetCellAtLocation(computerMoveData.Move);
            if (cellToPlay != null)
            {
                cellToPlay.PlayCell();

                this.canExecute = ! computerMoveData.IsGameWon;
            }

            hexBoard.GetDebugDataCommand.Execute(hexBoard);
        }
    }
}
