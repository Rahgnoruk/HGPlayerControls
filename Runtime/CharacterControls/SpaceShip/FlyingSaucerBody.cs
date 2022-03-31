using HyperGnosys.Core;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class FlyingSaucerBody : MonoBehaviour
{
    [SerializeField] private GameObject playerDeathPrefab;
    [SerializeField] private VoidScriptableEvent onPlayerDeath;
    private new Rigidbody rigidbody;
    void Awake()
    {
        rigidbody = transform.GetComponent<Rigidbody>();
        onPlayerDeath.AddListener(Die);
    }
    void OnCollisionEnter(Collision other)
    {
        onPlayerDeath.Raise(new Void());
    }
    public void Die(Void arg0)
    {
        Instantiate(playerDeathPrefab, transform.position, transform.rotation);
        gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        onPlayerDeath.RemoveListener(Die);
    }
    public Transform Body { get => transform; }
    public Rigidbody Rigidbody { get => rigidbody; }
}
