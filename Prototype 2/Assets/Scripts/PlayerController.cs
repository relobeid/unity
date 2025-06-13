using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Player Movement
    public float horizontalInput;
    public float speed = 10.0f;
    public float xRange = 20.0f;

    public GameObject projectilePrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Keep the player in bounds - left side
        if(transform.position.x < -xRange)
        {
            transform.position = new Vector3(-20, transform.position.y, transform.position.z);
        }

        // Keep the player in bounds - right side
        if(transform.position.x > xRange)
        {
            transform.position = new Vector3(20, transform.position.y, transform.position.z);
        }

        // Move the player left and right
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            // Launch a projectile from the player 
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }
}
