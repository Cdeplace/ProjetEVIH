using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BigBossHealth : MonoBehaviour
{

    public GameObject particle;
    public Slider m_Slider;
    private float m_CurrentHealth = 100f;
    public Vector3 pos;
    public Light myLight;
    public GameObject Menu;

    public void Start()
    {
     
        Menu.SetActive(false);
    }


    public void TakeDamage(float amount)
    {

        m_CurrentHealth -= amount;
        if (m_CurrentHealth <= 0)
        {

            Destroy(gameObject);
            Time.timeScale = 0;
            Menu.SetActive(true);



        }

        SetHealthUI();



    }

    private void SetHealthUI()
    {
        // Définit la valeur du curseur de défilement.
        m_Slider.value = m_CurrentHealth;


    }

    void OnTriggerStay(Collider other)
    {

        if (other.gameObject.CompareTag("Bullet"))
        {


            TakeDamage(10);



        }
    }
}