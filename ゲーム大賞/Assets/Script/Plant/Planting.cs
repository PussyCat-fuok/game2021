using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planting : MonoBehaviour
{
    // �픭�˓_
    private GameObject seed;

    // �픭�˓_
    private Transform plantTop;

    // ��̑��x
    private float speed = 250;

    // Update is called once per frame
    public void Plant(float x,float y,GameObject seed, Transform plantTop)
    {
        if (x == 0)
        {
            x = 0.2f;
        }

        // ��̕���
        GameObject seeds = Instantiate(seed);

        Vector2 force;

        force = new Vector2(x, y*1.5f) * speed;

        // Rigidbody�ɗ͂������Ĕ���
        seeds.GetComponent<Rigidbody2D>().AddForce(force);

        // ��̈ʒu�𒲐�
        seeds.transform.position = new Vector2(plantTop.position.x, plantTop.position.y + 3.5f);

    }
}
