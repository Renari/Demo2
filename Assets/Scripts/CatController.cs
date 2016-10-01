using UnityEngine;
using System.Collections;

public class CatController : MonoBehaviour {

    public AudioClip walk;
    public AudioClip run;
    public AudioClip die;


    public const string MOVEMENT_KEY = "Movement";
    public const string DEAD_KEY = "Dead";
    private Animator animator;
    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
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
                playSound(walk);
            }
            else if (animator.GetInteger(MOVEMENT_KEY) > 0)
            {
                animator.SetInteger(MOVEMENT_KEY, 2);
                playSound(run);
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
                playSound(walk);
            }
            else if (animator.GetInteger(MOVEMENT_KEY) < 0)
            {
                animator.SetInteger(MOVEMENT_KEY, -2);
                playSound(run);
            }
            else
            {
                invertDirection();
            }
            transform.rotation = new Quaternion(0, 180, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            if (animator.GetInteger(MOVEMENT_KEY) == 2)
            {
                animator.SetInteger(MOVEMENT_KEY, animator.GetInteger(MOVEMENT_KEY) - 1);
                playSound(walk);
            }
            else if (animator.GetInteger(MOVEMENT_KEY) == 1)
            {
                animator.SetInteger(MOVEMENT_KEY, animator.GetInteger(MOVEMENT_KEY) - 1);
                playSound(null);
            }
            else if (animator.GetInteger(MOVEMENT_KEY) == -1)
            {
                animator.SetInteger(MOVEMENT_KEY, animator.GetInteger(MOVEMENT_KEY) + 1);
                playSound(null);
            }
            else if (animator.GetInteger(MOVEMENT_KEY) == -1)
            {
                animator.SetInteger(MOVEMENT_KEY, animator.GetInteger(MOVEMENT_KEY) + 1);
                playSound(walk);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Backspace))
        {
            animator.SetBool(DEAD_KEY, true);
            animator.SetInteger(MOVEMENT_KEY, 0);
            playSound(die);
            audioSource.loop = false;
        }
    }
    
    private void invertDirection()
    {
        animator.SetInteger(MOVEMENT_KEY, animator.GetInteger(MOVEMENT_KEY) * -1);
    }
    
    private void playSound(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
}
