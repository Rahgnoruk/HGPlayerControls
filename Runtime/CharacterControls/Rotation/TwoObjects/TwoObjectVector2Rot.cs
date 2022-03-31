using HyperGnosys.Core;
using UnityEngine;

namespace HyperGnosys.Skills
{
    public class TwoObjectVector2Rot : ATwoObjectRot
    {
        /// <summary>
        /// Si estas configurando una camara de jugador que rota de arriba a abajo
        /// alrededor del personaje, mete la camara en un empty e inserta el Empty 
        /// en xRotObject
        /// </summary>
        [SerializeField] private int maxXRotation = 89;
        private Vector2 currentYRotation = Vector2.zero;
        private Vector2 currentXRotation = Vector2.zero;

        private void Awake()
        {
            if (XRotObject == null || YRotObject == null)
            {
                HGDebug.LogError(transform.name + " no tiene alguno de los objetos a rotar asignado", Debugging);
            }
        }


        protected override void Look(Vector2 rotate)
        {
            if (rotate.sqrMagnitude < 0.01 || XRotObject == null || YRotObject == null)
            {
                return;
            }
            float scaledRotateSpeed = RotateSpeed.Value * Time.deltaTime;
            currentYRotation.y += rotate.x * scaledRotateSpeed;
            YRotObject.transform.localEulerAngles = currentYRotation;

            currentXRotation.x = Mathf.Clamp(currentXRotation.x - rotate.y * scaledRotateSpeed, -maxXRotation, maxXRotation);
            XRotObject.transform.localEulerAngles = currentXRotation;
        }
    }
}