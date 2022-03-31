using HyperGnosys.Core;
using UnityEngine;

public static class ColliderIsGrounded
{
    private static RaycastHit hitInfo = new RaycastHit();
    private static Ray ray = new Ray();
    public static bool IsGrounded(Collider collider, float xRange, float zRange, bool debug = false, int ignoreLayer = -1)
    {
        Vector3 origin = collider.bounds.center;// + collider.bounds.extents;
        float maxDistance = collider.bounds.extents.y + 0.01f;
        ray.origin = origin;
        for (float x = -xRange; x <= xRange; x += 0.1f)
        {
            for (float y = -zRange; y <= zRange; y += 0.1f)
            {
                ray.direction = new Vector3(x, -1, y);
                HGDebug.DrawRay(ray.origin, ray.direction * maxDistance, debug, Color.red);
                ///Si la desiredLayer es -1 se manda el raycast sin especificar la layer
                ///para que choque contra todas.
                if (ignoreLayer == -1)
                {
                    if (Physics.Raycast(ray, out hitInfo, maxDistance))
                    {
                        HGDebug.Log("ColliderIsGrounded ray hit " + hitInfo.transform.name, debug);
                        return true;
                    }
                }
                else
                {
                    if (Physics.Raycast(ray, out hitInfo, maxDistance, ignoreLayer))
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }
}