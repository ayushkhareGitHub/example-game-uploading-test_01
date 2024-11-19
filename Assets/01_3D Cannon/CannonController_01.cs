using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController_01 : MonoBehaviour
{
    public Camera gameCamera;
    public GameObject cannonHead;
    public float bulletForce;
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = Input.mousePosition;
        Vector3 worldPosition = gameCamera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, transform.position.z - gameCamera.transform.position.z));

        if (worldPosition.x > cannonHead.transform.position.x + 1)
        {
            cannonHead.transform.localEulerAngles = new Vector3(
                cannonHead.transform.localEulerAngles.x,
                cannonHead.transform.localEulerAngles.y,
                Mathf.Atan2((worldPosition.y - this.transform.position.y), (worldPosition.x - this.transform.position.x)) * Mathf.Rad2Deg - 10
            );
        }

        if (Input.GetMouseButtonDown(0))
        {
            GameObject bulletObject = Instantiate(bulletPrefab);
            bulletObject.transform.position = cannonHead.transform.position + cannonHead.transform.right * 2;
            bulletObject.GetComponent<Rigidbody> ().AddForce (cannonHead.transform.right * bulletForce);
        }
    }
}
