using System.Collections.Generic;
using UnityEngine;
namespace Entity
{
    public static class EntityManager
    {
        static Transform entityParent = new GameObject("Entites").transform;
        //인터페이스

        //모든 개체들
        public static List<MonsterBase> monsters = new List<MonsterBase>();
        //세부 리스트
        // - 플레이어
        public static PlayerBase player { get; private set; }
        

        public static void Add(EntityBase entity)
        {
            entity.transform.SetParent(entityParent);

            if (entity == null) return;
            MonsterBase monster = entity as MonsterBase;
            if (monster !=null)
            {
                monsters.Add(monster);
            }
        }
        public static void SetPlayer(PlayerBase newPlayer)
        {
            player = newPlayer;
            player.team = Team.Player;
        }

    }
}