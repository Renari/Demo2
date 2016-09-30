using UnityEngine;
using System.Collections;

public class CameraScaler : MonoBehaviour {

	// Use this for initialization
	void Start () {
        // Scale object to fit the camera
        float width = Camera.main.orthographicSize * 2.0f * Screen.width / Screen.height;
        float height = Camera.main.orthographicSize * 2.0f;
        Transform transform = GetComponent<Transform>();
        transform.localScale = new Vector3(width, height, transform.position.z);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
