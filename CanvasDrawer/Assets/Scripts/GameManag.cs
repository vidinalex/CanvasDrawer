using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManag : MonoBehaviour
{
    [SerializeField] private SplineFollower splineFollower;
    [SerializeField] private string animTrigger = "State";

    private List<GameObject> charas = new List<GameObject>();
    private float widthMax, heightMax;


    public float GetWidthMax()
    {
        return widthMax;
    }

    public float GetHeightMax()
    {
        return heightMax;
    }

    public string GetAnimTrigger()
    {
        return animTrigger;
    }

    private void Awake()
    {
        widthMax = Screen.width;
        heightMax = Screen.height / 3;
    }

    private void Start()
    {
        GetChildGuys();
    }

    public void CalcDiff(Vector3[] positions)
    {
        int tempMult = positions.Length/charas.Count;

        List<Vector3> tempPositions = new List<Vector3>();
        tempPositions.AddRange(positions);

        while(tempPositions.Count < charas.Count) //fix too short lines
        {
            tempPositions.Add(positions[Random.Range(0,positions.Length-1)]);
        }
        if(tempMult == 0) tempMult = 1;

        for (int i = 1; i <= charas.Count; i++)
        {
            Debug.Log(i + " " + tempMult);
            Debug.Log(new Vector2(
                (tempPositions[i * tempMult-1].x-widthMax/2)/widthMax*5,
                (tempPositions[i * tempMult-1].y-heightMax/2)/heightMax*5
                ));
            charas[i-1].transform.localPosition = new Vector3(
                (tempPositions[i * tempMult-1].x - widthMax / 2) / widthMax * 5,
                0,
                (tempPositions[i * tempMult-1].y - heightMax / 2) / heightMax * 5
                );
        }
    }

    public void StartMovement()
    {
        splineFollower.enabled = true;
        SetRunAnim();
    }

    public void GetChildGuys()
    {
        charas.Clear();
        for (int i = 0; i < transform.childCount; i++)
        {
            charas.Add(transform.GetChild(i).gameObject);
        }
    }

    private void FixedUpdate()
    {
        GetChildGuys();
    }

    public void SetRunAnim()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.GetComponent<Animator>().SetInteger(animTrigger, 1);
        }
    }
}
