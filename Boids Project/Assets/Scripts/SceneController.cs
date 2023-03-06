using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public BoidController boidPre;
    public int boidNumber=100;
    private List<BoidController> _boids;


    private void SpawnBoid(GameObject prefab, int swarmIndex){
        var boidInstance=Instantiate(prefab);
        boidInstance.transform.localPosition+= new Vector3(Random.Range(-10,10),Random.Range(-10,10),Random.Range(-10,10));
        _boids.Add(boidPre);
    }




    // Start is called before the first frame update
    private void Start()
    {
        _boids= new List<BoidController>();
        for(int i=0; i<boidNumber; i++){
            SpawnBoid(boidPre.gameObject,0);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
}
