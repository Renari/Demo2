using UnityEngine;
using System.Collections;

public class BackgroundScroller : MonoBehaviour {

    private new Renderer renderer;
    private Vector2 savedOffset;
    private GameObject player;
    private Animator playerAnimator;

    public float scrollSpeed;
    

    // Use this for initialization
    void Start () {
        renderer = GetComponent<Renderer>();
        playerAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        savedOffset = renderer.sharedMaterial.GetTextureOffset("_MainTex");
    }
	
	// Update is called once per frame
	void Update () {
        int movement = playerAnimator.GetInteger(CatController.MOVEMENT_KEY);
        float x = renderer.sharedMaterial.GetTextureOffset("_MainTex").x;
        if (x > 1)
            x = 0;
        if (x < 0)
            x = 1;
        x += Time.time % scrollSpeed * movement;
        Vector2 offset = new Vector2(x, savedOffset.y);
        renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
