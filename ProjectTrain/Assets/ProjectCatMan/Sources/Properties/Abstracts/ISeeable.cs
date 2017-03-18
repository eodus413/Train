using UnityEngine;
namespace ProjectCatMan
{
    public interface ISeeable : IUnitProperty
    {
        float sight { get; }
        GameObject current { get; }
        UnitBase currentSeeingUnit { get; }

        bool Nothing();

        void Seeing();
    }
}