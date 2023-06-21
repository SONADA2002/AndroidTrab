using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player instance;

    [Header("move")]
    [Range(0f, 5f)]
    [SerializeField]
    private float moveSpeed = 1f;

    private bool _canMove = true;
    
    [Header("Bounds")]
    [SerializeField]
    private BoxCollider2D playerBounds;

    [Header("Shoot")]
    [SerializeField]
    private Transform shootPivot;

    [SerializeField]
    private GameObject shootPrefab;

    [SerializeField]
    public int vidaMaxima;
    public int vidaAtual;

    [Header("Death")]
    [SerializeField]
    private GameObject explosionPrefab;

    [SerializeField]
    private Transform deathPosition;

    private Vector3 _initialDeathPosition;

    [SerializeField]
    private float returnSpeed = 0.2f;

    
    private Vector3 _initialPosition;

    [Header("UI")]
    public GameObject gameOverPanel;

    bool buttonRight;
    bool buttonLeft;
    bool buttonUp;
    bool buttonDown;
    

    private void Awake()
    {
        instance = this;
        _initialPosition = transform.position;
        _initialDeathPosition = deathPosition.position;
    }
    private void Start()
    {
        Debug.Log("PLAYER");
        vidaAtual = vidaMaxima;
        Time.timeScale = 1f;
        Physics2D.IgnoreLayerCollision(6, 7, false);
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        ApplyBounds();

        // Shoot();

        Invecivel();

        MoveRight();
        MoveLeft();
        MoveUp();
        MoveDown();

    }

    private void Invecivel()
    {
        if (!Input.GetButtonDown("Jump"))
        {
            
            return;
        }
       // Physics2D.IgnoreLayerCollision(6, 7, true);

    }
    private void Shoot()
    {
        if (!Input.GetButtonDown("Fire1"))
        {
            return;
        }
        Instantiate(shootPrefab, shootPivot.position, shootPivot.rotation);
        FindObjectOfType<AudioManager>().Play("PlayerShoot");
        //Physics2D.IgnoreLayerCollision(6, 7, false);

    }

    public void ShootButton()
    {
        Instantiate(shootPrefab, shootPivot.position, shootPivot.rotation);
        FindObjectOfType<AudioManager>().Play("PlayerShoot");
    }

    private void Move()
    {
        if (!_canMove)
        {
            return;
        }

        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");

        var move = new Vector3(
            h * moveSpeed * Time.deltaTime,
            v * moveSpeed * Time.deltaTime,
            0f

        );

        transform.Translate(move);
    }

    #region MoveUpButton
    void MoveUp()
    {
        if (buttonUp == true)
        {
            var move = new Vector3(0, 1f * moveSpeed * Time.deltaTime, 0);

            transform.Translate(move);
        }
    }
    public void MoveUpPointerUp()
    {
        buttonUp = false;
    }

    public void MoveUpPointerDown()
    {
        buttonUp = true;
    }
    #endregion

    #region MoveLeftButton
    void MoveLeft()
    {
        if (buttonLeft == true)
        {
            var move = new Vector3(-1f * moveSpeed * Time.deltaTime, 0, 0);

            transform.Translate(move);
        }
    }
    public void MoveLeftPointerUp()
    {
        buttonLeft = false;
    }

    public void MoveLeftPointerDown()
    {
        buttonLeft = true;
    }
    #endregion

    #region MoveRightButton
    void MoveRight()
    {
        if (buttonRight == true)
        {
            var move = new Vector3(1f * moveSpeed * Time.deltaTime, 0, 0);

            transform.Translate(move);
        }
    }
    public void MoveRightPointerUp()
    {
        buttonRight = false;
    }

    public void MoveRightPointerDown()
    {
        buttonRight = true;
    }
    #endregion

    #region MoveDownButton
    void MoveDown()
    {
        if (buttonDown == true)
        {
            var move = new Vector3(0, -1f * moveSpeed * Time.deltaTime, 0);

            transform.Translate(move);
        }
    }
    public void MoveDownPointerUp()
    {
        buttonDown = false;
    }

    public void MoveDownPointerDown()
    {
        buttonDown = true;
    }
    #endregion

    private void ApplyBounds(){

        var minX = -playerBounds.bounds.extents.x + playerBounds.offset.x + playerBounds.transform.position.x;
        var maxX = playerBounds.bounds.extents.x + playerBounds.offset.x + playerBounds.transform.position.x;

        var minY = -playerBounds.bounds.extents.y + playerBounds.offset.y + playerBounds.transform.position.y;
        var maxY = playerBounds.bounds.extents.y + playerBounds.offset.y + playerBounds.transform.position.y;

        //Debug.Log($"Size: {playerBounds.size}; {playerBounds.bounds.extents}");
        //y-1.107

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, minX, maxX),
            Mathf.Clamp(transform.position.y, minY, maxY),
            transform.position.z
        ); 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Instantiate(explosionPrefab, other.transform.position, other.transform.rotation); 
            Destroy(other.gameObject);
            StartCoroutine(Die());
        }
        if (other.CompareTag("ShootEnemy"))
        {
            Instantiate(explosionPrefab, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
            StartCoroutine(Die());
        }
        //if (other.CompareTag("ShootEnemy"))
        //{
        //    vidaAtual--;
        //    if (vidaAtual <= 0)
        //    {
        //        Destroy(gameObject);
        //        Debug.Log("Game Over");
        //    }
        //}
        
    }

    private IEnumerator Die()
    {
        _canMove = false;
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        FindObjectOfType<AudioManager>().Play("ExplosionPlayer");
        yield return new WaitForSeconds(1f);

        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;

        yield return null;

        /*transform.position = _initialDeathPosition;

        yield return new WaitForSeconds(1f);

        yield return null;

        transform.position = deathPosition.position;

        while(transform.position.x < _initialPosition.x)
        {
            var direction = (deathPosition.position - transform.position).normalized;
            transform.Translate(direction * (returnSpeed * Time.deltaTime));

            yield return null;

        }

        yield return new WaitForSeconds(1f);*/

        _canMove = true;
    }

    public void GetInvulnerable()
    {

        StartCoroutine("Invulnerable");
    }

    private IEnumerator Invulnerable()
    {
        Debug.Log("Oie");
        Physics2D.IgnoreLayerCollision(6, 7, true);
        yield return new WaitForSeconds(12f);
        
    }
}
