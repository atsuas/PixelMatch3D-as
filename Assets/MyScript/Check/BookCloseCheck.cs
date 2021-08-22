using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookCloseCheck : MonoBehaviour
{
    void OnMouseDrag()
    {
        //Cubeの位置をワールド座標からスクリーン座標に変換して、objectPointに格納
        Vector3 objectPoint
            = Camera.main.WorldToScreenPoint(transform.position);

        //Cubeの現在位置(マウス位置)を、pointScreenに格納
        Vector3 pointScreen
            = new Vector3(Input.mousePosition.x,
                          Input.mousePosition.y,
                          0);

        //Cubeの現在位置を、スクリーン座標からワールド座標に変換して、pointWorldに格納
        Vector3 pointWorld = Camera.main.ScreenToWorldPoint(pointScreen);
        pointWorld.y = transform.position.y;

        //Cubeの位置を、pointWorldにする
        transform.position = pointWorld;
    }

}