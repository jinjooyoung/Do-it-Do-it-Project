using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public float rotateSpeed;

    void Update()
    {
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.World); //������ ȸ�� ��� (����� ���� ��Ǹ�) ���� ��� ������
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")  //�ε��� ������Ʈ�� �±װ� �÷��̾��� ��
        {
            playerscript player = other.GetComponent<playerscript>(); //Player�� ��ũ��Ʈ ������Ʈ ��������
            player.itemCount++; //������ ī��Ʈ + 1
            print("�������� ���Խ��ϴ�.");
            gameObject.SetActive(false); //������Ʈ ��Ȱ��ȭ
        }

    }
}