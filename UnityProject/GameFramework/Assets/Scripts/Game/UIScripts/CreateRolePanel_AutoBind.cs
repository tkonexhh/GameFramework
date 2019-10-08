using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using GFrame;

namespace Main.Game
{
	public partial class CreateRolePanel : MonoBehaviour
	{
		[SerializeField] private Toggle m_ToggleMale;
		[SerializeField] private Toggle m_ToggleFemale;
		[SerializeField] private Button m_BtnHeadReduce;
		[SerializeField] private Button m_BtnHeadAdd;
		[SerializeField] private Button m_BtnEyeBrowReduce;
		[SerializeField] private Button m_BtnEyeBrowAdd;
		[SerializeField] private Button m_BtnFacialHairReduce;
		[SerializeField] private Button m_BtnFacialHairAdd;
		[SerializeField] private Button m_BtnTorsoReduce;
		[SerializeField] private Button m_BtnTorsoAdd;
	}
}