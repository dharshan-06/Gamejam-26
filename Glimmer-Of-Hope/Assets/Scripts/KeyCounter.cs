using UnityEngine;
using TMPro;

public class KeyCounter : MonoBehaviour
{
    public TMP_Text currentCountText;
    public TMP_Text maxCountText;

    public int maxKeys = 1;

    private int currentKeys = 0;

    void Start()
    {
        currentCountText.text = "0";
        maxCountText.text = maxKeys.ToString();
    }

    public void AddKey()
    {
        currentKeys++;

        currentCountText.text = currentKeys.ToString();

        Debug.Log("Key UI: " + currentKeys + " / " + maxKeys);
    }
}