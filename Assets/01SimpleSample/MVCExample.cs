using UnityEngine;
using System.Collections;
using UniRx;
using UnityEngine.UI;

public class MVCExample : MonoBehaviour
{
    EnemyModel mEnemy= new EnemyModel(200);
    // Use this for initialization
    void Start()
    {
        var attackBtn = transform.Find("Button").GetComponent<Button>();
        var HPText = transform.Find("Text").GetComponent<Text>();

        attackBtn.OnClickAsObservable()
            .Subscribe(_ =>
            {
                mEnemy.HP.Value -= 99;
            });

        mEnemy.HP.SubscribeToText(HPText);

        mEnemy.IsDead
            .Where(isDead => isDead)
            .Select(isDead => !isDead)
            .SubscribeToInteractable(attackBtn);
    }
}

public class EnemyModel
{
    public ReactiveProperty<long> HP;
    public IReadOnlyReactiveProperty<bool> IsDead;

    public EnemyModel(long initialHP)
    {
        HP = new ReactiveProperty<long>(initialHP);
        IsDead = HP.Select(hp => hp <= 0).ToReactiveProperty();
    }
}
