using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GFrame.Sample
{

    public class SignDemo : MonoBehaviour
    {
        private void Awake()
        {
            SignSystem.S.InitSignSystem();
        }


        private void Start()
        {
            Debug.LogError(SignSystem.S.weekSign.signAbleIndex);
            SignSystem.S.weekSign.Sign();
            Debug.LogError(SignSystem.S.weekSign.signAbleIndex);
        }
    }
}




