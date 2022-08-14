using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject firePoint;
    private int _magazineCapacity = 5;
    private Vector3 _mousePos;
    public List<Image> bulletList;

    private void Start()
    {
        for (int i = 0; i < _magazineCapacity; i++)
        {
            var bullet = GameObject.Find("Canvas").transform.GetChild(i).GetComponent<Image>();
            bulletList.Add(bullet);
        }
       
    }

    private void Update()
    
    {
        LineOfSight();
        
        if (Input.GetMouseButtonDown(0) && _magazineCapacity != 0)
        {
            Shoot();
        }

        if (Input.GetKeyDown("r"))
        {
            StartCoroutine(Reload());
        }
    }

    private void Shoot()
    {
        Instantiate(bullet, firePoint.transform.position, Quaternion.identity);
        var currentIndex = 5 - _magazineCapacity;
        var currentBullet = bulletList[currentIndex];
        currentBullet.color = new Color(1, 1, 1, 0.5f);
        _magazineCapacity -= 1;

    }

    IEnumerator Reload()
    {
        if (_magazineCapacity == 0)
        {
            yield return new WaitForSeconds(1);
            _magazineCapacity = 5;
            for (int i = 0; i < _magazineCapacity; i++)
            {
                var currentBullet = bulletList[i];
                currentBullet.color = new Color(1, 1, 1, 1);

            }
        }
    }

    private void LineOfSight()
    {
        _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = _mousePos - transform.position;
        var angle = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - 90);
        
    }
}
