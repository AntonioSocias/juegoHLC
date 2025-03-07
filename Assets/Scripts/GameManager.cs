using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton
    public int score = 0;
    public int highScore = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    private AudioSource audioSource;

    // Música y sonidos
    public AudioClip menuMusic;
    public AudioClip levelMusic;
    public AudioClip sonidoMuerte;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        // 🔹 Busca los textos en la escena
        BuscarTextosUI();

        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateScoreText();

        audioSource = GetComponent<AudioSource>() ?? gameObject.AddComponent<AudioSource>();

        CambiarMusicaPorEscena();

        // 🔹 Suscribirse al evento de cambio de escena para actualizar la UI
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void BuscarTextosUI()
    {
        scoreText = GameObject.Find("contadorPuntos")?.GetComponent<TextMeshProUGUI>();
        highScoreText = GameObject.Find("highScore")?.GetComponent<TextMeshProUGUI>();

        // 🔹 Oculta los textos si estamos en el menú principal
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            if (scoreText != null) scoreText.gameObject.SetActive(false);
            if (highScoreText != null) highScoreText.gameObject.SetActive(false);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("🔄 Escena cargada, actualizando referencias de UI...");
        BuscarTextosUI();
        UpdateScoreText();
        CambiarMusicaPorEscena();
    }

    void CambiarMusicaPorEscena()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            audioSource.clip = menuMusic;
        }
        else if (SceneManager.GetActiveScene().name == "NivelPrincipal")
        {
            audioSource.clip = levelMusic;
        }

        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void AddScore(int points)
    {
        score += points;

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }

        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        if (scoreText != null) scoreText.text = "Score: " + score;
        if (highScoreText != null) highScoreText.text = "High Score: " + highScore;
    }

    public void GameOver()
    {
        Debug.Log("🔴 El juego ha terminado. Pausando y reproduciendo sonido...");

        Time.timeScale = 0f; // Pausar el juego
        StartCoroutine(ReiniciarJuegoConSonido());
    }

    IEnumerator ReiniciarJuegoConSonido()
    {
        if (sonidoMuerte != null)
        {
            GameObject tempAudio = new GameObject("TempAudio");
            AudioSource tempSource = tempAudio.AddComponent<AudioSource>();
            tempSource.clip = sonidoMuerte;
            tempSource.Play();

            DontDestroyOnLoad(tempAudio);
            Debug.Log("🔊 Reproduciendo sonido de muerte...");

            yield return new WaitForSecondsRealtime(sonidoMuerte.length);

            Time.timeScale = 1f;
            score = 0;
            UpdateScoreText();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            Destroy(tempAudio, 1f);
        }
        else
        {
            Debug.LogWarning("⚠️ No se asignó sonido de muerte, reiniciando inmediatamente...");
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
