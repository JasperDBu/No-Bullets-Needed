using UnityEngine;

public class GunRotation : MonoBehaviour
{

    public bool left;
    private void FixedUpdate()
    {
        Vector3 diffrence = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diffrence.Normalize();

        float rotationZ = Mathf.Atan2(diffrence.y, diffrence.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);

        if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270)
        {
            left = true;
        }
        else
        {
            left = false;
        }
    }
}
