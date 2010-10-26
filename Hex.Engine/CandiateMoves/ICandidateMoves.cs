﻿//-----------------------------------------------------------------------
// <copyright> 
// Copyright (c) Anthony Steele 
//  This source code is part of Hex http://github.com/AnthonySteele/Hex
//  and is made available under the terms of the Microsoft Reciprocal License (Ms-RL)
//  http://www.opensource.org/licenses/ms-rl.html
// </copyright>
//----------------------------------------------------------------------- 
namespace Hex.Engine.CandiateMoves
{
    using System.Collections.Generic;
    using Hex.Board;

    public interface ICandidateMoves
    {
        IEnumerable<Location> CandidateMoves(HexBoard board, int lookaheadDepth);
    }
}
