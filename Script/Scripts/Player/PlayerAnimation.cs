using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator am;
    PlayerMovement pm;
    SpriteRenderer sr;

    void Start()
    {
        am = GetComponent<Animator>();
        pm = GetComponent<PlayerMovement>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pm.moveDir.x !=0 || pm.moveDir.y !=0)
        {
            am.SetBool("Move", true);
            SpriteDirectionChecker();
        }
        else
        {
            am.SetBool("Move", false);
        }
    }

    void SpriteDirectionChecker()
    {
        if (pm.moveDir.x > 0)
        {
            am.SetBool("right", true);
        }
        else
        {
            am.SetBool("right", false);
        }
        if (pm.moveDir.x < 0)
        {
            am.SetBool("left", true);
        }
        else
        {
            am.SetBool("left", false);
        }
        if (pm.moveDir.y > 0)
        {
            am.SetBool("up", true);
        }
        else
        {
            am.SetBool("up", false);
        }
        if (pm.moveDir.y < 0)
        {
            am.SetBool("down", true);
        }
        else
        {
            am.SetBool("down", false);
        }
    }
}
