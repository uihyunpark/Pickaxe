using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelect : MonoBehaviour
{
    public static SceneSelect instnace;

    private void Awake()
    {
        if (instnace == null)
        {
            instnace = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void SelectedScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
