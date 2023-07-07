using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public TankDatabase tankDB;

    public SpriteRenderer artorkSprite;
    private int selectedOption = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption = 0;
        }
        else
        {
            Load();
        }
        UpdateTank(selectedOption);
    }
    private void UpdateTank(int selectedOption)
    {
        Tank tank = tankDB.GetTank(selectedOption); // set the tank as the selected tank
        artorkSprite.sprite = tank.tankSprite; // set artwork to selected sprite
    }

    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }
}
