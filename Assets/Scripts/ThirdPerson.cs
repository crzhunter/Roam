using UnityEngine;

public class ThirdPerson : MonoBehaviour
{
    //float autoCountDown = 0f;
    public Transform targetCamPos;
    private Vector3 inputEuler;
    private Vector3 refV3;


    public Vector3 pos1;
    public Vector3 pos4;
    public Vector3 verPos1;
    public Vector3 verPos4;

    public float pos1WidhthWidthMult = 0.75f;
    public float pos1WidhthHeightMult = 0.5f;
    public float pos1HeightWidthMult = 2f;
    public float pos1HeightHeightMult = 1.5f;

    public float pos4WidhthWidthMult = 1.35f;
    public float pos4WidhthHeightMult = 1.35f;
    public float pos4HeightWidthMult = 2.25f;
    public float pos4HeightHeightMult = 2.25f;


    public void SetFirstPersonPos(Transform player)
    {
        if (targetCamPos != null)
        {
            targetCamPos.position = player.position;
            transform.position = player.position;

            targetCamPos.rotation = player.rotation;
            transform.rotation = player.rotation;
        }
    }

    public void Awake()
    {

        targetCamPos = new GameObject("CamPal").transform;
        targetCamPos.transform.position = transform.position;
        targetCamPos.transform.rotation = transform.rotation;
        inputEuler = targetCamPos.eulerAngles;
        inputEuler.x = Mathf.Clamp(inputEuler.x, -89.9f, 89.9f);

        //targetCamPos.LookAt(Vector3.zero, Vector3.up);
        inputEuler = targetCamPos.rotation.eulerAngles;
        transform.rotation = targetCamPos.rotation;
        transform.position = targetCamPos.position;

    }


    void LateUpdate()
    {
        if (!MainGame.Instance.isWalking)
            return;
        float x = Mathf.Clamp(Input.GetAxis("Mouse X"), -2f, 2f);
        float y = Mathf.Clamp(Input.GetAxis("Mouse Y"), -2f, 2f);
        SetPalEuler(x, y);


        Vector3 direction = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            direction += targetCamPos.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction -= targetCamPos.right;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction -= targetCamPos.forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += targetCamPos.right;
        }
        if (Input.GetKey(KeyCode.E))
        {
            direction += targetCamPos.up;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            direction -= targetCamPos.up;
        }

        Vector3 inputPos = targetCamPos.position + direction * 100 * Time.deltaTime;
        inputPos.x = Mathf.Clamp(inputPos.x, -250, 250);
        inputPos.y = Mathf.Clamp(inputPos.y, 101, 350);
        inputPos.z = Mathf.Clamp(inputPos.z, -250, 250);
        targetCamPos.position = inputPos;





        transform.rotation = Quaternion.Lerp(transform.rotation, targetCamPos.rotation, 5 * Time.deltaTime);
        transform.position = Vector3.SmoothDamp(transform.position, targetCamPos.position, ref refV3, 0.2f);

    }


    void SetPalEuler(float deltaX, float deltaY)
    {
        inputEuler += new Vector3(-deltaY, deltaX, 0) * 3f;
        inputEuler.z = 0;
        inputEuler.x = Mathf.Clamp(inputEuler.x, -15, 89.9f);
        targetCamPos.eulerAngles = inputEuler;
    }
}