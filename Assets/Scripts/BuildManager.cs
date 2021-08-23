using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("����Ŵ��� �̹� ����!!");
            return;
        }

        instance = this;
    }

    // ��ž ������ �ִ� ��
    public GameObject standardTurretPrefab;

    //private void Start()
    //{
    //    BuildTurret = standardTurretPrefab;     
    //}

    //private GameObject BuildTurret;

    public GameObject GetBuildTurret()
    {
        return standardTurretPrefab;
    }
}
