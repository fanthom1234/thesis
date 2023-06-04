using UnityEngine;

namespace ObjectiveManagerandQuestEngine
{
    public class SimpleMoveRotate : MonoBehaviour
    {
        public float moveSpeed = 5f;
        public float mouseSensitivity = 2f;

        private float rotationX;
        private float rotationY;

        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        void Update()
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");
            transform.Translate(new Vector3(moveX, 0f, moveZ) * moveSpeed * Time.deltaTime);

            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

            rotationX -= mouseY;
            rotationX = Mathf.Clamp(rotationX, -90f, 90f);

            rotationY += mouseX;

            transform.rotation = Quaternion.Euler(rotationX, rotationY, 0f);

            if(Input.GetMouseButtonDown(0))
            {
                // Hit!
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                // Casts the ray and get the first game object hit 
                if (Physics.Raycast(ray, out hit, 2))
                {
                    if(hit.collider.gameObject.name == "Dummy Training")
                    {
                        hit.transform.GetComponent<DummyTrainingScript>().GetDamage(30);
                    }
                }
            }
        }
    }
}