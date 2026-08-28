using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public GameObject respawnFlicker;
    public GameObject gameOverPanel;

    private int health = 3;
    private float damageCooldown = 1f;
    private float lastDamageTime = -1f;

    private Vector3 spawnPosition;
    private Quaternion spawnRotation;

    void Start()
{
    spawnPosition = transform.position;
    spawnRotation = transform.rotation;

    UpdateHealthUI();
}

    void UpdateHealthUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
                hearts[i].sprite = fullHeart;
            else
                hearts[i].sprite = emptyHeart;
        }
    }

   public void TakeDamage()
{
    if (Time.time < lastDamageTime + damageCooldown)
        return;

    lastDamageTime = Time.time;

    health--;

    UpdateHealthUI();

    Debug.Log("Player Health: " + health);

    if (health > 0)
{
    Respawn();
}
else
{
    GameOver();
}
}

void GameOver()
{
    gameOverPanel.SetActive(true);

    Cursor.lockState = CursorLockMode.None;
    Cursor.visible = true;

    Time.timeScale = 0f;

    Debug.Log("GAME OVER");
}

void Respawn()
{
    CharacterController controller = GetComponent<CharacterController>();

    controller.enabled = false;

    transform.position = spawnPosition;
    transform.rotation = spawnRotation;

    controller.enabled = true;

    StartCoroutine(FlickerCamera());
}



System.Collections.IEnumerator FlickerCamera()
{
    float timer = 0f;

    while (timer < 1f)
    {
        respawnFlicker.SetActive(true);

        yield return new WaitForSeconds(0.08f);

        respawnFlicker.SetActive(false);

        yield return new WaitForSeconds(0.12f);

        timer += 0.2f;
    }

    respawnFlicker.SetActive(false);
}

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Trap"))
        {
            TakeDamage();
        }
    }
}