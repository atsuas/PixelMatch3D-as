using UnityEngine;

public class ClickManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var col = Physics2D.OverlapCircle(pos, 0.1f);
            Block b = col?.gameObject.GetComponent<Block>();
            b?.Break();
        }
    }
}
