using System;
using UnityEngine;

public class ParticleSupplier : MonoBehaviour
{
    public ParticleInstance[] ptcArr;

    public static ParticleSupplier instance;
    private void Start()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void SetParticle(Vector3 _pos, string _name)
    {
        ParticleInstance p = Array.Find(ptcArr, ptc => ptc.name == _name);
        if (p == null)
        {
            Debug.LogWarning("ParticleSupplier: " + _name + " does not found!");
            return;
        }

        GameObject obj = Instantiate(p.obj, _pos, Quaternion.Euler(0f, 0f, 0f));
    }
}

[System.Serializable]
public class ParticleInstance
{
    public string name;
    public GameObject obj;
}