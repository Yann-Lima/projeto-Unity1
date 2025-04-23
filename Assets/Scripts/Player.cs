using UnityEngine;

public class Player : MonoBehaviour

{
    public static Player obj;
    public int livs = 3;

    public bool isGrounded = false;
    public bool isMooving = false;
    public bool isImmune = false;

    public float speed = 5f;
    public float jumpForce = 3f;
    public float movHor;

    public float immuneTimeCnt = 0f;
    public float immuneTime = 0.5f;

    public LayerMask groundLayer;
    public float radius = 0.3f;
    public float groundRayDist = 0.5f;


    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer spr;

    void Awake(){
        obj = this;
    }

    
    // Start is called beafore the fisrt frame
    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    //Update is called once per frame
    void Update(){
        movHor = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate(){

    }

    void onDestroy(){
        obj = null;
    }
}
