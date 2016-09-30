using UnityEngine;
using System.Collections;

public class GroundScaler : MonoBehaviour {

    private const float backgroundBaseHeight = 1080.0f;
    private const float groundBaseHeight = 285.0f;

	// Use this for initialization
	void Start ()
    {
        float width = Camera.main.orthographicSize * 2.0f * Screen.width / Screen.height;
        float height = groundBaseHeight / backgroundBaseHeight * (Camera.main.orthographicSize * 2.0f);

        GetComponent<BoxCollider2D>().size = new Vector2(width, height);
        Transform transform = GetComponent<Transform>();
        transform.position = new Vector3(transform.position.x, Camera.main.orthographicSize * -1 + height / 2, transform.position.z);
    }
	
	// Update is called once per frame
	void Update () {

    }
}
