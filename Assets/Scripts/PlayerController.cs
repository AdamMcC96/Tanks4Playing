using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 mousePos;
    public TankDatabase tankDB;
    public Rigidbody2D rb;
    public Transform bullet;
    float vertical;
    public float runSpeed = 5f;
    public SpriteRenderer artorkSprite;
    private int selectedOption = 0;
    private Camera mainCam;
    // Start is called before the first frame update
    void Start()
    {
        
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
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
    private void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);
        vertical = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(transform.position.x ,vertical * runSpeed);
    }

    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }
}
