﻿namespace Global.Services.Publisher.Abstract.Leaderboards
{
    public interface ILeaderboards
    {
        void SetScore(ILeaderboardEntry entry, int score);
    }
}