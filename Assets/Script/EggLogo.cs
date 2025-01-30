using UnityEngine;

public class EggLogo : MonoBehaviour
{ 
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Shoot"))
        {
            Application.OpenURL("https://github.com/Trijeux/My_Link");
        }
    }
}
