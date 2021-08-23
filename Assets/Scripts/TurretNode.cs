using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretNode : MonoBehaviour
{
	public Color hoverColor;		// ���콺 ���� �� ���� ��
	public Vector3 positionOffset;	// ��ž ��ġ �� ���� ��ġ ����

	private GameObject turret;   

	private Renderer rend;
	private Color originColor;

	private void Start()
	{
		rend = GetComponent<Renderer>();
		originColor = rend.material.color;
	}

	private void OnMouseEnter()
	{
		rend.material.color = hoverColor;
	}

	private void OnMouseExit()
	{
		rend.material.color = originColor;
	}

	private void OnMouseDown()
	{
		// ��ž ��ġ �Ұ���
		if (BuildManager.instance.GetBuildTurret() == null)
		{
			Debug.Log("��ž ��ġ �Ұ��� - TODO: ȭ�鿡 ��� ����");
			return;
		}

		GameObject buildTurret = BuildManager.instance.GetBuildTurret();
		turret = Instantiate(buildTurret, transform.position + positionOffset, transform.rotation);
	}
}

