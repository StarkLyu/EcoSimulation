using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMoving : MonoBehaviour
{
    public enum AnimMode
    {
        IDLE, WALK, RUN, JUMP, EAT, REST, ATTACK, DAMAGE, DIE
    }

    public enum MoveMode
    {
        IDLE, WALK, RUN
    }

    public float walkSpeed;
    public float runSpeed;
    public float turnSpeed;
    public MoveMode moveMode;
    public bool turnLeft;
    public bool turnRight;

    private Animator anim;
    private float timeCounter;
    private int animIndex;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        timeCounter = 0;
        animIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        MoveAhead();
        TurnAround();
    }

    void SetAnim(AnimMode mode)
    {
        anim.SetInteger("animation", (int)mode);
    }

    void MoveAhead()
    {
        switch (moveMode)
        {
            case MoveMode.IDLE:
                SetAnim(AnimMode.IDLE);
                break;
            case MoveMode.WALK:
                transform.position += transform.forward * walkSpeed * Time.deltaTime;
                SetAnim(AnimMode.WALK);
                break;
            case MoveMode.RUN:
                SetAnim(AnimMode.RUN);
                transform.position += transform.forward * runSpeed * Time.deltaTime;
                break;
        }
    }

    void TurnAround()
    {
        if (turnLeft) transform.Rotate(0, -turnSpeed * Time.deltaTime, 0);
        if (turnRight) transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
    }
}
