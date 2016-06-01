using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReverterManager : MonoBehaviour
{
    static int indexOfCurScene = -1;

    public static void ResetScene()
    {
        indexOfCurScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene("Reverter");
    }

    protected void Start()
    {
        if (indexOfCurScene != -1)
        {
            StartCoroutine(Load());
        }
    }

    IEnumerator Load()
    {

        yield return new WaitForSeconds(3);

        SceneManager.LoadScene(indexOfCurScene);
    }
}
