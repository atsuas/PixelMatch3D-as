using UnityEngine;

public class BookCloseExample : MonoBehaviour
{
    Animator animator;
    public GameObject book1;
    public GameObject stage;
    public GameObject button;
    public GameObject handSprite;
    public float lifeTime = 4f;
    public float destroy = 7f;

    public new HingeJoint hingeJoint;

    // 単純化のために、スピード調整用係数はVector2からfloatに変更
    [SerializeField]
    float RotationSpeed;


    void Start()
    {
        hingeJoint = GetComponent<HingeJoint>();
        
    }

    void Update()
    {
        //ドラッグしている間
        if (Input.GetMouseButton(0))
        {
            OnRotate(new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")));

            if (hingeJoint.angle >= 90f)
            {
                JointSpring hingeSpring = hingeJoint.spring;
                hingeSpring.targetPosition = 170f;
                hingeJoint.spring = hingeSpring;
                Debug.Log("90度超えたよ");
            }
        }
        if (hingeJoint.angle >= 165f)
        {
            //hingeJoint.useSpring = false;
            animator = GetComponent<Animator>();
            animator.enabled = true;
            Destroy(book1.gameObject, lifeTime);
            Destroy(this.gameObject, destroy);
            handSprite.SetActive(false);
            Debug.Log("閉じたよ");
        }
    }

    //void Zoom()
    //{
    //    animator.SetTrigger("Zoom");
    //}

    void StageOn()
    {
        stage.SetActive(true);
    }

    void ButtonOn()
    {
        button.SetActive(true);
    }

    //deltaはドラッグの方向を取得
    void OnRotate(Vector2 delta)
    {
        // 回転量はドラッグ方向ベクトルの長さに比例する
        float deltaAngle = delta.magnitude * RotationSpeed;

        // 回転量がほぼ0なら、回転軸を求められないので何もしない
        if (Mathf.Approximately(deltaAngle, 0.0f))
        {
            return;
        }

        // ドラッグ方向をワールド座標系に直す
        // 横ドラッグならカメラのright方向、縦ドラッグならup方向ということなので
        // deltaのx、yをright、upに掛けて、2つを合成すればいい
        Transform cameraTransform = Camera.main.transform;
        Vector3 deltaWorld = cameraTransform.right * delta.x + cameraTransform.up * delta.y * 0;

        // 回転軸はドラッグ方向とカメラforwardの外積の向き
        Vector3 axisWorld = Vector3.Cross(deltaWorld, cameraTransform.forward).normalized;

        // Rotateで回転する
        // 回転軸はワールド座標系に基づくので、回転もワールド座標系を使う
        transform.Rotate(axisWorld, deltaAngle, Space.World);
    }
}