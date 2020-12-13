using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public ParticleSystem deathParticles;

    public Transform target;
	public float speed = 10f;
	Rigidbody rig;
	private Animator mAnimator;
     static int deathNumber=0;
    int health=100;
    static AudioSource audioSrc;
    public static AudioClip attack;
    public List<Vector3> EscapeDirections = new List<Vector3>();
    Vector3 storeTarget;
    Vector3 newTargetPos;
    bool savePos;
    bool overrideTarget;
    Transform obstacle;
    // Start is called before the first frame update
    void Start()
    {	
	target= GameObject.FindGameObjectWithTag("Player").transform;
	mAnimator = GetComponent<Animator>();
	rig=GetComponent<Rigidbody>();
        attack = Resources.Load<AudioClip>("spider");
        audioSrc = GetComponent<AudioSource>();
     }

//     Update is called once per frame
    void FixedUpdate()
    {
        if (mAnimator.GetCurrentAnimatorStateInfo(0).IsName("walk") || mAnimator.GetCurrentAnimatorStateInfo(0).IsName("attack"))
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime * 2);
            rig.MovePosition(pos);
            transform.LookAt(target);
            
            if (Vector3.Distance(transform.position, target.position) < 10.0f)
             mAnimator.SetTrigger("attack");  
         }

        if (deathNumber == 5)
            SceneManager.LoadScene("Winner");
       
        if (Vector3.Distance(transform.position, target.position) < 0.001f)
                 target.position *= -1.0f;
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "bullet")
        {
            health = health - 50;
            SoundManagerScript.PlaySound("bulletHit");
        }

        if (health == 0)
        {
            deathNumber++;
            mAnimator.SetTrigger("die");
            Destroy();

            if (deathNumber == 5)
                SceneManager.LoadScene("Winner");

        }
      }


    public void Destroy()
    {
        if (deathParticles != null)
       {
            Instantiate(deathParticles, transform.position, Quaternion.identity);
            Destroy(gameObject, 2);
        }
        Destroy(gameObject);
    }


          IEnumerator Quit(){
        yield return new WaitForSeconds(2);
        Application.Quit();
    }
}

