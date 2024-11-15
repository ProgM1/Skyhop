using UnityEngine;

public class CoinController : MonoBehaviour
{
    public float speed = 2f; // �������� �������� ������

    private void Update()
    {
        // ������� ������ ����
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // ������� ������, ���� ��� ������ �� ������ ������� ������
        if (transform.position.y < Camera.main.transform.position.y - 6f)
        {
            Destroy(gameObject);
        }
    }
}
