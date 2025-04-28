using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;

    public float movHor = -1f; // Inicia andando para direita
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
        if (movHor == 0)
        movHor = -1f;
    }

    void Update()
    {
        // Evitar cair no vazio
        isGroundFloor = (Physics2D.Raycast(
            new Vector3(transform.position.x, transform.position.y - floorCheckY, transform.position.z),
            new Vector2(movHor, 0), 
            frontGrnRayDist, 
            groundLayer
        ));

        if (!isGroundFloor)
            movHor = movHor * -1;

        // Bater na parede
        if (Physics2D.Raycast(transform.position, new Vector2(movHor, 0), frontCheck, groundLayer))
            movHor = movHor * -1;

        // Choque com outro inimigo
        hit = Physics2D.Raycast(
            new Vector3(transform.position.x + movHor * frontCheck, transform.position.y, transform.position.z),
            new Vector2(movHor, 0),
            frontDist
        );

        if (hit.collider != null && hit.transform.CompareTag("Enemy"))
            movHor = movHor * -1;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(movHor * speed, rb.linearVelocity.y); // Corrigido
    }

    void onCollisionEnter2D(Collision2D collision){

    }

    private void OnTriggerEnter2D(Collider2D collision){
        
    }

    private void getKilled()
    {
        gameObject.SetActive(false);
    }
}
