using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuPanel;

    private PlayerInput playerInput;
    private InputAction pauseAction;
    private bool isPaused = false;

    private void Awake()
    {
        isPaused = false;
        Time.timeScale = 1f;
        playerInput = GetComponent<PlayerInput>();
        pauseAction = playerInput.actions["Pause"];
    }

    private void OnEnable()
    {
        pauseAction.performed += TogglePause;
    }

    private void OnDisable()
    {
        pauseAction.performed -= TogglePause;
    }

    private void TogglePause(InputAction.CallbackContext context)
    {
        if (isPaused) ResumeGame();
        else PauseGame();
    }

    private void PauseGame()
    {
        Time.timeScale = 0f;
        pauseMenuPanel.SetActive(true);
        isPaused = true;
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseMenuPanel.SetActive(false);
        isPaused = false;
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void QuitGame()
    {
        SceneManager.LoadScene(0);
    }
}