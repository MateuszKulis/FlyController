using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Portfolio.FlyController
{
    [CreateAssetMenu(fileName = "Ship Controller Data", menuName = "New Ship/Deafult")]
    public class ShipControllerScriptable : ScriptableObject
    {
        public float forwardSpeed = 25f, strafeSpeed = 7.5f, hoverSpeed = 5f;
        public float forwardAcceleration = 2.5f, strafeAcceleration = 2f, hoverAcceleration = 2f;

        public float lookRateSpeed = 90f;
        public float lookSlowdownSpeed = 5f;

        public float rollSpeed = 90f, rollAcceleration = 3.5f;

        #region saveVariables
        public bool isSave;

        public float _forwardSpeed = 25f, _strafeSpeed = 7.5f, _hoverSpeed = 5f;
        public float _forwardAcceleration = 2.5f, _strafeAcceleration = 2f, _hoverAcceleration = 2f;

        public float _lookRateSpeed = 90f;
        public float _lookSlowdownSpeed = 5f;

        public float _rollSpeed = 90f, _rollAcceleration = 3.5f;
        #endregion
    }
}
