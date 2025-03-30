using UnityEngine;

public class ExplosionTrigger : MonoBehaviour
{
    public GameObject explosionVFX; 
    public int damage = 100; 
    public string playerTag = "Player";
    public AudioClip Explosion;
    AudioSource ExplosionSource;

    public void Start()
    {
        ExplosionSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            ExplosionSource.PlayOneShot(Explosion);
            Instantiate(explosionVFX, transform.position, Quaternion.identity);

           
            other.GetComponent<PlayerHealth>().TakeDamage(damage);

            
            Destroy(gameObject, Explosion.length);
        }
    }
    
}

