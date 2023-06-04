using UnityEngine;

namespace ObjectiveManagerandQuestEngine
{
    public class TargetPointer : MonoBehaviour
    {
        public Texture arrow;
        public float size = 30;
        public GameObject PointedTarget;
        public bool hoverOnScreen = true;
        public float distanceAbove = 20;
        public float blindSpot = 0.5f;
        public float hoverAngle = 270;
        private float xCenter;
        private float yCenter;
        private float halfSize;
        private float screenSlope;
        public Camera camera;
        public static TargetPointer Instance;

        private void Awake()
        {
            Instance = this;
        }

        void Start()
        {
            if (camera == null)
            {
                camera = Camera.main;
            }
        }

        void OnGUI()
        {
            if (PointedTarget == null || camera == null) return;


            if (PointedTarget != null && Time.timeScale != 0)
            {
                if (Event.current.type.Equals(EventType.Repaint))
                {
                    xCenter = camera.pixelWidth / 2;
                    yCenter = camera.pixelHeight / 2;
                    screenSlope = camera.pixelHeight / camera.pixelWidth;
                    halfSize = size / 2;

                    float angle = hoverAngle - 180;
                    float rad = angle * (Mathf.PI / 180);
                    Vector3 arrowPos = camera.transform.right * Mathf.Cos(rad) + camera.transform.up * Mathf.Sin(rad);
                    Vector3 worldPos = PointedTarget.transform.position + (arrowPos * distanceAbove);
                    Vector3 pos = camera.WorldToViewportPoint(worldPos);

                    if (pos.z < 0)
                    {
                        pos.x *= -1;
                        pos.y *= -1;
                    }

                    if (pos.z > 0 || (pos.z < 0 && (pos.x > .5 + (blindSpot / 2) || pos.x < .5 - (blindSpot / 2))
                            && (pos.y < .5 - (blindSpot / 2) || pos.y > .5 + (blindSpot / 2))))
                    {
                        var newX = pos.x * camera.pixelWidth;
                        var newY = camera.pixelHeight - pos.y * camera.pixelHeight;
                        if (pos.z < 0 || (newY < 0 || newY > camera.pixelHeight || newX < 0 || newX > camera.pixelWidth))
                        {
                            float a = CalculateAngle(camera.pixelWidth / 2, camera.pixelHeight / 2, newX, newY);
                            Vector2 coord = ProjectToEdge(newX, newY);
                            GUIUtility.RotateAroundPivot(a, coord);
                            Graphics.DrawTexture(new Rect(coord.x - halfSize, coord.y - halfSize, size, size), arrow);
                            GUIUtility.RotateAroundPivot(-a, coord);
                        }
                        else if (hoverOnScreen)
                        {
                            float nh = Mathf.Sin(rad) * size;
                            float nw = Mathf.Cos(rad) * size;
                            GUIUtility.RotateAroundPivot(-angle + 180, new Vector2(newX + nw, newY - nh));
                            Graphics.DrawTexture(new Rect(newX + nw, newY - nh - halfSize, size, size), arrow, null);
                            GUIUtility.RotateAroundPivot(angle - 180, new Vector2(newX + nw, newY - nh));
                        }
                    }
                }
            }
        }

        float CalculateAngle(float x1, float y1, float x2, float y2)
        {
            var xDiff = x2 - x1;
            var yDiff = y2 - y1;
            var rad = Mathf.Atan(yDiff / xDiff);
            var deg = rad * 180 / Mathf.PI;

            if (xDiff < 0)
            {
                deg += 180;
            }

            return deg;
        }

        Vector2 ProjectToEdge(float x2, float y2)
        {
            float xDiff = x2 - (camera.pixelWidth / 2);
            float yDiff = y2 - (camera.pixelHeight / 2);
            float slope = yDiff / xDiff;

            Vector2 coord = new Vector2(0, 0);

            float ratio;

            if (slope > screenSlope || slope < -screenSlope)
            {
                ratio = (yCenter - halfSize) / yDiff;
                if (yDiff < 0)
                {
                    coord.y = halfSize;
                    ratio *= -1;
                }
                else coord.y = camera.pixelHeight - halfSize;
                coord.x = xCenter + xDiff * ratio;
            }
            else
            {
                ratio = (xCenter - halfSize) / xDiff;
                if (xDiff < 0)
                {
                    coord.x = halfSize;
                    ratio *= -1;
                }
                else coord.x = camera.pixelWidth - halfSize;
                coord.y = yCenter + yDiff * ratio;
            }
            return coord;
        }
    }
}