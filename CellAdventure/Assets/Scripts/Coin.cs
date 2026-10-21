using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private CongratsText congratsText;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            congratsText.ShowCongrats();
            Debug.Log("Coin collected!");
            Destroy(gameObject);
        }
    }
}
