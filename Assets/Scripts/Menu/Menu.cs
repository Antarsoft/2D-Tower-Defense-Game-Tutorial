using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
   public void ChangeScene(string sceneName)
   {
       SceneManager.LoadScene(sceneName);
   }
}
