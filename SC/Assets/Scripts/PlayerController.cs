using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class PlayerController : MonoBehaviour {

    public float speed;
    private Rigidbody2D rb2d;

    private int count;
    private int total;
    public Text countText;
    public Text winText;
    public GameObject[] Pickups;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        winText.text = "";
        SetCountText();

        var recoger = GameObject.FindGameObjectsWithTag("PickUp");
        total  = recoger.Length;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        rb2d.AddForce(movement * speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }

        if ( count >= total )
        {
            winText.text = "You Win!!";
        }


    }

    void SetCountText( )
    {
        countText.text = "Count: " + count.ToString();
    }
}
