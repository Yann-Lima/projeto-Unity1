using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;

    public float movHor = 0f;
    public float speed = 3f;

    public bool isGroundFloor = true;
    public bool isGroundFront = false;

    public LayerMask groundLayer;
    public float frontGrnRayDist = 0.25f;
    public float floorCheckY = 0.52f;
    public float frontCheck = 0.51f;
    public float frontDist = 0.001f;

    public int scoreGiv = 50;

    private RaycastHit2D hit;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
       // Evitar cair no vazio
        isGroundFloor = (Physics2D.Rycast(new Vector3(transform.position.x, traansform.position.y - floorCheckY, trnsform.position.z),
        new Vector3(movHor, 0, 0), frontGrnRayDist, groundLayer));

        if(isGroundFloor)
        movHor = movHor * -1;
       //Bater na parede

       //Choque com outro inimigo
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(movHor * speed, rb.linearVelocity.y);
    }

    private void getKilled()
    {
        gameObject.SetActive(false);
    }
}
