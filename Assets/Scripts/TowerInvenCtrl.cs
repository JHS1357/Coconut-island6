using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerInvenCtrl : MonoBehaviour
{
    static public TowerInvenCtrl instance;
    public int TowerCount = 4;
    //public bool[] canUsableTower = new bool[4];       //�Ŀ� �ر����� ����.

    [HideInInspector]
    public enum TowerType { Tower1, Tower2, Tower3, Tower4, None };

    public TowerType SelectedTower;

    public GameObject towerPrefab1;

    public Color usableTower = Color.blue;
    public Color unusableTower = Color.gray;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        //for (int i = 0; i < TowerCount; i++)
        //{
        //    canUsableTower[i] = false;
        //}

        ////��밡���� Ÿ��?
        //canUsableTower[0] = true;

        SelectedTower = TowerType.None;

        SetTowerInventoryImage();
    }

    //public void SwapTower(int index)
    //{
    //    //if (usingTower[index] == false)
    //    //{
    //    //    //���ⱳü��ȣ �ֱ�.
    //    //    Debug.Log(index);
    //    //    usingTower[index] = true;
    //    //}

    //    //for (int i = 0; i < TowerCount; i++)
    //    //{
    //    //    if (i != index)
    //    //        usingTower[i] = false;
    //    //}

    //    SetTowerInventoryImage();
    //}

    public void WeaponSelect(int index)
    {
        switch(SelectedTower)
        {                                                       //����           ���� Ű��
            case TowerType.Tower1:      //�ϳ� ���� �Ǿ�����. -> ������ ���ý�/�ٸ��� ���ý�. ���������.
                if (index == 0)
                {
                    SelectedTower = TowerType.None;
                    BuildManager.instance.standardTurretPrefab = null;
                    this.transform.GetChild(index).GetComponent<Jun_TweenRuntime>().enabled = false;
                }
                else
                {
                    SelectedTower = (TowerType)index;
                    BuildManager.instance.standardTurretPrefab = null;  //������ ����.
                    this.transform.GetChild(index).GetComponent<Jun_TweenRuntime>().enabled = true;
                    this.transform.GetChild(0).GetComponent<Jun_TweenRuntime>().enabled = false;
                }
                break;
            case TowerType.Tower2:
                if (index == 1)
                {
                    SelectedTower = TowerType.None;
                    BuildManager.instance.standardTurretPrefab = null;
                    this.transform.GetChild(index).GetComponent<Jun_TweenRuntime>().enabled = false;
                }
                else
                {
                    SelectedTower = (TowerType)index;
                    BuildManager.instance.standardTurretPrefab = null;  //������ ����.
                    this.transform.GetChild(index).GetComponent<Jun_TweenRuntime>().enabled = true;
                    this.transform.GetChild(1).GetComponent<Jun_TweenRuntime>().enabled = false;
                }
                break;
            case TowerType.Tower3:
                if (index == 2)
                {
                    SelectedTower = TowerType.None;
                    BuildManager.instance.standardTurretPrefab = null;
                    this.transform.GetChild(index).GetComponent<Jun_TweenRuntime>().enabled = false;
                }
                else
                {
                    SelectedTower = (TowerType)index;
                    BuildManager.instance.standardTurretPrefab = null;  //������ ����.
                    this.transform.GetChild(index).GetComponent<Jun_TweenRuntime>().enabled = true;
                    this.transform.GetChild(2).GetComponent<Jun_TweenRuntime>().enabled = false;
                }
                break;
            case TowerType.Tower4:
                if (index == 3)
                {
                    SelectedTower = TowerType.None;
                    BuildManager.instance.standardTurretPrefab = null;
                    this.transform.GetChild(index).GetComponent<Jun_TweenRuntime>().enabled = false;
                }
                else
                {
                    SelectedTower = (TowerType)index;
                    BuildManager.instance.standardTurretPrefab = null;  //������ ����.
                    this.transform.GetChild(index).GetComponent<Jun_TweenRuntime>().enabled = true;
                    this.transform.GetChild(3).GetComponent<Jun_TweenRuntime>().enabled = false;
                }
                break;
            case TowerType.None:        //���� �ȵǾ����� -> �ϳ� �������� �ٲٱ�.
                SelectedTower = (TowerType)index;
                if(index ==0)
                    BuildManager.instance.standardTurretPrefab = towerPrefab1;

                //this.GetComponent<MonoBehaviour>().enabled = true;
                this.transform.GetChild(index).GetComponent<Jun_TweenRuntime>().enabled = true;
                
                break;
        }
        SetTowerInventoryImage();

        //false �϶� �ش� ���� ���ý� -> �Ŵ����� ������ ����. �� ������.

        //true �϶� �ش� ���� ���ý�. ����
    }

    void SetTowerInventoryImage()
    {
        for (int i = 0; i < TowerCount; i++)
        {
            this.transform.GetChild(i).GetComponent<Image>().color = unusableTower;
        }
        switch (SelectedTower)
        {                                  
            case TowerType.Tower1:
                this.transform.GetChild(0).GetComponent<Image>().color = usableTower;

                break;
            case TowerType.Tower2:
                this.transform.GetChild(1).GetComponent<Image>().color = usableTower;
                break;
            case TowerType.Tower3:
                this.transform.GetChild(2).GetComponent<Image>().color = usableTower;
                break;
            case TowerType.Tower4:
                this.transform.GetChild(3).GetComponent<Image>().color = usableTower;
                break;
            case TowerType.None:
                
                break;
        }
        //for (int i = 0; i < TowerCount; i++)
        //{
        //    if (canUsableTower[i] == true)
        //        this.transform.GetChild(i).GetComponent<Image>().color = unusableTower;
        //    else
        //        this.transform.GetChild(i).GetComponent<Image>().color = usableTower;
        //}


    }
}
