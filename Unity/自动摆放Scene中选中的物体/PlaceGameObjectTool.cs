using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
/// <summary>
/// 这个类用于解决：将场景中选中的所有物体，分成 10 列 彼此之间 X Z 轴上间隔 5 个单位地排布GameObject
/// 用于展示你从网上下载到的一堆东西 就是这样的一个小工具
/// 使用方式：
/// 在场景中选中你想排列的物体，然后点击顶部的菜单栏：我的工具/自动场景物体摆放工具 打开界面，点击自动展开按钮即可
/// 排列基准点是第一个选中的物体
/// </summary>
public class PlaceGameObjectTool : ScriptableWizard
{
    private const int PLACE_COL_COUNT = 10;         //间隔列数10
    private const float PLACE_X_OFFSET = 5f;        //间隔距离X
    private const float PLACE_Z_OFFSET = 5f;        //间隔距离Y
    
    [MenuItem("我的工具/自动场景物体摆放工具")]
    public static void CreatePlaceGameObjectTool()
    {
        ScriptableWizard.DisplayWizard<PlaceGameObjectTool>("物品自动摆放工具", "自动展开");
    }

    // private void OnSelectionChange()
    // {
    //     foreach (var go in Selection.gameObjects)
    //     {
    //         Debug.Log(go.name);
    //     }
    // }

    private void OnWizardCreate()
    {
        var gos = Selection.gameObjects;
        if (gos.Length <= 0)
        {
            Debug.Log("PlaceGameObjectTool: 请选中物体群--");
            return;
        }

        var oneGo = gos[0];
        var oriPosition = oneGo.transform.position;

        for (int i = 1; i < gos.Length; i++)
        {
            int row = i / PLACE_COL_COUNT;
            int col = i - (row * PLACE_COL_COUNT);
            gos[i].transform.position = oriPosition + row * Vector3.back * PLACE_Z_OFFSET 
                                                    + col * Vector3.right * PLACE_X_OFFSET;
        }
        
        Debug.Log("PlaceGameObjectTool: 处理完毕--");
    }
}
