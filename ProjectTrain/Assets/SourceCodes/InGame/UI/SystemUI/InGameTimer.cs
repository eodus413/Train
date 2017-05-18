using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
public class InGameTimer : MonoBehaviour
{
    [SerializeField]
    private float playTime;
    private int minute { get { return (int)(playTime * 0.016666666f); } }
    private int second { get { return (int)playTime % 60; } }

    Text UI;
    StringBuilder builder = new StringBuilder("00 : 00");
    void Start()
    {
        UI = GetComponentInChildren<Text>();
    }
    void Update()
    {
        playTime += Time.deltaTime;
        
        builder.Remove(0, builder.Length);
        builder.Append(minute).Append(" : ").Append(second);

        UI.text = builder.ToString();
    }
}
