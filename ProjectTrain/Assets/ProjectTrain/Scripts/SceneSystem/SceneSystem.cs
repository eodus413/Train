using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneSystem : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        SceneManager.LoadScene("Scene");
    }
}
