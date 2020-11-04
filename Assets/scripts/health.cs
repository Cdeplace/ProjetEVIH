
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class health : MonoBehaviour
{
    
    public Slider m_Slider;
    public GameObject uiObject;
    private float m_CurrentHealth = 100f;
    public Vector3 pos;
    bool IsInvincible;
    public GameObject Menu;
  

    public void Start()
    {
        IsInvincible = false;
        uiObject.SetActive(false);
        Menu.SetActive(false);
    }


    public void TakeDamage(float amount)
    {
        if (IsInvincible == true)
        {
            m_CurrentHealth = m_CurrentHealth;
           

        }
        if (IsInvincible == false)
        {
            m_CurrentHealth -= amount;
            if (m_CurrentHealth <= 0)
            {

                dead();
            }
            // Met à jour la barre de vie.
            SetHealthUI();
        }
        

       
  
    }


    private void SetHealthUI()
    {
        // Définit la valeur du curseur de défilement.
        m_Slider.value = m_CurrentHealth;

      
    }

    void OnTriggerEnter(Collider other)
    {
        

        if (other.gameObject.CompareTag("Heart"))
        {
            m_CurrentHealth += 20;
            SetHealthUI();
            Destroy(other.gameObject);

        }
        if (other.gameObject.CompareTag("lava"))
        {
            transform.position = new Vector3(50, 5, 0);
            TakeDamage(10f);
            

        }
        if (other.gameObject.CompareTag("Bullet"))
        {
 
            TakeDamage(10f);
            Destroy(other.gameObject);
           


        }

        if (other.gameObject.CompareTag("Star"))
        {

            IsInvincible = true;
            Destroy(other.gameObject);
            uiObject.SetActive(true);
            StartCoroutine("WaitForSec");


        }

     
    }

    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(5);
        IsInvincible = false;
        uiObject.SetActive(false);


    }

    
    void dead()
    {
        Time.timeScale = 0;
        Menu.SetActive(true);
    }

  

}