using UnityEngine;
using System.Collections;

public class CatController : MonoBehaviour {

    public const string MOVEMENT_KEY = "Movement";
    public const string DEAD_KEY = "Dead";
    private Animator animator;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (animator.GetBool(DEAD_KEY))
            return;
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (animator.GetInteger(MOVEMENT_KEY) == 0)
            {
                animator.SetInteger(MOVEMENT_KEY, 1);
            }
            else if (animator.GetInteger(MOVEMENT_KEY) > 0)
            {
                animator.SetInteger(MOVEMENT_KEY, 2);
            }
            else
            {
                invertDirection();
            }
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (animator.GetInteger(MOVEMENT_KEY) == 0)
            {
                animator.SetInteger(MOVEMENT_KEY, -1);
            }
            else if (animator.GetInteger(MOVEMENT_KEY) < 0)
            {
                animator.SetInteger(MOVEMENT_KEY, -2);
            }
            else
            {
                invertDirection();
            }
            transform.rotation = new Quaternion(0, 180, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            if (animator.GetInteger(MOVEMENT_KEY) > 0)
            {
                animator.SetInteger(MOVEMENT_KEY, animator.GetInteger(MOVEMENT_KEY) - 1);
            }
            else if (animator.GetInteger(MOVEMENT_KEY) < 0)
            {
                animator.SetInteger(MOVEMENT_KEY, animator.GetInteger(MOVEMENT_KEY) + 1);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Backspace))
        {
            animator.SetBool(DEAD_KEY, true);
            animator.SetInteger(MOVEMENT_KEY, 0);
        }
    }
    
    private void invertDirection()
    {
        animator.SetInteger(MOVEMENT_KEY, animator.GetInteger(MOVEMENT_KEY) * -1);
    }
}
