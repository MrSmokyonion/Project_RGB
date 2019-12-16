using UnityEngine;

public class SplashManager : MonoBehaviour
{
    [SerializeField]
    public AudioSource[] sounds;

    public void PlaySFX(string _name)
    {
        switch(_name)
        {
            case "R": sounds[0].Play(); break;
            case "G": sounds[1].Play(); break;
            case "B": sounds[2].Play(); break;
            case "TEAM": sounds[3].Play(); break;
        }
    }

    public void ChangeScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("TitleScene");
    }
}
