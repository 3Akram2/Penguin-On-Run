using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    public float speed = 120;
    
    public float hInput;
    public Rigidbody playerRg;
    public bool onGround=true;
    public float grav=1;
    public float force = 500;
    public bool gameOver=false;
    public TextMeshProUGUI GameOver;
    public ParticleSystem ExplosionPlayer;
    public ParticleSystem Ices;
    private AudioSource playerSounds;
    public AudioClip jumpClip;
    public AudioClip crashClip;
    public Button restartGame;
   



    // Start is called before the first frame update
    void Start()
    {

        playerRg = GetComponent<Rigidbody>();
        Physics.gravity *= grav;
        GameOver.gameObject.SetActive(false);
        playerSounds = GetComponent<AudioSource>();
    }



    // Update is called once per frame
    void Update()
    {
        if (gameOver == false )
        { 
        hInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward*Time.deltaTime*speed*hInput);
        }
        if (transform.position.x > 80) 
        {
            transform.position = new Vector3(80, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -23)
        {
            transform.position = new Vector3(-23, transform.position.y, transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.Space)&&onGround&&!gameOver) 
        {
            playerRg.AddForce(Vector3.up*force,ForceMode.Impulse);
            onGround = false;
            Ices.Stop();
            playerSounds.PlayOneShot(jumpClip,1);
        }
      

    }


    public void RestartGame()

    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            onGround = true;
            Ices.Play();
        }
        else if (collision.gameObject.CompareTag("barrier"))
            {
            gameOver = true;
            ExplosionPlayer.Play();
            Ices.Stop();
            playerSounds.PlayOneShot(crashClip,1);
            GameOver.gameObject.SetActive(true);
            restartGame.gameObject.SetActive(true);
            
            }
    }
}
