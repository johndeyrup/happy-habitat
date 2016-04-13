using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public BoardManager boardScript;
    private int level = 1;
    private Camera cam;
    private float scrollSpeed;
    private int scrollBound;

    void Start()
    {
        cam = Camera.main;
        scrollSpeed = 10;
        scrollBound = 5;
    }
    void Awake()
    {
        boardScript = GetComponent<BoardManager>();
        InitGame();

    }

    void InitGame()
    {
        boardScript.SetupScene(level);
    }

    void FixedUpdate()
    {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        if (mouseX < scrollBound)
        {
            cam.transform.Translate(Vector3.right * -scrollSpeed);
        }
        else if (mouseY < scrollBound)
        {
            cam.transform.Translate(Vector3.forward * -scrollSpeed);
        }
        else if (mouseX >= Screen.height - scrollBound)
        {
            cam.transform.Translate(Vector3.right);
        }
        else if (mouseY >= Screen.height - scrollBound) {
            cam.transform.Translate(Vector3.forward);
        }
        cam.transform.position = new Vector3(Mathf.Clamp(cam.transform.position.x, 0, 10), Mathf.Clamp(cam.transform.position.y, 0, 10), 1.0f);
    }
}

