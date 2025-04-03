using UnityEngine;

public class VultureAttack : MonoBehaviour
{
    public Transform player;
    public float attackDuration = 2f;
    public float flightAwaySpeed = 5f;
    public float disappearTime = 3f;
    public int damage = 10;

    private Vector3 startPos;
    private Vector3 peakPos;
    private float attackTime = 0f;
    private bool attacking = true;
    private bool flyingAway = false;

    void OnEnable()
    {
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player").transform;

        startPos = transform.position;
        peakPos = (startPos + player.position) / 2 + Vector3.up * 3f; // Adjust peak height
        attackTime = 0f;
        attacking = true;
        flyingAway = false;
    }

    void Update()
    {
        if (attacking)
        {
            attackTime += Time.deltaTime / attackDuration;
            transform.position = ParabolicLerp(startPos, peakPos, player.position, attackTime);

            if (attackTime >= 1f)
            {
                attacking = false;
                flyingAway = true;
            }
        }
        else if (flyingAway)
        {
            transform.position += Vector3.up * flightAwaySpeed * Time.deltaTime;
            Invoke("Disappear", disappearTime);
        }
    }

    Vector3 ParabolicLerp(Vector3 start, Vector3 peak, Vector3 end, float t)
    {
        Vector3 m1 = Vector3.Lerp(start, peak, t);
        Vector3 m2 = Vector3.Lerp(peak, end, t);
        return Vector3.Lerp(m1, m2, t);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //other.GetComponent<PlayerHealth>()?.TakeDamage(damage);
            flyingAway = true;
        }
    }

    void Disappear()
    {
        gameObject.SetActive(false);
    }
}
