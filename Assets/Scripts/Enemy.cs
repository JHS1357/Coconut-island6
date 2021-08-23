using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float rot_speed = 10.0f;

    private Transform target;
    private int wavepointIndex = 0;

    MinimapIcon myMinimapicon = null;
    Animator myAnimator = null;

    [Header("State")]
    public int HP = 100;
    public float move_speed = 3.0f;

    private void OnEnable()
    {
        HP = DataManager.instance.enemyHP[GameManager.instance.nCurWave];
        move_speed = DataManager.instance.enemySpeed[GameManager.instance.nCurWave];
    }

    private void Start()
    {
        this.transform.position = GameObject.Find("StartPos").transform.position;
        target = Waypoints.points[0];
        //github check

        myAnimator = GetComponentInChildren<Animator>();
        myAnimator.SetBool("Walk Forward", true);


        GameObject obj = Instantiate(Resources.Load("Prefabs/MiniMapIcon") as GameObject);
        myMinimapicon = obj.GetComponent<MinimapIcon>();
        myMinimapicon.Initalize(this.transform);
        myMinimapicon.myColor = Color.red;
    }

    private void Update()
    {
        Vector3 dir = (target.position - transform.position).normalized;
        transform.Translate(dir * move_speed * Time.deltaTime, Space.World); 

        this.transform.forward = Vector3.Lerp(this.transform.forward, dir, Time.deltaTime * rot_speed);

        // �����̻� ������ ���� �߰��� �ڵ�
        //����������� üũ�ؾ� �ӵ����� ����.
        if(this.HP > 0)
            CheckStatus();

        if (Vector3.Distance(transform.position, target.transform.position) <= 0.2f)
        {
            GetNextWayPoint();
        }

    }

    void GetNextWayPoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            //Destroy(gameObject);
            //������ �Ǹ�??????
            //

            this.gameObject.SetActive(false);
            GameManager.instance.nUsedMonsterCnt++;
            myMinimapicon.gameObject.SetActive(false);
            return;
        }

        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

    public void GetDamage(int dam)
    {
        HP -= dam;
        //�Ŀ� ���潺�� �߰�.
        if (HP <= 0)
        {
            //�״� ��� ������ ������ �͵�
            GetComponentInChildren<Animator>().SetBool("Walk Forward", false);
            move_speed = 0.0f;
            myMinimapicon.gameObject.SetActive(false);
            StartCoroutine(EnemyDie());
            return;

        }
        else
            myAnimator.SetTrigger("Take Damage");
    }


    // TO-DO ���ο� �� �����̻� ���� �ʿ�
    // �ϴ��� ���� ȥ�� �����ϸ鼭 �����ߴ� �ڵ带 �ӽ÷� �����ɴϴ�.
    // START
    bool is_slow = false;
    float slow_power;
    public void ApplyStatus(int status_code, float duration, float power)
    {
        // 1 = slow
        if (status_code == 1)
        {
            is_slow = true;
            slow_power = power;
            left_slow = duration;
        }
    }
    float init_move_speed = 3.0f;
    float left_slow = 0.0f;
    void CheckStatus()
    {
        if (is_slow == true && init_move_speed == move_speed)
        {
            move_speed = init_move_speed * slow_power;
            return;
        }

        left_slow -= Time.deltaTime;

        if(left_slow <= 0.0f)
        {
            slow_power = 1.0f;
            move_speed = init_move_speed;
        }
    }
    // END



    IEnumerator EnemyDie()
    {

        myAnimator.SetTrigger("Die");
                                                                                //���̶�� �ִϸ��̼���                                           //������ ����
        yield return new WaitUntil(() => (myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Die") && (myAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.99f)));

        //�״� ��� ���Ŀ� ������ �͵�
        GameManager.instance.nUsedMonsterCnt++;
        this.gameObject.SetActive(false);

        yield return null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Melee")
        {
            if(this.HP >0)
                GetDamage(other.GetComponent<Weapon>().damage);
        }
    }
}
