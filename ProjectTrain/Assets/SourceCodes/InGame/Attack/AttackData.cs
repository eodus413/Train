using UnityEngine;
using Entity;

//추후에 enum AttackType 추가 가능
//예) AttackType : Fire,Water,Magic,Bullet...등등
//타입에 따른 데미지 상성 제작가능

public struct AttackData
{
    //생성자
    public AttackData(EntityBase attacker,EntityBase attackTarget, int damage, Vector2 direction)
    {
        _attacker = attacker;
        _attackTarget = attackTarget;
        _damage = damage;
        _direction = direction;
    }

    //멤버
    private EntityBase _attacker;       //공격 시전자
    private EntityBase _attackTarget;   //공격 피해자
    private int _damage;                //데미지
    private Vector2 _direction;         //공격 방향

    //인터페이스
    public EntityBase attacker
    {
        get
        {
            if (_attacker == null)   //예외처리
            {
                Debug.Log("No Attacker");
            }

            return _attacker;
        }
    }
    public EntityBase attackTarget
    {
        get
        {
            if (_attackTarget == null) //예외처리
            {
                Debug.Log("No AttackTarget");
            }
            return _attackTarget;
        }
    }
    public int damage
    {
        get { return _damage; }
        private set
        {
            _damage = value;
            if (_damage < 0)        //예외처리
            {
                _damage = 0;
            }
        }
    }
    public Vector2 direction
    {
        get
        {
            if(_direction == Vector2.zero)  //예외처리
            {
                Debug.Log("No Direction");
            }
            return _direction;
        }
    }

    public bool isAttackTeam
    {
        get { return attacker.team == attackTarget.team; }
    }
    public bool isAttackEnemy
    {
        get { return attacker.team != attackTarget.team; }
    }
}
