using UnityEngine;
using TMPro;

public class cubeScript : MonoBehaviour
{
    public Rigidbody rb;
    private FMOD.Studio.EventInstance instance;

    [SerializeField]
    public TMP_Text textBox;
    public Material material;

    void Start()
    {
        Debug.Log("Start()");
        material.color = Color.blue;
        textBox.text = "LEVEL 1";
        instance = FMODUnity.RuntimeManager.CreateInstance("event:/bg-level-1");
        instance.start();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(20, 20, 0);
            FMODUnity.RuntimeManager.PlayOneShot("event:/pull-up");
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(-20, 20, 0);
            FMODUnity.RuntimeManager.PlayOneShot("event:/pull-up");
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(0, 20, 20);
            FMODUnity.RuntimeManager.PlayOneShot("event:/pull-up");
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(0, 20, -20);
            FMODUnity.RuntimeManager.PlayOneShot("event:/pull-up");
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "success")
        {
            textBox.text = "LEVEL 2";
            material.color = Color.yellow;

            instance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            instance.release();

            FMODUnity.RuntimeManager.PlayOneShot("event:/bg-level-2");
        }
    }
}