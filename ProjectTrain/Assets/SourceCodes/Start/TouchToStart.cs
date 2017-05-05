namespace StartScene
{
    using UnityEngine;
    public class TouchToStart : MonoBehaviour
    {
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            SceneController.LoadScene("InGame");
        }
    }
}