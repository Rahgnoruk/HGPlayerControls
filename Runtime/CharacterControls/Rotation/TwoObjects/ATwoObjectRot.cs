using UnityEngine;

namespace HyperGnosys.Skills
{
    public abstract class ATwoObjectRot : ARotObject
    {
        [SerializeField] private GameObject xRotObject;
        [SerializeField] private GameObject yRotObject;

        protected GameObject XRotObject { get => xRotObject; set => xRotObject = value; }
        protected GameObject YRotObject { get => yRotObject; set => yRotObject = value; }
    }
}