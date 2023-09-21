using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGame : MonoBehaviour
{
    public static MainGame Instance;

    public GameObject go_StartMenu;
    public SwitchMove switchMove;
    /// <summary>
    /// 原始位置
    /// </summary>
    public Transform originTrans;
    /// <summary>
    /// 玩家
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
        //按ESC退出漫游回到主菜单，人物位置视角还原，漫游状态设为false
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
    /// 点击开始漫游，设置漫游状态
    /// </summary>
    public void SetIsWalking()
    {
        isWalking = true;
        switchMove.ChangeToFirstPerson();
    }
}
