using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const string ANIMATOR_MOVE_X = "moveX";
    private const string ANIMATOR_MOVE_Y = "moveY";
    private const string ANIMATOR_LAST_MOVE_X = "lastMoveX";
    private const string ANIMATOR_LAST_MOVE_Y = "lastMoveY";
    private const string INPUT_HORIZONTAL = "Horizontal";
    private const string INPUT_VERTICAL = "Vertical";
    private const float LIMIT_OFFSET = .5f;
    public static PlayerController instance;

    public Rigidbody2D rigidBody;
    public Animator animator;
    public float movementSpeed;
    public string areaTransitionName;

    public bool canMove = true;

    private Vector3 bottomLeftLimit;
    private Vector3 topRightLimit;

    public void SetBounds(Vector3 bottomLeft, Vector3 topRight)
    {
        bottomLeftLimit = bottomLeft + new Vector3(LIMIT_OFFSET, LIMIT_OFFSET, 0f);
        topRightLimit = topRight + new Vector3(-LIMIT_OFFSET, -LIMIT_OFFSET, 0f);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            UpdateRigidBodyVelocity();
            UpdateCurrentAnimatorMovement();
            UpdateLastAnimatorMovement();
            KeepPlayerWithinBounds();
        }
        else
        {
            rigidBody.velocity = Vector2.zero;
        }
        
    }

    private void UpdateRigidBodyVelocity()
    {
        this.rigidBody.velocity = new Vector2(Input.GetAxisRaw(INPUT_HORIZONTAL), Input.GetAxisRaw(INPUT_VERTICAL)) * this.movementSpeed;
    }

    private void UpdateCurrentAnimatorMovement()
    {
        this.animator.SetFloat(ANIMATOR_MOVE_X, this.rigidBody.velocity.x);
        this.animator.SetFloat(ANIMATOR_MOVE_Y, this.rigidBody.velocity.y);
    }


    private void UpdateLastAnimatorMovement()
    {
        if (Input.GetAxisRaw(INPUT_HORIZONTAL) == 1 || Input.GetAxisRaw(INPUT_HORIZONTAL) == -1 || Input.GetAxisRaw(INPUT_VERTICAL) == 1 || Input.GetAxisRaw(INPUT_VERTICAL) == -1)
        {
            this.animator.SetFloat(ANIMATOR_LAST_MOVE_X, Input.GetAxisRaw(INPUT_HORIZONTAL));
            this.animator.SetFloat(ANIMATOR_LAST_MOVE_Y, Input.GetAxisRaw(INPUT_VERTICAL));

        }
    }

    private void KeepPlayerWithinBounds()
    {
        float newXPosition = Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x);
        float newYPosition = Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y);

        transform.position = new Vector3(newXPosition, newYPosition, transform.position.z);
    }

}
