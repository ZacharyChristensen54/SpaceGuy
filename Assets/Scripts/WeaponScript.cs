using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public float shotSpeed;

    public Transform shotPrefab;

    public float shootingRate = 0.25f;

    public float shootCooldown = 0f;

    // Update is called once per frame
    void Update()
    {
        if (shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        }
    }

    public void Attack(bool isEnemy)
    {
        if (CanAttack)
        {
            shootCooldown = shootingRate;

            var shotTransform = Instantiate(shotPrefab) as Transform;

            shotTransform.position = transform.position;

            ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
            if (shot != null)
            {
                shot.isEnemyShot = isEnemy;
            }

            Destroy(shotTransform.gameObject, 5);
            Vector2 mousePos = Input.mousePosition;

            Vector2 objPos = Camera.main.WorldToScreenPoint(transform.position);
            mousePos.x = -(mousePos.x - objPos.x);
            mousePos.y = -(mousePos.y - objPos.y);

            float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
            Vector2 movement = new Vector2(mousePos.x * shotSpeed, mousePos.y * shotSpeed);
            Vector3 rotation = new Vector3(0, 0, angle);

            shotTransform.rotation = Quaternion.Euler(rotation);
            shotTransform.GetComponent<Rigidbody2D>().AddForce(movement);

        }
    }

    public bool CanAttack
    {
        get
        {
            return shootCooldown <= 0f;
        }
    }
}
