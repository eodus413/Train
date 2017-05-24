//플레이어를 참조하는 모든 객체이서 포함함
//주로 UI
//옵저버패턴과 비슷,혹은 동일

namespace Entity
{
    public class TargetingPlayer
    {
        //생성자
        public TargetingPlayer()        
        {
            Update();
        }

        //멤버
        PlayerBase _current; //현재 플레이어

        //인터페이스
        public PlayerBase current
        {
            get { return _current; }
        } 
            
        public void Update()    //플레이어를 바꿈
        {
            _current = EntityManager.player;    //현재 플레이어 참조함
        }
    }
}