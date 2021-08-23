using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] GameObject m_fallingBlock = default;

    public void Break()
    {
        Instantiate(m_fallingBlock, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
