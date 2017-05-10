using UnityEngine;
using System.Collections;
using Entity.Factory;

namespace Entity
{
    public partial class TowerBase : EntityBase
    {
        //초기화
        protected override IEntityFactory SetFactory()
        {
            entityType = EntityType.Tower;
            return EntityFactoryMethod.GetFactory(_towerType);
        }

        [SerializeField]
        TowerType _towerType;
    }
}