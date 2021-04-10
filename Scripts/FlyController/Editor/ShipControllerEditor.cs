using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Portfolio.FlyController
{
    [CustomEditor(typeof(ShipControllerScriptable))]
    public class ShipControllerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            ShipControllerScriptable baseScript = (ShipControllerScriptable)target;
            EditorUtility.SetDirty(baseScript);

            #region GUI
            GUILayout.BeginVertical("HelpBox");
            GUILayout.Label("Fly Controller v0.1");

            SetSpeedValues(baseScript);
            SetAccelerationValues(baseScript);
            SetLookValues(baseScript);
            SetRollValues(baseScript);
            SetButtons(baseScript);


            GUILayout.EndVertical();
            #endregion

            serializedObject.ApplyModifiedProperties();
        }

        #region SpeedGUI
        private void SetSpeedValues(ShipControllerScriptable shipController)
        {
            GUILayout.BeginHorizontal();
            GUILayout.BeginVertical("GroupBox");
            GUILayout.Label("Speed");
            shipController.forwardSpeed = ForwardSpeed(shipController);
            shipController.strafeSpeed = StrafeSpeed(shipController);
            shipController.hoverSpeed = HoverSpeed(shipController);
            GUILayout.EndVertical();
            GUILayout.EndHorizontal();
        }
        #endregion

        #region AccelerationGUI
        private void SetAccelerationValues(ShipControllerScriptable shipController)
        {
            GUILayout.BeginHorizontal();
            GUILayout.BeginVertical("GroupBox");
            GUILayout.Label("Acceleration");
            shipController.forwardAcceleration = ForwardAcceleration(shipController);
            shipController.strafeAcceleration = StrafeAcceleration(shipController);
            shipController.hoverAcceleration = HoverAcceleration(shipController);
            GUILayout.EndVertical();
            GUILayout.EndHorizontal();
        }
        #endregion

        #region LookGUI
        private void SetLookValues(ShipControllerScriptable shipController)
        {
            GUILayout.BeginHorizontal();
            GUILayout.BeginVertical("GroupBox");
            GUILayout.Label("Look");
            shipController.lookRateSpeed = LookRateSpeed(shipController);
            shipController.lookSlowdownSpeed = LookSlowdownSpeed(shipController);
            GUILayout.EndVertical();
            GUILayout.EndHorizontal();
        }
        #endregion

        #region RollGUI
        private void SetRollValues(ShipControllerScriptable shipController)
        {
            GUILayout.BeginHorizontal();
            GUILayout.BeginVertical("GroupBox");
            GUILayout.Label("Roll");
            shipController.rollSpeed = RollSpeed(shipController);
            shipController.rollAcceleration = RollAcceleration(shipController);
            GUILayout.EndVertical();
            GUILayout.EndHorizontal();
        }
        #endregion

        #region ButtonsGUI
        private void SetButtons(ShipControllerScriptable shipController)
        {
            EditorGUILayout.Space();

            if (GUILayout.Button("Set Deafult Values"))
            {
                SetDeafultValues(shipController);
            }
            EditorGUILayout.Space();

            if (GUILayout.Button("Save Values"))
            {
                SaveValues(shipController);
            }
            EditorGUILayout.Space();

            if (GUILayout.Button("Load Values"))
            {
                LoadValues(shipController);
            }
            EditorGUILayout.Space();
        }
        #endregion


        #region Speed

        private float ForwardSpeed(ShipControllerScriptable shipController)
        {
            return EditorGUILayout.Slider("Forward Speed", shipController.forwardSpeed, 10f, 1000f);
        }

        private float StrafeSpeed(ShipControllerScriptable shipController)
        {
            return EditorGUILayout.Slider("Strafe Speed", shipController.strafeSpeed, 10f, 1000f);
        }

        private float HoverSpeed(ShipControllerScriptable shipController)
        {
            return EditorGUILayout.Slider("Hover Speed", shipController.hoverSpeed, 10f, 1000f);
        }
        #endregion

        #region Acceleration
        private float ForwardAcceleration(ShipControllerScriptable shipController)
        {
            return EditorGUILayout.Slider("Forward Acceleration", shipController.forwardAcceleration, 10f, 1000f);
        }

        private float StrafeAcceleration(ShipControllerScriptable shipController)
        {
            return EditorGUILayout.Slider("Strafe Acceleration", shipController.strafeAcceleration, 10f, 1000f);
        }

        private float HoverAcceleration(ShipControllerScriptable shipController)
        {
            return EditorGUILayout.Slider("Hover Acceleration", shipController.hoverAcceleration, 10f, 1000f);
        }
        #endregion

        #region Look
        private float LookRateSpeed(ShipControllerScriptable shipController)
        {
            return EditorGUILayout.Slider("Look Rate Speed", shipController.lookRateSpeed, 50f, 1200f);
        }

        private float LookSlowdownSpeed(ShipControllerScriptable shipController)
        {
            return EditorGUILayout.Slider("Look Slowdown Speed", shipController.lookSlowdownSpeed, 0.5f, 200f);
        }
        #endregion

        #region Roll
        private float RollSpeed(ShipControllerScriptable shipController)
        {
            return EditorGUILayout.Slider("Roll Speed", shipController.rollSpeed, 50f, 1200f);
        }

        private float RollAcceleration(ShipControllerScriptable shipController)
        {
            return EditorGUILayout.Slider("Roll Acceleration", shipController.rollAcceleration, 0.5f, 200f);
        }
        #endregion

        #region Buttons
        private void SetDeafultValues(ShipControllerScriptable shipController)
        {
            shipController.forwardSpeed = 25f;
            shipController.strafeSpeed = 7.5f;
            shipController.hoverSpeed = 5f;

            shipController.forwardAcceleration = 2.5f;
            shipController.strafeAcceleration = 2f;
            shipController.hoverAcceleration = 2f;

            shipController.lookRateSpeed = 90f;
            shipController.lookSlowdownSpeed = 5f;

            shipController.rollSpeed = 90f;
            shipController.rollAcceleration = 3.5f;
        }
        
        private void SaveValues(ShipControllerScriptable shipController)
        {
            shipController.isSave = true;

            shipController._forwardSpeed = shipController.forwardSpeed;
            shipController._strafeSpeed = shipController.strafeSpeed;
            shipController._hoverSpeed = shipController.hoverSpeed;

            shipController._forwardAcceleration = shipController.forwardAcceleration;
            shipController._strafeAcceleration = shipController.strafeAcceleration;
            shipController._hoverAcceleration = shipController.hoverAcceleration;

            shipController._lookRateSpeed = shipController.lookRateSpeed;
            shipController._lookSlowdownSpeed = shipController.lookSlowdownSpeed;

            shipController._rollSpeed = shipController.rollSpeed;
            shipController._rollAcceleration = shipController.rollAcceleration;
        }

        private void LoadValues(ShipControllerScriptable shipController)
        {
            shipController.forwardSpeed = shipController._forwardSpeed;
            shipController.strafeSpeed = shipController._strafeSpeed;
            shipController.hoverSpeed = shipController._hoverSpeed;

            shipController.forwardAcceleration = shipController._forwardAcceleration;
            shipController.strafeAcceleration = shipController._strafeAcceleration;
            shipController.hoverAcceleration = shipController._hoverAcceleration;

            shipController.lookRateSpeed = shipController._lookRateSpeed;
            shipController.lookSlowdownSpeed = shipController._lookSlowdownSpeed;

            shipController.rollSpeed = shipController._rollSpeed;
            shipController.rollAcceleration = shipController._rollAcceleration;
        }
        #endregion

    }
}
