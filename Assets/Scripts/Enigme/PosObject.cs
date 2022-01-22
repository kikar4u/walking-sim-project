using UnityEngine;

public class PosObject : MonoBehaviour
{
    [SerializeField]
    public int idObject;
    [SerializeField] Quaternion rotationToHave;
    [SerializeField] Vector3 positionToHave;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MovableObject")
        {
            if (other.gameObject.GetComponent<MovableObject>().idObject == idObject)
            {
                other.GetComponent<MovableObject>().isOnPlace = true;
                if (positionToHave != new Vector3(0, 0, 0))
                {
                    other.gameObject.transform.position = positionToHave;
                }
                else
                {
                    other.gameObject.transform.position = this.gameObject.transform.position;

                }
                other.gameObject.transform.rotation = rotationToHave;
                other.gameObject.GetComponent<Rigidbody>().useGravity = false;
                other.gameObject.GetComponent<Rigidbody>().isKinematic = true;

                Debug.Log("LE DEMON MDR");
            }
            else
            {
                other.GetComponent<MovableObject>().isOnPlace = false;
                if (positionToHave != new Vector3(0, 0, 0))
                {
                    other.gameObject.transform.position = positionToHave;
                }
                else
                {
                    other.gameObject.transform.position = this.gameObject.transform.position;

                }
                other.gameObject.transform.rotation = rotationToHave;
                other.gameObject.GetComponent<Rigidbody>().useGravity = false;
                other.gameObject.GetComponent<Rigidbody>().isKinematic = true;

                Debug.Log("LE DEMON MDR");
            }

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "MovableObject")
        {
            other.gameObject.GetComponent<Rigidbody>().useGravity = true;
            other.gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
            other.GetComponent<MovableObject>().isOnPlace = false;
            Debug.Log("LE DEMON plus la");
        }
    }
}
