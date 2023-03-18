using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace MeasurementTool
{
	public class EditorMeasurementTool : MonoBehaviour
	{
        private enum LengthUnitType { Meter, Centimeter, Millimeter, Kilometer, Inch, Foot, Yard, Mile }

        [SerializeField] private LengthUnitType lengthUnitType;
        [Range(0, 1000)] [SerializeField] private int rulerSize = 10;

        [SerializeField] private bool displayAxisMeasurements = true;
        [SerializeField] private bool displayXAxis = false;
        [SerializeField] private bool displayYAxis = false;
        [SerializeField] private bool displayZAxis = false;

        [SerializeField] private Transform sourceObject;
        [SerializeField] private List<Transform> targetObjects;
        [SerializeField] private bool displayInBetweenDistanceValues;
        [SerializeField] private bool displayAnglesInfo = false;
        [SerializeField] private bool displayMainPlanesAnglesInfo = false;
        [SerializeField] private bool displayReversePlanesAnglesInfo = false;

        [SerializeField] private Color textColor = Color.white;
        [SerializeField] private int textSize = 12;
        [SerializeField] private Color lineColor = Color.white;


        private float convertedDistanceFromMeter = 0;
        private float distanceMultiplier = 0;
        private string lengthUnitSymbol = "";

        private GUIStyle textStyle;

        private const float METER_VALUE = 1f;
        private const float CENTIMETER_VALUE = 0.01f;
        private const float MILLIMETER_VALUE = 0.001f;
        private const float KILOMETER_VALUE = 1000f;
        private const float INCH_VALUE = 0.0254f;
        private const float FOOT_VALUE = 0.3048f;
        private const float YARD_VALUE = 0.9144f;
        private const float MILE_VALUE = 1609.34f;

        public string NameOfLengthUnitType => nameof(lengthUnitType);
        public string NameOfRulerSize => nameof(rulerSize);
        public string NameOfDisplayAxisMeasurements => nameof(displayAxisMeasurements);
        public string NameOfDisplayXAxis => nameof(displayXAxis);
        public string NameOfDisplayYAxis => nameof(displayYAxis);
        public string NameOfDisplayZAxis => nameof(displayZAxis);
        public string NameOfSourceObject => nameof(sourceObject);
        public string NameOfTargetObject => nameof(targetObjects);
        public string NameOfDisplayInBetweenDistanceValues => nameof(displayInBetweenDistanceValues);
        public string NameOfDisplayAnglesInfo => nameof(displayAnglesInfo);
        public string NameOfDisplayMainPlanesAnglesInfo => nameof(displayMainPlanesAnglesInfo);
        public string NameOfDisplayReversePlanesAnglesInfo => nameof(displayReversePlanesAnglesInfo);
        public string NameOfTextColor => nameof(textColor);
        public string NameOfTextSize => nameof(textSize);
        public string NameOfLineColor => nameof(lineColor);

        private void OnValidate()
        {
            UpdateDistanceParameters();

            UpdateTextStyle();
        }

        private void UpdateDistanceParameters()
        {
            switch (lengthUnitType)
            {
                case LengthUnitType.Meter:
                    convertedDistanceFromMeter = rulerSize * METER_VALUE;
                    distanceMultiplier = METER_VALUE;
                    lengthUnitSymbol = "m";
                    break;
                case LengthUnitType.Centimeter:
                    convertedDistanceFromMeter = rulerSize * CENTIMETER_VALUE;
                    distanceMultiplier = CENTIMETER_VALUE;
                    lengthUnitSymbol = "cm";
                    break;
                case LengthUnitType.Millimeter:
                    convertedDistanceFromMeter = rulerSize * MILLIMETER_VALUE;
                    distanceMultiplier = MILLIMETER_VALUE;
                    lengthUnitSymbol = "mm";
                    break;
                case LengthUnitType.Kilometer:
                    convertedDistanceFromMeter = rulerSize * KILOMETER_VALUE;
                    distanceMultiplier = KILOMETER_VALUE;
                    lengthUnitSymbol = "km";
                    break;
                case LengthUnitType.Inch:
                    convertedDistanceFromMeter = rulerSize * INCH_VALUE;
                    distanceMultiplier = INCH_VALUE;
                    lengthUnitSymbol = "in";
                    break;
                case LengthUnitType.Foot:
                    convertedDistanceFromMeter = rulerSize * FOOT_VALUE;
                    distanceMultiplier = FOOT_VALUE;
                    lengthUnitSymbol = "ft";
                    break;
                case LengthUnitType.Yard:
                    convertedDistanceFromMeter = rulerSize * YARD_VALUE;
                    distanceMultiplier = YARD_VALUE;
                    lengthUnitSymbol = "yd";
                    break;
                case LengthUnitType.Mile:
                    convertedDistanceFromMeter = rulerSize * MILE_VALUE;
                    distanceMultiplier = MILE_VALUE;
                    lengthUnitSymbol = "mi";
                    break;
                default:
                    break;
            }
        }

        private void UpdateTextStyle()
        {
            textStyle = new GUIStyle() { normal = new GUIStyleState() { textColor = textColor }, fontSize = textSize, alignment = TextAnchor.MiddleCenter };
        }

        private float ConvertFromMeters(float value, LengthUnitType unitType)
        {
            float convertedValue = 0;

            switch (unitType)
            {
                case LengthUnitType.Meter:
                    convertedValue = value / METER_VALUE;
                    break;
                case LengthUnitType.Centimeter:
                    convertedValue = value / CENTIMETER_VALUE;
                    break;
                case LengthUnitType.Millimeter:
                    convertedValue = value / MILLIMETER_VALUE;
                    break;
                case LengthUnitType.Kilometer:
                    convertedValue = value / KILOMETER_VALUE;
                    break;
                case LengthUnitType.Inch:
                    convertedValue = value / INCH_VALUE;
                    break;
                case LengthUnitType.Foot:
                    convertedValue = value / FOOT_VALUE;
                    break;
                case LengthUnitType.Yard:
                    convertedValue = value / YARD_VALUE;
                    break;
                case LengthUnitType.Mile:
                    convertedValue = value / MILE_VALUE;
                    break;
                default:
                    break;
            }

            return convertedValue;
        }

        #if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            if (displayAxisMeasurements && displayXAxis)
                DrawAxis(Vector3.left, Vector3.right, Color.red);
            if (displayAxisMeasurements && displayYAxis)
                DrawAxis(Vector3.down, Vector3.up, Color.green);
            if (displayAxisMeasurements && displayZAxis)
                DrawAxis(Vector3.back, Vector3.forward, Color.blue);

            if (targetObjects != null && targetObjects.Count > 0)
                DrawTargetInformation();
        }

        private void DrawAxis(Vector3 startDirection, Vector3 endDirection, Color axisColor)
        {
            Gizmos.color = axisColor;
            Vector3 startPoint = transform.position + (startDirection * convertedDistanceFromMeter);
            Vector3 endPoint = transform.position + (endDirection * convertedDistanceFromMeter);
            Gizmos.DrawLine(startPoint, endPoint);
            Gizmos.color = Color.white;

            DrawDistanceLabels(startPoint, endDirection);
        }

        private void DrawDistanceLabels(Vector3 startPoint, Vector3 direction)
        {
            Vector3 rulerStartPoint = startPoint;
            for (int i = -rulerSize; i <= rulerSize; i++)
            {
                Handles.Label(rulerStartPoint, i.ToString() + lengthUnitSymbol, textStyle);
                rulerStartPoint += (direction * distanceMultiplier);
            }
        }

        private void DrawTargetInformation()
        {
            Transform source = sourceObject == null ? transform : sourceObject;

            foreach (Transform targetObject in targetObjects)
            {
                if (targetObject == null)
                    continue;

                float distance = Vector3.Distance(source.position, targetObject.position);

                string convertedDistanceString = ConvertFromMeters(distance, lengthUnitType).ToString() + lengthUnitSymbol;

                Gizmos.color = lineColor;
                Gizmos.DrawLine(source.position, targetObject.position);
                Gizmos.color = Color.white;
                Handles.Label(targetObject.position, "Distance: " + convertedDistanceString + "\n" + GetAnglesRelatedToPlanes(source, targetObject), textStyle);

                if (displayInBetweenDistanceValues)
                {
                    Vector3 rulerStartPoint = source.position;
                    Vector3 direction = (targetObject.position - source.position).normalized;
                    for (int i = 0; i <= Mathf.FloorToInt(distance / distanceMultiplier); i++)
                    {
                        Handles.Label(rulerStartPoint, i.ToString() + lengthUnitSymbol, textStyle);
                        rulerStartPoint += (direction * distanceMultiplier);
                    }
                }
            }
        }

        private string GetAnglesRelatedToPlanes(Transform source, Transform target)
        {
            if (!displayAnglesInfo)
                return string.Empty;

            Vector3 direction = target.transform.position - source.transform.position;

            // Decompose the angle into individual x, y, and z axis rotations
            //float xRotation = Mathf.Atan(Mathf.Sqrt((direction.z * direction.z) + (direction.y * direction.y)) / (direction.x)) * Mathf.Rad2Deg;
            //float yRotation = Mathf.Atan(Mathf.Sqrt((direction.x * direction.x) + (direction.z * direction.z)) / (direction.y)) * Mathf.Rad2Deg;
            //float zRotation = Mathf.Atan(Mathf.Sqrt((direction.x * direction.x) + (direction.y * direction.y)) / (direction.z)) * Mathf.Rad2Deg;
            string anglesString = "";

            if (displayMainPlanesAnglesInfo)
            {
                float xy = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                float xz = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg;
                float zy = Mathf.Atan2(direction.y, direction.z) * Mathf.Rad2Deg;
                anglesString += "XY: " + xy.ToString("F4") + "°\n";
                anglesString += "XZ: " + xz.ToString("F4") + "°\n";
                anglesString += "ZY: " + zy.ToString("F4") + "°\n";
            }

            if (displayReversePlanesAnglesInfo)
            {
                float yx = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
                float zx = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
                float yz = Mathf.Atan2(direction.z, direction.y) * Mathf.Rad2Deg;
                anglesString += "YX: " + yx.ToString("F4") + "°\n";
                anglesString += "ZX: " + zx.ToString("F4") + "°\n";
                anglesString += "YZ: " + yz.ToString("F4") + "°\n";
            }

            return anglesString;
        }

        [MenuItem("Tools/Measurement Tool")]
        public static void AddMeasurementToolToScene()
        {
            GameObject measurementToolGameObject = new GameObject("MeasurementTool");
            measurementToolGameObject.AddComponent<EditorMeasurementTool>();
        }
        #endif
    }
}