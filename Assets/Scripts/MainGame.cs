using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGame : MonoBehaviour
{
    public static MainGame Instance;

    public GameObject go_StartMenu;
    public SwitchMove switchMove;
    /// <summary>
    /// ԭʼλ��
    /// </summary>
    public Transform originTrans;
    /// <summary>
    /// ���
    /// </summary>
    public Transform player;

    public bool isWalking;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        //��ESC�˳����λص����˵�������λ���ӽǻ�ԭ������״̬��Ϊfalse
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            go_StartMenu.SetActive(true);
            player.transform.position = originTrans.position;
            player.transform.rotation = originTrans.rotation;
            switchMove.HideMove();
            isWalking = false;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    /// <summary>
    /// �����ʼ���Σ���������״̬
    /// </summary>
    public void SetIsWalking()
    {
        isWalking = true;
        switchMove.ChangeToFirstPerson();
    }
}
