using UnityEngine;
using Entity;

namespace Weapon.Factory
{

    internal interface IGunFactory : IWeaponFactory
    {
        float reloadDelay { get; }
    }
    internal class PistolFactory : IGunFactory
    {
        public int damage { get { return 2; } }

        public float startDelay { get { return 0f; } }

        public float cooltime { get { return 0.25f; } }

        public AmmoType ammoType { get { return AmmoType.Small; } }

        public int maxAmmo { get { return 8; } }

        readonly Vector2 _shotPosition = new Vector2(0.05f, 0.08f);
        public Vector2 shotPosition
        {
            get { return _shotPosition; }
        }

        public float reloadDelay { get { return 1f; } }
    }
    internal class ShotGunFactory : IGunFactory
    {
        public int damage { get { return 30; } }

        public float startDelay { get { return 0.1f; } }

        public float cooltime { get { return 1f; } }

        public AmmoType ammoType { get { return AmmoType.Scatter; } }

        public int maxAmmo { get { return 4; } }


        readonly Vector2 _shotPosition = new Vector2(0.05f, 0.08f);
        public Vector2 shotPosition
        {
            get { return _shotPosition; }
        }

        public float reloadDelay { get { return 1f; } }
    }
    internal class RifleFactory : IGunFactory
    {
        public int damage { get { return 5; } }

        public float startDelay { get { return 0f; } }

        public float cooltime { get { return 0.3f; } }

        public AmmoType ammoType { get { return AmmoType.Normal; } }

        public int maxAmmo { get { return 30; } }


        readonly Vector2 _shotPosition = new Vector2(0.07f, 0.08f);
        public Vector2 shotPosition
        {
            get { return _shotPosition; }
        }

        public float reloadDelay { get { return 1f; } }
    }
    internal class SniperFactory : IGunFactory
    {
        public int damage { get { return 50; } }

        public float startDelay { get { return 0.2f; } }

        public float cooltime { get { return 3f; } }

        public AmmoType ammoType { get { return AmmoType.Huge; } }

        public int maxAmmo { get { return 3; } }


        readonly Vector2 _shotPosition = new Vector2(0.1f, 0.08f);
        public Vector2 shotPosition
        {
            get { return _shotPosition; }
        }

        public float reloadDelay { get { return 2f; } }
    }
    internal class SubMachineFactory : IGunFactory
    {
        public int damage { get { return 4; } }

        public float startDelay { get { return 0f; } }

        public float cooltime { get { return 0.15f; } }

        public AmmoType ammoType { get { return AmmoType.Small; } }

        public int maxAmmo { get { return 40; } }


        readonly Vector2 _shotPosition = new Vector2(0.05f, 0.08f);
        public Vector2 shotPosition
        {
            get { return _shotPosition; }
        }

        public float reloadDelay { get { return 1f; } }
    }
    internal class MachineGunFactory : IGunFactory
    {
        public int damage { get { return 1; } }

        public float startDelay { get { return 0f; } }

        public float cooltime { get { return 0.1f; } }

        public AmmoType ammoType { get { return AmmoType.Small; } }

        public int maxAmmo { get { return 100; } }


        readonly Vector2 _shotPosition = new Vector2(0.05f, 0.08f);
        public Vector2 shotPosition
        {
            get { return _shotPosition; }
        }

        public float reloadDelay { get { return 5f; } }
    }
}