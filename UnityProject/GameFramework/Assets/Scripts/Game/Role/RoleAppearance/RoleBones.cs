using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

namespace Main.Game
{
    public class RoleBones : MonoBehaviour
    {
        [SerializeField] private Transform m_Root;
        [SerializeField] private Transform m_Hips;
        [SerializeField] private Transform m_Hips_Attachment;
        [SerializeField] private Transform m_Spine_01;
        [SerializeField] private Transform m_Spine_02;
        [SerializeField] private Transform m_Spine_03;
        [SerializeField] private Transform m_Clavicle_L;
        [SerializeField] private Transform m_Clavicle_R;
        [SerializeField] private Transform m_Neck;
        [SerializeField] private Transform m_Head;
        [SerializeField] private Transform m_UpperLeg_L;
        [SerializeField] private Transform m_LowerLeg_L;
        [SerializeField] private Transform m_UpperLeg_R;

        private void Awake()
        {
            string root = "Root";
            m_Root = transform.Find(root);
            m_Hips = transform.Find(root + "/Hips");
            m_Hips_Attachment = transform.Find(root + "/Hips/Hips_Attachment");
            m_Spine_01 = transform.Find(root + "/Hips/Spine_01");
            m_Spine_02 = transform.Find(root + "/Hips/Spine_01/Spine_02");
            m_Spine_03 = transform.Find(root + "/Hips/Spine_01/Spine_02/Spine_03");
            m_Clavicle_L = transform.Find(root + "/Hips/Spine_01/Spine_02/Spine_03/Clavicle_L");
            m_Clavicle_R = transform.Find(root + "/Hips/Spine_01/Spine_02/Spine_03/Clavicle_R");
            m_Neck = transform.Find(root + "/Hips/Spine_01/Spine_02/Spine_03/Neck");
            m_Head = transform.Find(root + "/Hips/Spine_01/Spine_02/Spine_03/Neck/Head");

            m_UpperLeg_L = transform.Find(root + "/Hips/UpperLeg_L");
            m_LowerLeg_L = transform.Find(root + "/Hips/UpperLeg_L/LowerLeg_L");
            m_UpperLeg_R = transform.Find(root + "/Hips/UpperLeg_R");
        }


        public Transform GetTargetBones(string bones)
        {
            switch (bones)
            {
                case "Hips":
                    return m_Hips;
                case "Hips_Attachment":
                    return m_Hips_Attachment;
                case "Spine_01":
                    return m_Spine_01;
                case "Spine_02":
                    return m_Spine_02;
                case "Spine_03":
                    return m_Spine_03;
                case "Clavicle_L":
                    return m_Clavicle_L;
                case "Clavicle_R":
                    return m_Clavicle_R;
                case "Neck":
                    return m_Neck;
                case "Head":
                    return m_Head;
            }
            // var filds = this.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            // for (int i = 0; i < filds.Length; i++)
            // {
            //     Debug.LogError(filds[i].Name);
            //     if
            // }
            return null;
        }
    }
}
