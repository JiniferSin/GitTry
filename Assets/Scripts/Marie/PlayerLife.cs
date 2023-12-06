using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private Image lifeUI;
    [SerializeField] private int maxLife = 5;
    public static int _life;
    private Animator _animator;
    private SoundPlayer _audioPlayer;
    public bool hurtCooldown;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _audioPlayer = GetComponent<SoundPlayer>();
        _life = maxLife;
    }

    public void Hurt(int damage)
    {
        if (hurtCooldown == false)
        {
            _life -= damage;
            
            _animator.SetTrigger("Hurt");
            _audioPlayer.PlayAudio(SoundFX.Hurt);
            UpdateUI();
            hurtCooldown = true;
            Invoke("Cooldown", 1f);
        }
        
    }

    public void Heal(int heal)
    {
        _life += heal;
        UpdateUI();
    }

    public void Cooldown()
    {
        hurtCooldown = false;
    }

    public void UpdateUI()
    {
        lifeUI.fillAmount = (float)_life / maxLife;
    }
}
