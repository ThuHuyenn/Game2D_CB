using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Buton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void BatDau()
    {
        SceneManager.LoadScene("Man1");
        // man1();
        // man2();
        // man3();
    }
    public void ReloadManchoi()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;//cho play lại
    }

    public void man1()
    {
        SceneManager.LoadScene("Man1");
        Time.timeScale = 1;
    }
    public void man2()
    {
        SceneManager.LoadScene("Man2");
        Time.timeScale = 1;
    }
    public void man3()
    {
        SceneManager.LoadScene("Man3");
        Time.timeScale = 1;
    }
}
