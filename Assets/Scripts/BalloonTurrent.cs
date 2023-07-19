using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class BalloonTurrent : MonoBehaviour
{
    public GameObject prefabBalloon;
    public GameObject muzzle;
    public GameObject target;
    public int attackRange = 20;
    public float fireRate = 1f;
    public float ballSpeed = 2000f;
    public float lastFire = 0f;
    public GameObject goal;


    // Start is called before the first frame update
    void Start()
    {
        Transform barrel = transform.Find("Barrel");
        muzzle = barrel.Find("Muzzle").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        lastFire += Time.deltaTime;
        target = FindTarget("Monkey", attackRange);

        if (target != null)
        {
            transform.LookAt(target.transform);

            if (lastFire >= fireRate)
            {
                GameObject ball = Object.Instantiate(prefabBalloon, muzzle.transform.position, Quaternion.identity);

                Rigidbody rigidBody = ball.GetComponent<Rigidbody>();
                rigidBody.AddForce(transform.forward * ballSpeed);

                lastFire = 0;
            }
        }
    }

    //Find the closest target that has the tag and is closer than maxDistance
    public GameObject FindTarget(string tag, float maxDistance)
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(tag);  //Fill array with all gameobjects with the tag
        GameObject closest = null;                          //result: starts at null just in case we don't find anything in range

        float distance = maxDistance * maxDistance;         //square the distance
        Vector3 position = transform.position;              //our current position
        

        foreach (GameObject obj in gameObjects)
        {
            Vector3 difference = obj.transform.position - position; //calculate the difference to the object from our current position
            float curDistance = difference.sqrMagnitude;    //distance requires a square root, which is slow, just using the squared magnitued
         

            if (curDistance < distance)                     //comparing the squared distances
            {
                closest = obj;                              //new closest object set
                distance = curDistance;                     //distance to the object saved for next comparison in loop
            }
        }

        return closest;
    }
}
