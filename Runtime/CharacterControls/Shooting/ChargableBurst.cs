using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

namespace HyperGnosys.Skills
{
    public class ChargableBurst : MonoBehaviour
    {
        [SerializeField] private float burstSpeed;
        [SerializeField] private GameObject projectile;

        private bool isCharging;

        public float BurstSpeed { get => burstSpeed; set => burstSpeed = value; }
        public GameObject Projectile { get => projectile; set => projectile = value; }

        public void OnFire(InputAction.CallbackContext context)
        {
            switch (context.phase)
            {
                case InputActionPhase.Performed:
                    if (context.interaction is SlowTapInteraction)
                    {
                        StartCoroutine(BurstFire((int)(context.duration * burstSpeed)));
                    }
                    else
                    {
                        Fire();
                    }
                    isCharging = false;
                    break;

                case InputActionPhase.Started:
                    if (context.interaction is SlowTapInteraction)
                        isCharging = true;
                    break;

                case InputActionPhase.Canceled:
                    isCharging = false;
                    break;
            }
        }
        public void OnGUI()
        {
            if (isCharging)
                GUI.Label(new Rect(100, 100, 200, 100), "Charging...");
        }
        private IEnumerator BurstFire(int burstAmount)
        {
            for (var i = 0; i < burstAmount; ++i)
            {
                Fire();
                yield return new WaitForSeconds(0.1f);
            }
        }

        private void Fire()
        {
            var transform = this.transform;
            var newProjectile = Instantiate(projectile);
            newProjectile.transform.position = transform.position + transform.forward * 0.6f;
            newProjectile.transform.rotation = transform.rotation;
            const int size = 1;
            newProjectile.transform.localScale *= size;
            newProjectile.GetComponent<Rigidbody>().mass = Mathf.Pow(size, 3);
            newProjectile.GetComponent<Rigidbody>().AddForce(transform.forward * 20f, ForceMode.Impulse);
            newProjectile.GetComponent<MeshRenderer>().material.color =
                new Color(Random.value, Random.value, Random.value, 1.0f);
        }
    }
}