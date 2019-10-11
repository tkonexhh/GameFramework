using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleSourceMeshPart : MonoBehaviour
{
    [SerializeField] private RoleMeshPart m_MeshPart;
    [SerializeField] private SkinnedMeshRenderer[] m_Meshs;

    private void Awake()
    {
        GetAllMesh();
    }

    public void GetAllMesh()
    {
        m_Meshs = transform.GetComponentsInChildren<SkinnedMeshRenderer>();
    }

    public int GetMeshCount()
    {
        return m_Meshs.Length;
    }


    public SkinnedMeshRenderer GetMeshByIndex(int index)
    {
        if (m_Meshs == null || m_Meshs.Length <= 0)
        {
            return null;
        }

        if (index < 0 || index >= m_Meshs.Length)
            return m_Meshs[0];

        return m_Meshs[index];
    }
}
