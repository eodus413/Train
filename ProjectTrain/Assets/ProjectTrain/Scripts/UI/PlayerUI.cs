using UnityEngine;
using UnityEngine.UI;

namespace ProjectTrain
{
    public class PlayerUI : MonoBehaviour
    {
        [SerializeField] Image hp;
        [SerializeField] Player player;
        void Start()
        {
            hp = GetComponent<Image>();
            player = GameObject.Find("Player").GetComponent<Player>();
        }
        void Update()
        {
            hp.fillAmount = (float)((float)player.hp / (float)Player.orgHp);
        }
    }
}
