using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;
using TMPro;

public class AI_Enemy : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] GameObject get_player;
    [SerializeField] ParticleSystem muzzle__flash;
    [SerializeField] AudioSource shoot_sound;
    [SerializeField] ThirdPersonCharacter charr;
    [SerializeField] Animator enmy_anim;
    [SerializeField] Transform gun;
    [SerializeField] GameObject attached_gun;
    [SerializeField] handle_enemy_gun to_detach_gun;

    [Header("For Enemy Bullet")]
    [SerializeField] Transform instantiate_position;
    [SerializeField] GameObject bullet;

    [Header("Value")]
    [SerializeField] float distance_between_them;
    [SerializeField] float look_radius = 15f;
    [SerializeField] float Health = 100f;
    [SerializeField] float per_bullet_damage = 10f;
    [SerializeField] bool isLiving = true;

    [Header("For Explosive Damage")]
    [SerializeField] damage_by_explosive get_damage;

    private void Awake()
    {
        agent = this.gameObject.GetComponent<NavMeshAgent>();
        muzzle__flash = this.gameObject.GetComponentInChildren<ParticleSystem>();
        shoot_sound = this.gameObject.GetComponentInChildren<AudioSource>();
        enmy_anim = this.gameObject.GetComponent<Animator>();
        agent.updateRotation = false;
        enmy_anim.SetBool("Fire", false);
        isLiving = true;

        get_damage = this.gameObject.GetComponent<damage_by_explosive>();
    }
    private void Update()
    {
        if (isLiving)
        {
            distance_between_them = Vector3.Distance(transform.position, get_player.transform.position);
            if (distance_between_them <= look_radius)
            {
                //facing();
                agent.SetDestination(get_player.transform.position);
            }
            if (agent.remainingDistance > agent.stoppingDistance)
            {
                charr.Move(agent.desiredVelocity, false, false);
            }
            else
            {
                charr.Move(Vector3.zero, false, false);
            }
            if (distance_between_them <= agent.stoppingDistance)
            {
                enmy_anim.SetBool("Fire", true);
                facing();
            }
            else
            {
                enmy_anim.SetBool("Fire", false);
            }
            if (get_damage.explosive_triggered)
            {
                do_damage_();
                get_damage.set_trigger_for_explosive_false();
            }
        }
        if(Health <= 0)
        {
            enmy_anim.SetBool("DeathTrigger", true);
            to_detach_gun.set_detach_gun_true();
            isLiving = false;
        }
        else
        {
            enmy_anim.SetBool("DeathTrigger", false);
            to_detach_gun.set_detach_gun_false();
            isLiving = true;
        }
    }
    void muzzle_flash()
    {
        muzzle__flash.Play();
        shoot_sound.Play();
        
        //instantiate_enemy_bullet
        GameObject ins_enemy_bullet = Instantiate(bullet, instantiate_position.position, instantiate_position.rotation);
        Destroy(ins_enemy_bullet, 5.0f);
    }
    void facing()
    {
        
        Vector3 _direction = (get_player.transform.position - transform.position).normalized;
        Quaternion look_Rotation = Quaternion.LookRotation(new Vector3(_direction.x, 0f, _direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, look_Rotation, Time.deltaTime * 5f);
    }
    public void deduct_enemy_health()
    {
        check_attached_gun();
        if (attached_gun.name == "Remington 870")
        {
            per_bullet_damage = 50f;
        }
        else if(attached_gun.name == "AKM")
        {
            per_bullet_damage = 25f;
        }
        else
        {
            per_bullet_damage = 20f;
        }
        Health = Health - per_bullet_damage;
    }
    void check_attached_gun()
    {
        attached_gun = gun.GetChild(0).gameObject;
    }
    void do_damage_()
    {
        Health = Health - get_damage.amount_of_damage_done_by_explosive - 20f;
    }
}
