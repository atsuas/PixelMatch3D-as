﻿using UnityEngine;

public class BookCloseExample : MonoBehaviour
{
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
                Debug.Log("90度超えたよ");
            }
        }
        
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
        // deltaのx、yをright、upに掛けて、2つを合成すればいいはず...
        Transform cameraTransform = Camera.main.transform;
        Vector3 deltaWorld = cameraTransform.right * delta.x + cameraTransform.up * delta.y * 0;

        // 回転軸はドラッグ方向とカメラforwardの外積の向き
        Vector3 axisWorld = Vector3.Cross(deltaWorld, cameraTransform.forward).normalized;

        // Rotateで回転する
        // 回転軸はワールド座標系に基づくので、回転もワールド座標系を使う
        transform.Rotate(axisWorld, deltaAngle, Space.World);
    }
}