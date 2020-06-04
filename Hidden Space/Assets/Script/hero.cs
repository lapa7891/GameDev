using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hero : MonoBehaviour
{
    Animator anim;

    // Start is called before the first frame update
    public Vector2 direct;
    public float speed =0.07f;
    Rigidbody2D rb;
    [SerializeField]
    [Tooltip("Здоровье игрока")]
    public float upper = 11f;
    [SerializeField]
    [Tooltip("Здоровье игрока")]
    private float upperright = 1f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator> ();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.Space) | Input.touchCount > 0)
        {
            //transform.Translate(direct.normalized * speed);
            fly();
            anim.SetInteger("go", 2);
        }

        else
        {
            anim.SetInteger("go", 1);
        }

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
       
        if (other.gameObject.tag == "koluchka")
        {
            anim.SetInteger("go", 3);
            Invoke("ReloadScene", 0.5f);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            upper = 1f;

        }
        if (other.gameObject.tag == "fin")
        {
            SceneManager.LoadScene(2);
        }

        if (other.gameObject.tag == "fin2")
        {
            SceneManager.LoadScene(3);
        }

        if (other.gameObject.tag == "fin3")
        {
            SceneManager.LoadScene(4);
        }

    }

    private void ReloadScene()
    {
        {
            Application.LoadLevel(index: Application.loadedLevel);
        }
    }



    void fly()
    {
        
          rb.AddForce(transform.up * upper, mode: ForceMode2D.Force);
        rb.AddForce(transform.right * upperright, mode: ForceMode2D.Force);
        //rb.AddForce(transform.position * upper, mode: ForceMode2D.Force);
        
    }
}
