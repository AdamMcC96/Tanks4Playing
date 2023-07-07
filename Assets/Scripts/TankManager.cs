using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TankManager : MonoBehaviour
{
    public TankDatabase tankDB;
    
    public Text nameText;
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
    public void NextOption()
    {
        selectedOption++; // next option
        
        if(selectedOption >= tankDB.TankCount) // if the next option is greater than the number of options
        {
            selectedOption = 0; // cycle back to first option
        }
        UpdateTank(selectedOption);
        Save();
    }

    public void BackOption()
    {
        selectedOption--; // previous option
        
        if(selectedOption < 0) // if the previous option is less than the first
        {
            selectedOption = tankDB.TankCount - 1; // cycle to the last option
        }

        UpdateTank(selectedOption);
        Save();
    }
    private void UpdateTank(int selectedOption)
    {
        Tank tank = tankDB.GetTank(selectedOption); // set the tank as the selected tank
        artorkSprite.sprite = tank.tankSprite; // set artwork to selected sprite
        nameText.text = tank.tankName; // set name to selected tank name
    }

    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }

    private void Save()
    {
        PlayerPrefs.SetInt("selectedOption", selectedOption);
    }

    public void ChangeScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}
