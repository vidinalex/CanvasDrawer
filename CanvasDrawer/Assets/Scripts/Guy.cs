using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guy : MonoBehaviour
{
    [SerializeField] private string addTag = "Add", sawTag = "Saw", finishTag = "Finish";
    [SerializeField] private GameObject collect, death, win;
    private string animTrigger;
    private Vector3 offset = new Vector3(0,1f,0);
    private Spawner spawner;
    private GameManag manager;

    private void Start()
    {
        spawner = transform.parent.GetComponent<Spawner>();
        manager = transform.parent.GetComponent<GameManag>();
        animTrigger = manager.GetAnimTrigger();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == addTag)
        {
            Instantiate(collect, transform.position + offset, Quaternion.identity);
            Destroy(other.gameObject);
            spawner.Spwan();
            manager.GetChildGuys();
        }
        if(other.tag == sawTag)
        {
            Instantiate(death, transform.position + offset, Quaternion.identity);
            Destroy(gameObject);
            manager.GetChildGuys();    
        }
        if(other.tag == finishTag)
        {
            Instantiate(win, transform.position + offset, Quaternion.identity);
            gameObject.GetComponent<Animator>().SetInteger("State", 2);
        }
    }
}
