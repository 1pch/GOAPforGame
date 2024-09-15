using Unity.VisualScripting;
using UnityEngine;
using GOAP;

namespace EntityController
{
    class Entity : MonoBehaviour
    {
        [SerializeField]public float movementSpeed;
        public bool isMoving;
        GameObject currentTaget;

        public void MoveTo(GameObject gameObject)
        {
            isMoving = true;
            currentTaget = gameObject;
            transform.LookAt(currentTaget.transform.position);
            Debug.Log(isMoving);
        }
        /*public void MoveTo(Vector3 vector3)
        {
            isMoving = true;
            transform.LookAt(vector3);
            while(isMoving)
            {
                transform.position += new Vector3(movementSpeed, 0, 0);
            }
        }*/
        /*void Update()
        {
            if(isMoving)
            {
                transform.position += transform.forward * movementSpeed * Time.deltaTime;
                Debug.Log("moving");
            }
        }*/

        void OnTriggerEnter(Collider collider)
        {
            Debug.Log("collision");
            if(collider.tag == currentTaget.tag && currentTaget != null)
            {
                isMoving = false;
            }
        }
        
    }
}