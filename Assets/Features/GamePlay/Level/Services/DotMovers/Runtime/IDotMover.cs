﻿using System.Threading;
using Cysharp.Threading.Tasks;
using GamePlay.Level.Fields.Runtime;

namespace GamePlay.Level.Services.DotMovers.Runtime
{
    public interface IDotMover
    {
        UniTask<UniTask<bool>> TryMove(IField field, CancellationToken cancellation);
    }
}