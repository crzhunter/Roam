using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SwitchMove : MonoBehaviour
{
    public FirstPerson move1;
    public ThirdPerson move2;

    public MoveEnum moveType = MoveEnum.第一人称;
    // Start is called before the first frame update
    void Start()
    {
        HideMove();
    }

    // Update is called once per frame
    void Update()
    {
        if (!MainGame.Instance.isWalking)
            return;
        if (Input.GetKeyDown(KeyCode.F)) {
            if (moveType == MoveEnum.第一人称)
            {
                ChangeToThirdPerson();
            }
            else {
                ChangeToFirstPerson();
            }
        }
    }

    public void HideMove() {
        move1.gameObject.SetActive(false);
        move2.gameObject.SetActive(false);

    }

    public void ChangeToFirstPerson()
    {
        moveType = MoveEnum.第一人称;
        move2.gameObject.SetActive(false);
        move1.gameObject.SetActive(true);
    }
    public void ChangeToThirdPerson()
    {
        moveType = MoveEnum.第三人称;
        move1.gameObject.SetActive(false);
        move2.gameObject.SetActive(true);
        move2.SetFirstPersonPos(move1.transform);
    }
}
public enum MoveEnum{ 
    第一人称,
    第三人称
}
