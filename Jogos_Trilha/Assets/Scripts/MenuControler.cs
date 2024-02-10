using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject startButton;
    public GameObject visualObject;
    public AudioClip buttonClickSound;
    public AudioSource audioSource;
    public float brightnessLevel = 1f; // Nível inicial de luminosidade
    public Color originalColor; // Cor original do objeto visual

    private void Start()
    {
        // Garanta que o objeto visual esteja oculto inicialmente
        visualObject.SetActive(false);

        // Salve a cor original do objeto visual
        originalColor = visualObject.GetComponent<Renderer>().material.color;
    }

    public void StartGame()
    {
        // Reproduzir som de clique
        if (audioSource != null && buttonClickSound != null)
        {
            audioSource.PlayOneShot(buttonClickSound);
        }

        // Alterar a visibilidade do objeto visual
        if (visualObject != null)
        {
            visualObject.SetActive(true);

            // Ajustar a luminosidade do objeto visual
            Color newColor = originalColor * brightnessLevel;
            visualObject.GetComponent<Renderer>().material.color = newColor;
        }

        // Iniciar o jogo ou transição para a cena de jogo
        // Aqui você pode adicionar lógica adicional, como carregar a próxima cena ou iniciar uma animação de transição
    }
}
