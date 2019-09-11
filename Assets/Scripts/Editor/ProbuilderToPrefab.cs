using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class ProbuilderToPrefab : MonoBehaviour
{
    [SerializeField]
    GameObject obj;

    [SerializeField]
    private bool hoge;
    private void Update()
    {
        if (hoge)
        {
            hoge = false;
            CreatePrefabWithMeshInstance(obj);
        }
    }

    public static void CreatePrefabWithMeshInstance(GameObject myMeshGO)
    {
        //プレハブ化する前のメッシュフィルター
        MeshFilter meshFilter = myMeshGO.GetComponent<MeshFilter>();

        //プレハブ化
        GameObject prefab = PrefabUtility.CreatePrefab("Assets/Prefabs/Triangler.prefab", myMeshGO, ReplacePrefabOptions.Default);

        //プレハブ化された後のメッシュフィルター
        MeshFilter prefabMeshFilter = prefab.GetComponent<MeshFilter>();

        //…にメッシュ参照をセットしなおす
        prefabMeshFilter.sharedMesh = meshFilter.sharedMesh;

        //メッシュデータそのものを同じプレハブの中に詰める
        //AssetDatabase.AddObjectToAsset(meshFilter.sharedMesh, prefab);
        AssetDatabase.CreateAsset(meshFilter.sharedMesh, "Assets/Prefabs/TrianglerMesh.asset");

        //アセットのアップデート
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
}
