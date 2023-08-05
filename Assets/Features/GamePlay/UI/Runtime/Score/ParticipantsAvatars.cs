using UnityEngine;

namespace GamePlay.UI.Runtime.Score
{
    public readonly struct ParticipantsAvatars
    {
        public ParticipantsAvatars(Sprite player, Sprite enemy)
        {
            Player = player;
            Enemy = enemy;
        }
        
        public readonly Sprite Player;
        public readonly Sprite Enemy;
    }
}