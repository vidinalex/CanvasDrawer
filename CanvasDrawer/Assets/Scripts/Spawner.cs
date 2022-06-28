using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject guy;
    [SerializeField] private float maxTimer = 0.1f;
    [SerializeField] private GameManag manager;
    private string animTrigger;
    private float timer;

    private void Start()
    {
        timer = maxTimer;
        animTrigger = manager.GetAnimTrigger();
    }

    public void Spwan()
    {
        if (timer > 0) return;
        timer = maxTimer;
        Instantiate(guy, transform).GetComponent<Animator>().SetInteger("State", 1);
    }

    private void Update()
    {
        timer -= Time.deltaTime;
    }
}
