using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Inventory inventory;
    int activeToolbar = 1;

    void Update()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;
        var e = Input.GetAxis("Jump");

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
    }

    void OnCollisionEnter(Collision collision)
    {
        IInventoryItem item = collision.collider.GetComponent<IInventoryItem>();
        if (item != null)
        {
            inventory.AddItem(item);
        }
    }
}