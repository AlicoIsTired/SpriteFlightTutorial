using System;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public int ForceRange = 7500; // half of the range of the applied force (range is -ForceRange to ForceRange)
    public int MinScaleModifier = 2; // shouldn't be lower than two, this gives the minimum size * 2
    public int MaxScaleModifier = 6; // this gives the maximum size * 2
    void Start()
    {
        



        // set spawn location within camera, but away from (0, 0)
        Vector3 NewPosition;
        do
        {
            NewPosition = new Vector3(UnityEngine.Random.Range(-10, 10), UnityEngine.Random.Range(-6, 6), 0);
        } while (2 > Vector3.Distance(new Vector3(0, 0, 0), NewPosition)); 
        transform.position = NewPosition; 

        // add a random scale to object
        int RandomScale = UnityEngine.Random.Range(2, 6); // also used for mass
        transform.localScale = new Vector3(Convert.ToSingle(RandomScale * 0.5), Convert.ToSingle(RandomScale*0.5), 1);
        
        // add mass in relation to size, and add an initial force
        Rigidbody2D ObsacleRB = GetComponent<Rigidbody2D>();
        ObsacleRB.mass = Convert.ToSingle(Math.Pow(RandomScale / 2, 2) * 5.196);
        ObsacleRB.AddForce(UnityEngine.Random.insideUnitCircle * UnityEngine.Random.Range(-ForceRange, ForceRange));

        transform.Rotate(new Vector3(0, 0, UnityEngine.Random.Range(0, 60)));


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
