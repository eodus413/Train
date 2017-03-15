using UnityEngine;
namespace ProjectCatMan
{
    public interface ISeeable : IUnitProperty
    {
        GameObject current { get; }
        UnitBase currentSeeingUnit { get; }

        bool seeingNothing { get; }

        void Seeing();
    }
}