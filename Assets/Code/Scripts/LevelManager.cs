using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    public void LoadLevel()
    {
        SceneManager.LoadScene("PlayScene");
    }

}
